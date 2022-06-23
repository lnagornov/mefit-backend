using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeFitCase_Assignment.Migrations
{
    public partial class ProfileWithKeycloak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    addressLine1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    addressLine2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    addressLine3 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    postalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "character varying(58)", maxLength: 58, nullable: true),
                    country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    targetMuscleGroup = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    imageLink = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    videoLink = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessAttributes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    weight = table.Column<double>(type: "double precision", nullable: true),
                    height = table.Column<double>(type: "double precision", nullable: true),
                    medicalConditions = table.Column<string[]>(type: "character varying[]", nullable: true),
                    disabilities = table.Column<string[]>(type: "character varying[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessAttributes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    category = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    firstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    lastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    isContributor = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    isAdmin = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    isCompleted = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    endDate = table.Column<DateOnly>(type: "date", nullable: true),
                    isAchieved = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    programId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.id);
                    table.ForeignKey(
                        name: "programId",
                        column: x => x.programId,
                        principalTable: "Program",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramWorkout",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    programId = table.Column<int>(type: "integer", nullable: false),
                    workoutId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramWorkout", x => x.id);
                    table.ForeignKey(
                        name: "programId",
                        column: x => x.programId,
                        principalTable: "Program",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "workoutId",
                        column: x => x.workoutId,
                        principalTable: "Workout",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Set",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    exerciseRepetitions = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    exerciseId = table.Column<int>(type: "integer", nullable: false),
                    workoutId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Set", x => x.id);
                    table.ForeignKey(
                        name: "exerciseId",
                        column: x => x.exerciseId,
                        principalTable: "Exercise",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "workoutId",
                        column: x => x.workoutId,
                        principalTable: "Workout",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GoalWorkout",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    endDate = table.Column<DateOnly>(type: "date", nullable: true),
                    goalId = table.Column<int>(type: "integer", nullable: false),
                    workoutId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalWorkout", x => x.id);
                    table.ForeignKey(
                        name: "goalId",
                        column: x => x.goalId,
                        principalTable: "Goal",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "workoutId",
                        column: x => x.workoutId,
                        principalTable: "Workout",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    keycloakId = table.Column<string>(type: "text", nullable: false),
                    goalId = table.Column<int>(type: "integer", nullable: true),
                    addressId = table.Column<int>(type: "integer", nullable: true),
                    fitnessAttributesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.id);
                    table.ForeignKey(
                        name: "addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fitnessAttributesId",
                        column: x => x.fitnessAttributesId,
                        principalTable: "FitnessAttributes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "goalId",
                        column: x => x.goalId,
                        principalTable: "Goal",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "id", "addressLine1", "addressLine2", "addressLine3", "city", "country", "postalCode" },
                values: new object[,]
                {
                    { 1, "Userstreet 1", null, null, "Usertown", "Mefit", "1234AB" },
                    { 2, "Contributorstreet 1", null, null, "Contributortown", "Mefit", "5678BC" },
                    { 3, "Adminstreet 1", null, null, "Admintown", "Mefit", "9012DE" }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "id", "description", "imageLink", "name", "targetMuscleGroup", "videoLink" },
                values: new object[,]
                {
                    { 1, "Five to ten minute exercise, slowly worked up to 30 minutes in five minute intervals. Hold a brisk walking pace during exercise.", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/runner-feet-running-on-road-closeup-on-shoe-royalty-free-image-918789438-1553785419.jpg", "Walking", "Quadriceps, hamstrings, glutes, calves, ankles", "" },
                    { 2, "Keep feet shoulder-width apart and back straight. Bend knees and lowering your rear. Knees should remain over the ankle as much as possible. Go back up, repeat.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRw99LEqLhyvtXH5diLY3rxiiowdPgzZm1NQg&usqp=CAU", "Squats", "Quadriceps, hamstrings, glutes", "" },
                    { 3, "Take a big step forward, keeping the spine in a neutral position. Bend front knee to 90 degrees, focussing on keeping the weight on the back toes and dropping the knee of your back leg toward the floor. Return to neutral standing position, repeat with other leg.", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/gettyimages-1036780614.jpg", "Lunges", "Quadriceps, hamstrings, glutes, calves", "" },
                    { 4, "Form a face-down position place hands slightly wider thatn shoulder-width apart. Place toes or knees on the floor then lower and lift your body by bending and straightening the elbows, keeping torse stable. ", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/athlete-worming-up-in-sunlit-studio-royalty-free-image-1587991217.jpg", "Push-ups", "Chest, shoulders, triceps, core trunk", "" },
                    { 5, "Lie on your back with feet flat on the floor. Press lower back down and contract adbominals and peel head, than neck, than shoulder and upper back off the floor. Lie down slowly and repeat.", "https://cdn.mos.cms.futurecdn.net/uB2vFdbMwWHrETwUURyV5V.jpg", "Abdominal Crunches", "core trunk", "" },
                    { 6, "Stand with feet shoulder-width apart, then bend knees and flex forward at the hips. Tilt your pelvis slightly forward, engage the abdominals, and extend your upper spine to add support. Hold dumbbells or barbell beneath the shoulders with hands about shoulder-width apart. Flex your elbows, and lift both hands toward the sides of your body. Pause, then slowly lower hands to the starting position.", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/mature-male-weight-lifter-exercises-and-does-royalty-free-image-1650890468.jpg", "Bent-over Row", "All major muscles in the upper back. Biceps.", "" }
                });

            migrationBuilder.InsertData(
                table: "FitnessAttributes",
                columns: new[] { "id", "disabilities", "height", "medicalConditions", "weight" },
                values: new object[,]
                {
                    { 1, null, 180.34, null, 75.530000000000001 },
                    { 2, null, 200.02000000000001, null, 90.120000000000005 },
                    { 3, null, 170.59999999999999, null, 210.68000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "id", "category", "name" },
                values: new object[,]
                {
                    { 1, "Basic", "Standard program for users" },
                    { 2, "Basic", "Standard program for contributors" },
                    { 3, "Basic", "Standard program for admins" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "email", "firstName", "isAdmin", "isContributor", "lastName", "password" },
                values: new object[,]
                {
                    { 1, "user@user.com", "user", false, false, "user", "user1234" },
                    { 2, "contributor@contributor.com", "contributor", false, true, "contributor", "contributor1234" },
                    { 3, "admin@admin.com", "admin", true, true, "admin", "admin1234" }
                });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "id", "isCompleted", "name", "type" },
                values: new object[,]
                {
                    { 1, false, "Full body workout", "Strength" },
                    { 2, false, "Basic Burner", "Endurance" },
                    { 3, false, "Legs and Core", "Strength" },
                    { 4, false, "Skip Leg Week", "Strength" }
                });

            migrationBuilder.InsertData(
                table: "Goal",
                columns: new[] { "id", "endDate", "isAchieved", "programId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 6, 24), false, 1 },
                    { 2, new DateOnly(2022, 6, 25), false, 2 },
                    { 3, new DateOnly(2022, 6, 27), false, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProgramWorkout",
                columns: new[] { "id", "programId", "workoutId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Set",
                columns: new[] { "id", "exerciseId", "exerciseRepetitions", "workoutId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 20, 1 },
                    { 3, 3, 20, 1 },
                    { 4, 4, 15, 1 },
                    { 5, 5, 15, 1 },
                    { 6, 6, 10, 1 },
                    { 7, 1, 3, 2 },
                    { 8, 4, 30, 2 },
                    { 9, 1, 1, 3 },
                    { 10, 1, 1, 3 },
                    { 11, 2, 20, 3 },
                    { 12, 3, 20, 3 },
                    { 13, 4, 15, 3 },
                    { 14, 5, 15, 3 },
                    { 15, 6, 10, 3 },
                    { 16, 4, 30, 4 },
                    { 17, 5, 30, 4 },
                    { 18, 6, 15, 4 }
                });

            migrationBuilder.InsertData(
                table: "GoalWorkout",
                columns: new[] { "id", "endDate", "goalId", "workoutId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 6, 24), 1, 1 },
                    { 2, new DateOnly(2022, 6, 25), 2, 2 },
                    { 3, new DateOnly(2022, 6, 27), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "id", "addressId", "fitnessAttributesId", "goalId", "keycloakId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "1" },
                    { 2, 2, 2, 2, "2" },
                    { 3, 3, 3, 3, "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goal_programId",
                table: "Goal",
                column: "programId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalWorkout_goalId",
                table: "GoalWorkout",
                column: "goalId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalWorkout_workoutId",
                table: "GoalWorkout",
                column: "workoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_addressId",
                table: "Profile",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_fitnessAttributesId",
                table: "Profile",
                column: "fitnessAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_goalId",
                table: "Profile",
                column: "goalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramWorkout_programId",
                table: "ProgramWorkout",
                column: "programId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramWorkout_workoutId",
                table: "ProgramWorkout",
                column: "workoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Set_exerciseId",
                table: "Set",
                column: "exerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Set_workoutId",
                table: "Set",
                column: "workoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalWorkout");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "ProgramWorkout");

            migrationBuilder.DropTable(
                name: "Set");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "FitnessAttributes");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "Program");
        }
    }
}
