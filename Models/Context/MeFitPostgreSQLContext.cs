using MeFitCase_Assignment.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Models.Context;

public class MeFitPostgreSqlContext : DbContext
{
    public MeFitPostgreSqlContext()
    {
    }

    public MeFitPostgreSqlContext(DbContextOptions<MeFitPostgreSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; } = null!;
    public virtual DbSet<Exercise> Exercises { get; set; } = null!;
    public virtual DbSet<FitnessAttribute> FitnessAttributes { get; set; } = null!;
    public virtual DbSet<Goal> Goals { get; set; } = null!;
    public virtual DbSet<GoalWorkout> GoalWorkouts { get; set; } = null!;
    public virtual DbSet<Profile> Profiles { get; set; } = null!;
    public virtual DbSet<Domain.Program> Programs { get; set; } = null!;
    public virtual DbSet<ProgramWorkout> ProgramWorkouts { get; set; } = null!;
    public virtual DbSet<Set> Sets { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Workout> Workouts { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(50)
                .HasColumnName("addressLine1");

            entity.Property(e => e.AddressLine2)
                .HasMaxLength(50)
                .HasColumnName("addressLine2");

            entity.Property(e => e.AddressLine3)
                .HasMaxLength(50)
                .HasColumnName("addressLine3");

            entity.Property(e => e.City)
                .HasMaxLength(58)
                .HasColumnName("city");

            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postalCode");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToTable("Exercise");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");

            entity.Property(e => e.ImageLink)
                .HasMaxLength(300)
                .HasColumnName("imageLink");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");

            entity.Property(e => e.TargetMuscleGroup)
                .HasMaxLength(200)
                .HasColumnName("targetMuscleGroup");

            entity.Property(e => e.VideoLink)
                .HasMaxLength(200)
                .HasColumnName("videoLink");
        });

        modelBuilder.Entity<FitnessAttribute>(entity =>
        {
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Disabilities)
                .HasColumnType("character varying[]")
                .HasColumnName("disabilities");

            entity.Property(e => e.Height).HasColumnName("height");

            entity.Property(e => e.MedicalConditions)
                .HasColumnType("character varying[]")
                .HasColumnName("medicalConditions");

            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.ToTable("Goal");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.EndDate).HasColumnName("endDate");

            entity.Property(e => e.IsAchieved)
                .HasColumnName("isAchieved")
                .HasDefaultValueSql("false");

            entity.Property(e => e.ProgramId).HasColumnName("programId");

            entity.HasOne(d => d.Program)
                .WithMany(p => p.Goals)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("programId");
        });

        modelBuilder.Entity<GoalWorkout>(entity =>
        {
            entity.ToTable("GoalWorkout");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.EndDate).HasColumnName("endDate");

            entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");

            entity.Property(e => e.GoalId).HasColumnName("goalId");

            entity.Property(e => e.WorkoutId).HasColumnName("workoutId");

            entity.HasOne(d => d.Goal)
                .WithMany(p => p.GoalWorkouts)
                .HasForeignKey(d => d.GoalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goalId");

            entity.HasOne(d => d.Workout)
                .WithMany(p => p.GoalWorkouts)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workoutId");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.ToTable("Profile");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.AddressId).HasColumnName("addressId");

            entity.Property(e => e.FitnessAttributesId).HasColumnName("fitnessAttributesId");

            entity.Property(e => e.GoalId).HasColumnName("goalId");

            entity.Property(e => e.KeycloakId).HasColumnName("keycloakId");

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Profiles)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("addressId");

            entity.HasOne(d => d.FitnessAttributes)
                .WithMany(p => p.Profiles)
                .HasForeignKey(d => d.FitnessAttributesId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fitnessAttributesId");

            entity.HasOne(d => d.Goal)
                .WithMany(p => p.Profiles)
                .HasForeignKey(d => d.GoalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("goalId");
        });

        modelBuilder.Entity<Domain.Program>(entity =>
        {
            entity.ToTable("Program");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .HasColumnName("category");

            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("Description");
        });

        modelBuilder.Entity<ProgramWorkout>(entity =>
        {
            entity.ToTable("ProgramWorkout");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.ProgramId).HasColumnName("programId");

            entity.Property(e => e.WorkoutId).HasColumnName("workoutId");

            entity.HasOne(d => d.Program)
                .WithMany(p => p.ProgramWorkouts)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("programId");

            entity.HasOne(d => d.Workout)
                .WithMany(p => p.ProgramWorkouts)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workoutId");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.ToTable("Set");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.ExerciseId).HasColumnName("exerciseId");

            entity.Property(e => e.ExerciseRepetitions)
                .HasColumnName("exerciseRepetitions")
                .HasDefaultValueSql("1");

            entity.Property(e => e.WorkoutId).HasColumnName("workoutId");

            entity.Property(e => e.ExerciseSets).HasColumnName("exercisesets");

            entity.HasOne(d => d.Exercise)
                .WithMany(p => p.Sets)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exerciseId");

            entity.HasOne(d => d.Workout)
                .WithMany(p => p.Sets)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workoutId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("firstName");

            entity.Property(e => e.IsAdmin)
                .HasColumnName("isAdmin")
                .HasDefaultValueSql("false");

            entity.Property(e => e.IsContributor)
                .HasColumnName("isContributor")
                .HasDefaultValueSql("false");

            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("lastName");

            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.ToTable("Workout");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>().HasData(SeedHelper.GetUsers());
        modelBuilder.Entity<FitnessAttribute>().HasData(SeedHelper.GetFitnessAttributes());
        modelBuilder.Entity<Address>().HasData(SeedHelper.GetAddresses());
        modelBuilder.Entity<Domain.Program>().HasData(SeedHelper.GetPrograms());
        modelBuilder.Entity<Goal>().HasData(SeedHelper.GetGoals());
        modelBuilder.Entity<Profile>().HasData(SeedHelper.GetProfiles());
        modelBuilder.Entity<Exercise>().HasData(SeedHelper.GetExercises());
        modelBuilder.Entity<Workout>().HasData(SeedHelper.GetWorkouts());
        modelBuilder.Entity<Set>().HasData(SeedHelper.GetSets());
        modelBuilder.Entity<GoalWorkout>().HasData(SeedHelper.GetGoalWorkouts());
        modelBuilder.Entity<ProgramWorkout>().HasData(SeedHelper.GetProgramWorkouts());
    }
}