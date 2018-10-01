## Base odata v4 service use netcore 2.1

Use [vscode](https://code.visualstudio.com/) or [visualstudio 2017](https://visualstudio.microsoft.com/) editor.

cmd code .

### New webapi project
 
```
> dotnet new webapi
```

### Add package efcore and odata

```
> dotnet add package Microsoft.EntityFrameworkCore --version 2.1.3
> dotnet add package Microsoft.AspNetCore.OData --version 7.0.1
```

### Models

```
public class Test
{
    [Key]
    public int Id { get; set; } 
    public long? A { get; set; } 
    public double? J { get; set; }   
    public string D { get; set; } 
    public DateTime? E { get; set; }    
    public byte[] B { get; set; }
    ...
}
```

#### Type map

|SqlType|ClrType|
|:---|:---|
|int|int|
|bigint|long|
|real|float|
|uniqueidentifier|Guid|
|smallint|short|
|datetimeoffset|DateTimeOffset|
|time|TimeSpan|
|tinyint|byte|
|char|int|
|bigint|string|
|nchar|string|
|ntext|string|
|nvarchar|string|
|varchar|string|
|xml|string|
|date|DateTime|
|datetime|DateTime|
|datetime2|DateTime|
|decimal|decimal|
|money|decimal|
|numeric|decimal|
|smallmoney|decimal|
|binary|byte[]|
|timestamp|byte[]|
|varbinary|byte[]|
|image|byte[]|

### Contexts
```
public partial class TestContext : DbContext
{
    public TestContext(DbContextOptions<TestContext> options):base(options)
    {
    }
    public virtual DbSet<Test> Test { get; set; }
}
```

### Controllers

```
[Produces("application/json")]
public class TestController : ODataController
{
    private readonly TestContext _context;
 
    public TestController(TestContext context) => this._context = context;

    [EnableQuery]
    public IQueryable<Test> Get() => this._context.Test;
}
```

### Startup

```
public void ConfigureServices(IServiceCollection services)
{
	services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    services.AddOData();
    var connection = Configuration.GetConnectionString("Test1");
    services.AddDbContext<TestContext>(options => options.UseSqlServer(connection));
}
```

```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder(app.ApplicationServices);
    builder.EntitySet<Test>("Test");
    app.UseMvc(routeBuilder =>
    {
        routeBuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
        routeBuilder
            .MaxTop(null)
            .Filter() // Allow for the $filter Command
            .Count() // Allow for the $count Command
            .Expand() // Allow for the $expand Command
            .OrderBy() // Allow for the $orderby Command
            .Select() // Allow for the $select Command
            .Expand();
            routeBuilder.EnableDependencyInjection();
	});
}
```

[Noah Li](https://github.com/huiali)
