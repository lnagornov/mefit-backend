using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeFitCase_Assignment.Migrations
{
    public partial class goalworkoutcompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Workout");

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "GoalWorkout",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "GoalWorkout",
                keyColumn: "id",
                keyValue: 1,
                column: "isCompleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "GoalWorkout",
                keyColumn: "id",
                keyValue: 2,
                column: "isCompleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "GoalWorkout",
                keyColumn: "id",
                keyValue: 3,
                column: "isCompleted",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "GoalWorkout");

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Workout",
                type: "boolean",
                nullable: true,
                defaultValueSql: "false");

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "id",
                keyValue: 1,
                column: "isCompleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "id",
                keyValue: 2,
                column: "isCompleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "id",
                keyValue: 3,
                column: "isCompleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "id",
                keyValue: 4,
                column: "isCompleted",
                value: false);
        }
    }
}
