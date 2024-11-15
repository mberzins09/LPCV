using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LPCVMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Addreses_AddressId",
                table: "CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_CVs_PersonalData_PersonalDataId",
                table: "CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_CVs_CvId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_CVs_CvId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_CvId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_CvId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_CVs_AddressId",
                table: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_CVs_PersonalDataId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "PersonalDataId",
                table: "CVs");

            migrationBuilder.AlterColumn<int>(
                name: "CvId",
                table: "WorkExperiences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CvId",
                table: "PersonalData",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CvId",
                table: "Educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CvId",
                table: "Addreses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_CvId",
                table: "WorkExperiences",
                column: "CvId",
                unique: true,
                filter: "[CvId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_CvId",
                table: "PersonalData",
                column: "CvId",
                unique: true,
                filter: "[CvId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CvId",
                table: "Educations",
                column: "CvId",
                unique: true,
                filter: "[CvId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addreses_CvId",
                table: "Addreses",
                column: "CvId",
                unique: true,
                filter: "[CvId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addreses_CVs_CvId",
                table: "Addreses",
                column: "CvId",
                principalTable: "CVs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_CVs_CvId",
                table: "Educations",
                column: "CvId",
                principalTable: "CVs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_CVs_CvId",
                table: "PersonalData",
                column: "CvId",
                principalTable: "CVs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_CVs_CvId",
                table: "WorkExperiences",
                column: "CvId",
                principalTable: "CVs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addreses_CVs_CvId",
                table: "Addreses");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_CVs_CvId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_CVs_CvId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_CVs_CvId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_CvId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_PersonalData_CvId",
                table: "PersonalData");

            migrationBuilder.DropIndex(
                name: "IX_Educations_CvId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Addreses_CvId",
                table: "Addreses");

            migrationBuilder.DropColumn(
                name: "CvId",
                table: "PersonalData");

            migrationBuilder.DropColumn(
                name: "CvId",
                table: "Addreses");

            migrationBuilder.AlterColumn<int>(
                name: "CvId",
                table: "WorkExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CvId",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDataId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_CvId",
                table: "WorkExperiences",
                column: "CvId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CvId",
                table: "Educations",
                column: "CvId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CVs_AddressId",
                table: "CVs",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_PersonalDataId",
                table: "CVs",
                column: "PersonalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Addreses_AddressId",
                table: "CVs",
                column: "AddressId",
                principalTable: "Addreses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_PersonalData_PersonalDataId",
                table: "CVs",
                column: "PersonalDataId",
                principalTable: "PersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_CVs_CvId",
                table: "Educations",
                column: "CvId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_CVs_CvId",
                table: "WorkExperiences",
                column: "CvId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
