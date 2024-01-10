
using Microsoft.EntityFrameworkCore.Query;

namespace StandaloneService.Definition.EntityFramework.DBProvider;

public partial class ContextBase(DbContextOptions options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        OnModelExtendCreating(builder);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry? entityEntry in entries)
        {
            Microsoft.EntityFrameworkCore.Metadata.IProperty? property = entityEntry.Metadata.FindProperty("CreatedTime");
            if (property != null && property.ClrType == typeof(DateTimeOffset))
            {
                entityEntry.Property("CreatedTime").CurrentValue = DateTimeOffset.UtcNow;
            }
        }
        entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry? entityEntry in entries)
        {
            Microsoft.EntityFrameworkCore.Metadata.IProperty? property = entityEntry.Metadata.FindProperty("UpdatedTime");
            if (property != null && property.ClrType == typeof(DateTimeOffset))
            {
                entityEntry.Property("UpdatedTime").CurrentValue = DateTimeOffset.UtcNow;

            }
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void OnModelExtendCreating(ModelBuilder modelBuilder)
    {
        IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType> entityTypes = modelBuilder.Model.GetEntityTypes();
        foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType entityType in entityTypes)
        {
            if (typeof(IEntityBase).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.Name)
                    .HasKey("Id");
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(ConvertFilterExpression<IEntityBase>(e => !e.IsDeleted, entityType.ClrType));
            }
        }
    }

    private static LambdaExpression ConvertFilterExpression<TInterface>(Expression<Func<TInterface, bool>> filterExpression, Type entityType)
    {
        ParameterExpression newParam = Expression.Parameter(entityType);
        Expression newBody = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.Single(), newParam, filterExpression.Body);

        return Expression.Lambda(newBody, newParam);
    }
}
