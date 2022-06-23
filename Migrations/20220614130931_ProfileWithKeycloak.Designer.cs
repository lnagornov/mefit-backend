﻿// <auto-generated />
using System;
using MeFitCase_Assignment.Models;
using MeFitCase_Assignment.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeFitCase_Assignment.Migrations
{
    [DbContext(typeof(MeFitPostgreSqlContext))]
    [Migration("20220614130931_ProfileWithKeycloak")]
    partial class ProfileWithKeycloak
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeFitCase_Assignment.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("addressLine1");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("addressLine2");

                    b.Property<string>("AddressLine3")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("addressLine3");

                    b.Property<string>("City")
                        .HasMaxLength(58)
                        .HasColumnType("character varying(58)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("country");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("postalCode");

                    b.HasKey("Id");

                    b.ToTable("Address", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressLine1 = "Userstreet 1",
                            City = "Usertown",
                            Country = "Mefit",
                            PostalCode = "1234AB"
                        },
                        new
                        {
                            Id = 2,
                            AddressLine1 = "Contributorstreet 1",
                            City = "Contributortown",
                            Country = "Mefit",
                            PostalCode = "5678BC"
                        },
                        new
                        {
                            Id = 3,
                            AddressLine1 = "Adminstreet 1",
                            City = "Admintown",
                            Country = "Mefit",
                            PostalCode = "9012DE"
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("ImageLink")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("imageLink");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("TargetMuscleGroup")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("targetMuscleGroup");

                    b.Property<string>("VideoLink")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("videoLink");

                    b.HasKey("Id");

                    b.ToTable("Exercise", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Five to ten minute exercise, slowly worked up to 30 minutes in five minute intervals. Hold a brisk walking pace during exercise.",
                            ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/runner-feet-running-on-road-closeup-on-shoe-royalty-free-image-918789438-1553785419.jpg",
                            Name = "Walking",
                            TargetMuscleGroup = "Quadriceps, hamstrings, glutes, calves, ankles",
                            VideoLink = ""
                        },
                        new
                        {
                            Id = 2,
                            Description = "Keep feet shoulder-width apart and back straight. Bend knees and lowering your rear. Knees should remain over the ankle as much as possible. Go back up, repeat.",
                            ImageLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRw99LEqLhyvtXH5diLY3rxiiowdPgzZm1NQg&usqp=CAU",
                            Name = "Squats",
                            TargetMuscleGroup = "Quadriceps, hamstrings, glutes",
                            VideoLink = ""
                        },
                        new
                        {
                            Id = 3,
                            Description = "Take a big step forward, keeping the spine in a neutral position. Bend front knee to 90 degrees, focussing on keeping the weight on the back toes and dropping the knee of your back leg toward the floor. Return to neutral standing position, repeat with other leg.",
                            ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/gettyimages-1036780614.jpg",
                            Name = "Lunges",
                            TargetMuscleGroup = "Quadriceps, hamstrings, glutes, calves",
                            VideoLink = ""
                        },
                        new
                        {
                            Id = 4,
                            Description = "Form a face-down position place hands slightly wider thatn shoulder-width apart. Place toes or knees on the floor then lower and lift your body by bending and straightening the elbows, keeping torse stable. ",
                            ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/athlete-worming-up-in-sunlit-studio-royalty-free-image-1587991217.jpg",
                            Name = "Push-ups",
                            TargetMuscleGroup = "Chest, shoulders, triceps, core trunk",
                            VideoLink = ""
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lie on your back with feet flat on the floor. Press lower back down and contract adbominals and peel head, than neck, than shoulder and upper back off the floor. Lie down slowly and repeat.",
                            ImageLink = "https://cdn.mos.cms.futurecdn.net/uB2vFdbMwWHrETwUURyV5V.jpg",
                            Name = "Abdominal Crunches",
                            TargetMuscleGroup = "core trunk",
                            VideoLink = ""
                        },
                        new
                        {
                            Id = 6,
                            Description = "Stand with feet shoulder-width apart, then bend knees and flex forward at the hips. Tilt your pelvis slightly forward, engage the abdominals, and extend your upper spine to add support. Hold dumbbells or barbell beneath the shoulders with hands about shoulder-width apart. Flex your elbows, and lift both hands toward the sides of your body. Pause, then slowly lower hands to the starting position.",
                            ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/mature-male-weight-lifter-exercises-and-does-royalty-free-image-1650890468.jpg",
                            Name = "Bent-over Row",
                            TargetMuscleGroup = "All major muscles in the upper back. Biceps.",
                            VideoLink = ""
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.FitnessAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string[]>("Disabilities")
                        .HasColumnType("character varying[]")
                        .HasColumnName("disabilities");

                    b.Property<double?>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<string[]>("MedicalConditions")
                        .HasColumnType("character varying[]")
                        .HasColumnName("medicalConditions");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.ToTable("FitnessAttributes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Height = 180.34,
                            Weight = 75.530000000000001
                        },
                        new
                        {
                            Id = 2,
                            Height = 200.02000000000001,
                            Weight = 90.120000000000005
                        },
                        new
                        {
                            Id = 3,
                            Height = 170.59999999999999,
                            Weight = 210.68000000000001
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("endDate");

                    b.Property<bool?>("IsAchieved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("isAchieved")
                        .HasDefaultValueSql("false");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("integer")
                        .HasColumnName("programId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Goal", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateOnly(2022, 6, 24),
                            IsAchieved = false,
                            ProgramId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateOnly(2022, 6, 25),
                            IsAchieved = false,
                            ProgramId = 2
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateOnly(2022, 6, 27),
                            IsAchieved = false,
                            ProgramId = 3
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.GoalWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("endDate");

                    b.Property<int>("GoalId")
                        .HasColumnType("integer")
                        .HasColumnName("goalId");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer")
                        .HasColumnName("workoutId");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("GoalWorkout", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateOnly(2022, 6, 24),
                            GoalId = 1,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateOnly(2022, 6, 25),
                            GoalId = 2,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateOnly(2022, 6, 27),
                            GoalId = 3,
                            WorkoutId = 3
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer")
                        .HasColumnName("addressId");

                    b.Property<int?>("FitnessAttributesId")
                        .HasColumnType("integer")
                        .HasColumnName("fitnessAttributesId");

                    b.Property<int?>("GoalId")
                        .HasColumnType("integer")
                        .HasColumnName("goalId");

                    b.Property<string>("KeycloakId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("keycloakId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("FitnessAttributesId");

                    b.HasIndex("GoalId");

                    b.ToTable("Profile", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            FitnessAttributesId = 1,
                            GoalId = 1,
                            KeycloakId = "1"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            FitnessAttributesId = 2,
                            GoalId = 2,
                            KeycloakId = "2"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            FitnessAttributesId = 3,
                            GoalId = 3,
                            KeycloakId = "3"
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("category");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Program", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Basic",
                            Name = "Standard program for users"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Basic",
                            Name = "Standard program for contributors"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Basic",
                            Name = "Standard program for admins"
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.ProgramWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("ProgramId")
                        .HasColumnType("integer")
                        .HasColumnName("programId");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer")
                        .HasColumnName("workoutId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ProgramWorkout", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProgramId = 1,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProgramId = 2,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 3,
                            ProgramId = 3,
                            WorkoutId = 3
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer")
                        .HasColumnName("exerciseId");

                    b.Property<int?>("ExerciseRepetitions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("exerciseRepetitions")
                        .HasDefaultValueSql("1");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer")
                        .HasColumnName("workoutId");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Set", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            ExerciseRepetitions = 1,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 2,
                            ExerciseRepetitions = 20,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 3,
                            ExerciseRepetitions = 20,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 4,
                            ExerciseRepetitions = 15,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 5,
                            ExerciseId = 5,
                            ExerciseRepetitions = 15,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 6,
                            ExerciseId = 6,
                            ExerciseRepetitions = 10,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 7,
                            ExerciseId = 1,
                            ExerciseRepetitions = 3,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 8,
                            ExerciseId = 4,
                            ExerciseRepetitions = 30,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 9,
                            ExerciseId = 1,
                            ExerciseRepetitions = 1,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 10,
                            ExerciseId = 1,
                            ExerciseRepetitions = 1,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 11,
                            ExerciseId = 2,
                            ExerciseRepetitions = 20,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 12,
                            ExerciseId = 3,
                            ExerciseRepetitions = 20,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 13,
                            ExerciseId = 4,
                            ExerciseRepetitions = 15,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 14,
                            ExerciseId = 5,
                            ExerciseRepetitions = 15,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 15,
                            ExerciseId = 6,
                            ExerciseRepetitions = 10,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 16,
                            ExerciseId = 4,
                            ExerciseRepetitions = 30,
                            WorkoutId = 4
                        },
                        new
                        {
                            Id = 17,
                            ExerciseId = 5,
                            ExerciseRepetitions = 30,
                            WorkoutId = 4
                        },
                        new
                        {
                            Id = 18,
                            ExerciseId = 6,
                            ExerciseRepetitions = 15,
                            WorkoutId = 4
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("firstName");

                    b.Property<bool?>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("isAdmin")
                        .HasDefaultValueSql("false");

                    b.Property<bool?>("IsContributor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("isContributor")
                        .HasDefaultValueSql("false");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user@user.com",
                            FirstName = "user",
                            IsAdmin = false,
                            IsContributor = false,
                            LastName = "user",
                            Password = "user1234"
                        },
                        new
                        {
                            Id = 2,
                            Email = "contributor@contributor.com",
                            FirstName = "contributor",
                            IsAdmin = false,
                            IsContributor = true,
                            LastName = "contributor",
                            Password = "contributor1234"
                        },
                        new
                        {
                            Id = 3,
                            Email = "admin@admin.com",
                            FirstName = "admin",
                            IsAdmin = true,
                            IsContributor = true,
                            LastName = "admin",
                            Password = "admin1234"
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("isCompleted")
                        .HasDefaultValueSql("false");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Type")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Workout", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCompleted = false,
                            Name = "Full body workout",
                            Type = "Strength"
                        },
                        new
                        {
                            Id = 2,
                            IsCompleted = false,
                            Name = "Basic Burner",
                            Type = "Endurance"
                        },
                        new
                        {
                            Id = 3,
                            IsCompleted = false,
                            Name = "Legs and Core",
                            Type = "Strength"
                        },
                        new
                        {
                            Id = 4,
                            IsCompleted = false,
                            Name = "Skip Leg Week",
                            Type = "Strength"
                        });
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Goal", b =>
                {
                    b.HasOne("MeFitCase_Assignment.Models.Program", "Program")
                        .WithMany("Goals")
                        .HasForeignKey("ProgramId")
                        .HasConstraintName("programId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.GoalWorkout", b =>
                {
                    b.HasOne("MeFitCase_Assignment.Models.Goal", "Goal")
                        .WithMany("GoalWorkouts")
                        .HasForeignKey("GoalId")
                        .IsRequired()
                        .HasConstraintName("goalId");

                    b.HasOne("MeFitCase_Assignment.Models.Workout", "Workout")
                        .WithMany("GoalWorkouts")
                        .HasForeignKey("WorkoutId")
                        .IsRequired()
                        .HasConstraintName("workoutId");

                    b.Navigation("Goal");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Profile", b =>
                {
                    b.HasOne("MeFitCase_Assignment.Models.Address", "Address")
                        .WithMany("Profiles")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("addressId");

                    b.HasOne("MeFitCase_Assignment.Models.FitnessAttribute", "FitnessAttributes")
                        .WithMany("Profiles")
                        .HasForeignKey("FitnessAttributesId")
                        .HasConstraintName("fitnessAttributesId");

                    b.HasOne("MeFitCase_Assignment.Models.Goal", "Goal")
                        .WithMany("Profiles")
                        .HasForeignKey("GoalId")
                        .HasConstraintName("goalId");

                    b.Navigation("Address");

                    b.Navigation("FitnessAttributes");

                    b.Navigation("Goal");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.ProgramWorkout", b =>
                {
                    b.HasOne("MeFitCase_Assignment.Models.Program", "Program")
                        .WithMany("ProgramWorkouts")
                        .HasForeignKey("ProgramId")
                        .IsRequired()
                        .HasConstraintName("programId");

                    b.HasOne("MeFitCase_Assignment.Models.Workout", "Workout")
                        .WithMany("ProgramWorkouts")
                        .HasForeignKey("WorkoutId")
                        .IsRequired()
                        .HasConstraintName("workoutId");

                    b.Navigation("Program");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Set", b =>
                {
                    b.HasOne("MeFitCase_Assignment.Models.Exercise", "Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .IsRequired()
                        .HasConstraintName("exerciseId");

                    b.HasOne("MeFitCase_Assignment.Models.Workout", "Workout")
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutId")
                        .IsRequired()
                        .HasConstraintName("workoutId");

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Address", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Exercise", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.FitnessAttribute", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Goal", b =>
                {
                    b.Navigation("GoalWorkouts");

                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Program", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("ProgramWorkouts");
                });

            modelBuilder.Entity("MeFitCase_Assignment.Models.Workout", b =>
                {
                    b.Navigation("GoalWorkouts");

                    b.Navigation("ProgramWorkouts");

                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
