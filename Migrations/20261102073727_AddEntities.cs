using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactBook.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactTags_Contacts_ContactId",
                table: "ContactTags");

            migrationBuilder.DropTable(
                name: "ContactNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactTags",
                table: "ContactTags");

            migrationBuilder.DropIndex(
                name: "IX_ContactTags_ContactId",
                table: "ContactTags");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "ContactTags");

            migrationBuilder.RenameTable(
                name: "ContactTags",
                newName: "ContacTags");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContacTags",
                newName: "TagId");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "ContacTags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "ContacTags",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContacTags",
                table: "ContacTags",
                columns: new[] { "ContactId", "TagId" });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContacTags_TagId",
                table: "ContacTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ContactId",
                table: "Notes",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContacTags_Contacts_ContactId",
                table: "ContacTags",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContacTags_Tags_TagId",
                table: "ContacTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContacTags_Contacts_ContactId",
                table: "ContacTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ContacTags_Tags_TagId",
                table: "ContacTags");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContacTags",
                table: "ContacTags");

            migrationBuilder.DropIndex(
                name: "IX_ContacTags_TagId",
                table: "ContacTags");

            migrationBuilder.RenameTable(
                name: "ContacTags",
                newName: "ContactTags");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "ContactTags",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "ContactTags",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ContactTags",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "ContactTags",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactTags",
                table: "ContactTags",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContactNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNotes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactTags_ContactId",
                table: "ContactTags",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNotes_ContactId",
                table: "ContactNotes",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactTags_Contacts_ContactId",
                table: "ContactTags",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
