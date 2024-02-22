using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guild.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RealName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    GuildRole = table.Column<string>(type: "text", nullable: true),
                    JoinGuildDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JoinGuildInvestments = table.Column<long>(type: "bigint", nullable: false),
                    CurrentInvestments = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_Id",
                table: "Players",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
