using Microsoft.EntityFrameworkCore;

namespace Ater.Web.Abstraction.EntityFramework;
/// <summary>
/// 数据访问层抽象
/// </summary>
public class DataAccessContextBase<TCommandContext, TQueryContext, TEntity>(TCommandContext commandDbContext, TQueryContext queryDbContext)
    where TCommandContext : DbContext
    where TQueryContext : DbContext
    where TEntity : class, IEntityBase
{
    private readonly TCommandContext _commandDbContext = commandDbContext;
    private readonly TQueryContext _queryDbContext = queryDbContext;

    public TQueryContext QueryContext { get; init; } = queryDbContext;
    public TCommandContext CommandContext { get; init; } = commandDbContext;

    public int MyProperty { get; set; }

    public QuerySet<TQueryContext, TEntity> QuerySet() => new(_queryDbContext);
    public CommandSet<TCommandContext, TEntity> CommandSet() => new(_commandDbContext);
}
