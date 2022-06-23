using MeFitCase_Assignment.Repositories;
using MeFitCase_Assignment.Repositories.Interfaces;
using MeFitCase_Assignment.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DBContext
builder.Services.AddDbContext<MeFitPostgreSqlContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("MeFitPostgreSQL")));

//Automapper
builder.Services.AddAutoMapper(typeof(Program));

#region Repositories
builder.Services.AddTransient<ILoginAsyncRepository, ProfileAsyncRepository>();

builder.Services.AddScoped(typeof(IProfileAsyncRepository), typeof(ProfileAsyncRepository));
builder.Services.AddScoped(typeof(IProgramAsyncRepository), typeof(ProgramAsyncRepository));
builder.Services.AddScoped(typeof(IGoalAsyncRepository), typeof(GoalAsyncRepository));
builder.Services.AddScoped(typeof(IProgramWorkoutAsyncRepository), typeof(ProgramWorkoutAsyncRepository));
builder.Services.AddScoped(typeof(IGoalWorkoutAsyncRepository), typeof(GoalWorkoutAsyncRepository));
builder.Services.AddScoped(typeof(IFitnessAttributesAsyncRepository), typeof(FitnessAttributesAsyncRepository));
builder.Services.AddScoped(typeof(IWorkoutAsyncRepository), typeof(WorkoutRepository));
builder.Services.AddScoped(typeof(IWorkoutGoalControllerAsyncRepository), typeof(WorkoutRepository));
builder.Services.AddScoped(typeof(IAddressAsyncRepository), typeof(AddressAsyncRepository));
builder.Services.AddScoped(typeof(IExerciseAsyncRepository), typeof(ExerciseAsyncRepository));
#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policyBuilder => policyBuilder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("_myAllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

