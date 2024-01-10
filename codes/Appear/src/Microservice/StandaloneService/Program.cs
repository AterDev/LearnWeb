var builder = WebApplication.CreateBuilder(args);

// if use AppHost then use this
// builder.AddServiceDefaults();

IServiceCollection services = builder.Services;
ConfigurationManager configuration = builder.Configuration;

// 1 基础组件
services.AddAppComponents(configuration);
services.AddWebComponents(configuration);

// 2 授权配置
services.AddAuthorizationBuilder()
    .AddPolicy(AppConst.User, policy => policy.RequireRole(AppConst.User))
    .AddPolicy(AppConst.AdminUser, policy => policy.RequireRole(AppConst.SuperAdmin, AppConst.AdminUser))
    .AddPolicy(AppConst.SuperAdmin, policy => policy.RequireRole(AppConst.SuperAdmin));

services.AddHttpContextAccessor();
services.AddTransient<IUserContext, UserContext>();
services.AddTransient<ITenantProvider, TenantProvider>();
// 3 数据及业务接口注入
services.AddManager();
// 4 其他自定义选项及服务
services.AddSingleton(typeof(CacheService));

services.AddControllers()
    .ConfigureApiBehaviorOptions(o =>
    {
        o.InvalidModelStateResponseFactory = context =>
        {
            return new CustomBadRequest(context, null);
        };
    }).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
    });

var app = builder.Build();

// if use AppHost then use this
// app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseCors("default");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/service/swagger.json", name: "service");
    });
}
else
{
    app.UseCors("default");
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
// 异常统一处理
app.UseExceptionHandler(ExceptionHandler.Handler());
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
