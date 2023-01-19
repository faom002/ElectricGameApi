using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricGamesApiV1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConsoleName = table.Column<string>(type: "TEXT", nullable: false),
                    ConsolePrice = table.Column<int>(type: "INTEGER", nullable: false),
                    ConsoleImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameName = table.Column<string>(type: "TEXT", nullable: false),
                    GameGenre = table.Column<string>(type: "TEXT", nullable: false),
                    GamePlatform = table.Column<string>(type: "TEXT", nullable: false),
                    GamePrice = table.Column<int>(type: "INTEGER", nullable: false),
                    GameReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    GameImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterName = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterGame = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterAge = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizMultipleChoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    AnswerOne = table.Column<string>(type: "TEXT", nullable: false),
                    AnswerTwo = table.Column<string>(type: "TEXT", nullable: false),
                    AnswerThree = table.Column<string>(type: "TEXT", nullable: false),
                    AnswerFour = table.Column<string>(type: "TEXT", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizMultipleChoice", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameCharacters");

            migrationBuilder.DropTable(
                name: "QuizMultipleChoice");
        }
    }
}
