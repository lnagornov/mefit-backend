using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Models.Context;

public static class SeedHelper
{
    public static IEnumerable<User> GetUsers()
    {
        return new List<User>
        {
            new ()
            {
                Id = 1,
                Email = "user@user.com",
                Password = "user1234",
                FirstName = "user",
                LastName = "user",
                IsContributor = false,
                IsAdmin = false
            },

            new ()
            {
                Id = 2,
                Email = "contributor@contributor.com",
                Password = "contributor1234",
                FirstName = "contributor",
                LastName = "contributor",
                IsContributor = true,
                IsAdmin = false
            },

            new ()
            {
                Id = 3,
                Email = "admin@admin.com",
                Password = "admin1234",
                FirstName = "admin",
                LastName = "admin",
                IsContributor = true,
                IsAdmin = true
            },
        };
    }

    public static IEnumerable<FitnessAttribute> GetFitnessAttributes()
    {
        return new List<FitnessAttribute>
        {
            new()
            {
                Id = 1,
                Weight = 75.53,
                Height = 180.34,
                MedicalConditions = null,
                Disabilities = null
            },
                
            new()
            {
                Id = 2,
                Weight = 90.12,
                Height = 200.02,
                MedicalConditions = null,
                Disabilities = null
            },
                
            new()
            {
                Id = 3,
                Weight = 210.68,
                Height = 170.60,
                MedicalConditions = null,
                Disabilities = null
            },
        };
    }

    public static IEnumerable<Address> GetAddresses()
    {
        return new List<Address>
        {
            new()
            {
                Id = 1,
                AddressLine1 = "Userstreet 1",
                PostalCode = "1234AB",
                City = "Usertown",
                Country = "Mefit"
            },
                
            new()
            {
                Id = 2,
                AddressLine1 = "Contributorstreet 1",
                PostalCode = "5678BC",
                City = "Contributortown",
                Country = "Mefit"
            },
                
            new()
            {
                Id = 3,
                AddressLine1 = "Adminstreet 1",
                PostalCode = "9012DE",
                City = "Admintown",
                Country = "Mefit"
            },
        };
    }

    public static IEnumerable<Domain.Program> GetPrograms()
    {
        return new List<Domain.Program>
        {
            new()
            {
                Id=1,
                Name = "Standard program for users",
                Category = "Basic",
                Description = ""
            },
                
            new()
            {
                Id=2,
                Name = "Standard program for contributors",
                Category = "Basic",
                Description = ""
            },
                
            new()
            {
                Id=3,
                Name = "Standard program for admins",
                Category = "Basic",
                Description = ""
            },
        };
    }

    public static IEnumerable<Goal> GetGoals()
    {
        return new List<Goal>
        {
            new()
            {
                Id = 1,
                EndDate = new DateOnly(2022, 06, 24),
                IsAchieved = false,
                ProgramId = 1,
            },
                
            new()
            {
                Id = 2,
                EndDate = new DateOnly(2022, 06, 25),
                IsAchieved = false,
                ProgramId = 2,
            },
                
            new()
            {
                Id = 3,
                EndDate = new DateOnly(2022, 06, 27),
                IsAchieved = false,
                ProgramId = 3,
            },
        };
    }

    public static IEnumerable<Profile> GetProfiles()
    {
        return new List<Profile>
        {
            // USER
            new()
            {
                Id = 1,
                KeycloakId = "0f4f6b10-cad2-42ef-ab71-af7d6d585bfc",
                GoalId = 1,
                AddressId = 1,
                FitnessAttributesId = 1
            },
                
            // CONTRIBUTOR
            new()
            {
                Id = 2,
                KeycloakId = "69ea1b81-7b8c-4ce6-9bf8-aadd21de35f7",
                GoalId = 2,
                AddressId = 2,
                FitnessAttributesId = 2
            },
                
            // ADMIN
            new()
            {
                Id = 3,
                KeycloakId = "9ca3732b-e4b0-4344-b444-8f6762a7be1b",
                GoalId = 3,
                AddressId = 3,
                FitnessAttributesId = 3
            },
        };
    }

    public static IEnumerable<Exercise> GetExercises()
    {
        return new List<Exercise>
        {
            new()
            {
                Id = 1,
                Name = "Walking",
                Description = "Five to ten minute exercise, slowly worked up to 30 minutes in five minute intervals. Hold a brisk walking pace during exercise.",
                TargetMuscleGroup = "Quadriceps, hamstrings, glutes, calves, ankles",
                ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/runner-feet-running-on-road-closeup-on-shoe-royalty-free-image-918789438-1553785419.jpg",
                VideoLink = ""
            },

            new()
            {
                Id = 2,
                Name = "Squats",
                Description = "Keep feet shoulder-width apart and back straight. Bend knees and lowering your rear. Knees should remain over the ankle as much as possible. Go back up, repeat.",
                TargetMuscleGroup = "Quadriceps, hamstrings, glutes",
                ImageLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRw99LEqLhyvtXH5diLY3rxiiowdPgzZm1NQg&usqp=CAU",
                VideoLink = ""
            },

            new()
            {
                Id = 3,
                Name = "Lunges",
                Description = "Take a big step forward, keeping the spine in a neutral position. Bend front knee to 90 degrees, focussing on keeping the weight on the back toes and dropping the knee of your back leg toward the floor. Return to neutral standing position, repeat with other leg.",
                TargetMuscleGroup = "Quadriceps, hamstrings, glutes, calves",
                ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/gettyimages-1036780614.jpg",
                VideoLink = ""
            },

            new()
            {
                Id = 4,
                Name = "Push-ups",
                Description = "Form a face-down position place hands slightly wider thatn shoulder-width apart. Place toes or knees on the floor then lower and lift your body by bending and straightening the elbows, keeping torse stable. ",
                TargetMuscleGroup = "Chest, shoulders, triceps, core trunk",
                ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/athlete-worming-up-in-sunlit-studio-royalty-free-image-1587991217.jpg",
                VideoLink = ""
            },

            new()
            {
                Id = 5,
                Name = "Abdominal Crunches",
                Description = "Lie on your back with feet flat on the floor. Press lower back down and contract adbominals and peel head, than neck, than shoulder and upper back off the floor. Lie down slowly and repeat.",
                TargetMuscleGroup = "core trunk",
                ImageLink = "https://cdn.mos.cms.futurecdn.net/uB2vFdbMwWHrETwUURyV5V.jpg",
                VideoLink = ""
            },

            new()
            {
                Id = 6,
                Name = "Bent-over Row",
                Description = "Stand with feet shoulder-width apart, then bend knees and flex forward at the hips. Tilt your pelvis slightly forward, engage the abdominals, and extend your upper spine to add support. Hold dumbbells or barbell beneath the shoulders with hands about shoulder-width apart. Flex your elbows, and lift both hands toward the sides of your body. Pause, then slowly lower hands to the starting position.",
                TargetMuscleGroup = "All major muscles in the upper back. Biceps.",
                ImageLink = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/mature-male-weight-lifter-exercises-and-does-royalty-free-image-1650890468.jpg",
                VideoLink = ""
            }
        };
    }

