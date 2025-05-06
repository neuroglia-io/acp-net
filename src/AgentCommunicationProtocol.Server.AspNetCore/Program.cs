using AgentCommunicationProtocol.Storage.DistributedCache;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediator(options =>
{
    options.ScanAssembly(typeof(AgentCommunicationProtocol.Server.Commands.Threads.CreateThreadCommandHandler).Assembly);
});
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProblemDetailsExceptionFilter());
    options.Conventions.Add(new AcpRoutePrefixConvention("/acp"));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddOpenApi();

//todo: remove (and remove reference to distributed cache assembly
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAcpServer(builder =>
{
    builder.UseDistributedCacheStorage();
});

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference("api/doc", options =>
{
    options.Title = "Agent Communication Protocol API";
});
app.MapControllers();
await app.RunAsync();
