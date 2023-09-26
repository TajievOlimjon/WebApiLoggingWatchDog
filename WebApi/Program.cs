using WatchDog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWatchDogServices(configure =>
{
    configure.IsAutoClear = true;
    //configure.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Weekly;
    configure.SetExternalDbConnString = builder.Configuration.GetConnectionString("DefaultConnection");
    configure.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.PostgreSql;
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseWatchDogExceptionLogger();
app.UseWatchDog(configure =>
{
    configure.WatchPageUsername = "Admin";
    configure.WatchPagePassword = "12345";
});
app.Run();
