using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAbackend.Infra.Data.Migrations
{
	/// <inheritdoc />
	public partial class AddDomainEntities : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Creators",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Creators", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Affiliateds",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
					CreatorId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Affiliateds", x => x.Id);
					table.ForeignKey(
						name: "FK_Affiliateds_Creators_CreatorId",
						column: x => x.CreatorId,
						principalTable: "Creators",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Affiliateds_CreatorId",
				table: "Affiliateds",
				column: "CreatorId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Affiliateds");

			migrationBuilder.DropTable(
				name: "Creators");
		}
	}
}
