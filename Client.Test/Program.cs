using static Client.Test.Protos.Permission;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpcClient<PermissionClient>(o => {
    o.Address = new Uri(builder.Configuration["GRPC_Permission_Server_Address"]);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
