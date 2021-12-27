using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCSharp.InfraData.Migrations
{
    public partial class Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Birthdate = table.Column<string>(type: "varchar(48)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    ModifyDate = table.Column<string>(type: "varchar(48)", nullable: false),
                    Data = table.Column<string>(type: "varchar(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Job = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: false),
                    Salary = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    BeginDate = table.Column<string>(type: "varchar(48)", nullable: false),
                    EndDate = table.Column<string>(type: "varchar(48)", nullable: false),
                    ModifyDate = table.Column<string>(type: "varchar(48)", nullable: false),
                    IdCandidate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<string>(type: "varchar(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateExperience_Candidates_IdCandidate",
                        column: x => x.IdCandidate,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperience_IdCandidate",
                table: "CandidateExperience",
                column: "IdCandidate");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_Email",
                table: "Candidates",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateExperience");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
