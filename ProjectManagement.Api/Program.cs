using ProjectManagement.BLL;
using ProjectManagement.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
    options.AddPolicy("Angular", policy => policy
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()));

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinessLogic();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProjectManagement.DAL.Data.ProjectManagementDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseCors("Angular");
app.MapGet("/", () => Results.Ok(new { message = "ProjectManagement API is running" }));
app.MapControllers();

app.Run();