    public static IEnumerable<Workout> GetWorkouts()
    {
        return new List<Workout>
        {
            new()
            {
                Id = 1,
                Name = "Full body workout",
                Type = "Strength",
                    
            },

            new()
            {
                Id = 2,
                Name = "Basic Burner",
                Type = "Endurance",
            },

            new()
            {
                Id = 3,
                Name = "Legs and Core",
                Type = "Strength",
            },

            new()
            {
                Id = 4,
                Name = "Skip Leg Week",
                Type = "Strength",
            },
        };
    }

    public static IEnumerable<Set> GetSets()
    {
        return new List<Set>
        {
            new()
            {
                Id = 1,
                WorkoutId = 1,
                ExerciseId = 1,
                ExerciseRepetitions = 1
            },

            new()
            {
                Id = 2,
                WorkoutId = 1,
                ExerciseId = 2,
                ExerciseRepetitions = 20
            },

            new()
            {
                Id = 3,
                WorkoutId = 1,
                ExerciseId = 3,
                ExerciseRepetitions = 20
            },

            new()
            {
                Id = 4,
                WorkoutId = 1,
                ExerciseId = 4,
                ExerciseRepetitions = 15
            },

            new()
            {
                Id = 5,
                WorkoutId = 1,
                ExerciseId = 5,
                ExerciseRepetitions = 15
            },

            new()
            {
                Id = 6,
                WorkoutId = 1,
                ExerciseId = 6,
                ExerciseRepetitions = 10
            },

            new()
            {
                Id = 7,
                WorkoutId = 2,
                ExerciseId = 1,
                ExerciseRepetitions = 3
            },

            new()
            {
                Id = 8,
                WorkoutId = 2,
                ExerciseId = 4,
                ExerciseRepetitions = 30
            },
                
            new()
            {
                Id = 9,
                WorkoutId = 3,
                ExerciseId = 1,
                ExerciseRepetitions = 1
            },

            new()
            {
                Id = 10,
                WorkoutId = 3,
                ExerciseId = 1,
                ExerciseRepetitions = 1
            },

            new()
            {
                Id = 11,
                WorkoutId = 3,
                ExerciseId = 2,
                ExerciseRepetitions = 20
            },

            new()
            {
                Id = 12,
                WorkoutId = 3,
                ExerciseId = 3,
                ExerciseRepetitions = 20
            },

            new()
            {
                Id = 13,
                WorkoutId = 3,
                ExerciseId = 4,
                ExerciseRepetitions = 15
            },

            new()
            {
                Id = 14,
                WorkoutId = 3,
                ExerciseId = 5,
                ExerciseRepetitions = 15
            },

            new()
            {
                Id = 15,
                WorkoutId = 3,
                ExerciseId = 6,
                ExerciseRepetitions = 10
            },

            new()
            {
                Id = 16,
                WorkoutId = 4,
                ExerciseId = 4,
                ExerciseRepetitions = 30
            },

            new()
            {
                Id = 17,
                WorkoutId = 4,
                ExerciseId = 5,
                ExerciseRepetitions = 30
            },

            new()
            {
                Id = 18,
                WorkoutId = 4,
                ExerciseId = 6,
                ExerciseRepetitions = 15
            },

        };
    }

    public static IEnumerable<GoalWorkout> GetGoalWorkouts()
    {
        return new List<GoalWorkout>
        {
            new()
            {
                Id = 1,
                EndDate = new DateOnly(2022, 06, 24),
                IsCompleted = false,
                GoalId  = 1,
                WorkoutId = 1,
            },

            new()
            {
                Id = 2,
                EndDate = new DateOnly(2022, 06, 25),
                IsCompleted = false,
                GoalId  = 2,
                WorkoutId = 2,
            },
                
            new()
            {
                Id = 3,
                EndDate = new DateOnly(2022, 06, 27),
                IsCompleted = false,
                GoalId  = 3,
                WorkoutId = 3,
            },
        };
    }

    public static IEnumerable<ProgramWorkout> GetProgramWorkouts()
    {
        return new List<ProgramWorkout>
        {
            new()
            {
                Id = 1,
                ProgramId = 1,
                WorkoutId = 1
            },

            new()
            {
                Id = 2,
                ProgramId = 2,
                WorkoutId = 2
            },
                
            new()
            {
                Id = 3,
                ProgramId = 3,
                WorkoutId = 3
            },
        };
    }
}