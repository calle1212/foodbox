using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class updateRewievSchema_step2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewOnCreatorId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewOnFulfillerId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    FulfillerId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_FulfillerId",
                        column: x => x.FulfillerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ReviewOnCreatorId",
                table: "Posts",
                column: "ReviewOnCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ReviewOnFulfillerId",
                table: "Posts",
                column: "ReviewOnFulfillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CreatorId",
                table: "Reviews",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FulfillerId",
                table: "Reviews",
                column: "FulfillerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Reviews_ReviewOnCreatorId",
                table: "Posts",
                column: "ReviewOnCreatorId",
                principalTable: "Reviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Reviews_ReviewOnFulfillerId",
                table: "Posts",
                column: "ReviewOnFulfillerId",
                principalTable: "Reviews",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Reviews_ReviewOnCreatorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Reviews_ReviewOnFulfillerId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ReviewOnCreatorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ReviewOnFulfillerId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ReviewOnCreatorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ReviewOnFulfillerId",
                table: "Posts");
        }
    }
}
