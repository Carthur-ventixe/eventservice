using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Changedtablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventPackageEntity_Events_EventId",
                table: "EventPackageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPackageEntity_PackageEntity_PackageId",
                table: "EventPackageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageEntity",
                table: "PackageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventPackageEntity",
                table: "EventPackageEntity");

            migrationBuilder.RenameTable(
                name: "PackageEntity",
                newName: "Packages");

            migrationBuilder.RenameTable(
                name: "EventPackageEntity",
                newName: "EventPackages");

            migrationBuilder.RenameIndex(
                name: "IX_EventPackageEntity_PackageId",
                table: "EventPackages",
                newName: "IX_EventPackages_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_EventPackageEntity_EventId",
                table: "EventPackages",
                newName: "IX_EventPackages_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventPackages",
                table: "EventPackages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPackages_Events_EventId",
                table: "EventPackages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPackages_Packages_PackageId",
                table: "EventPackages",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventPackages_Events_EventId",
                table: "EventPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPackages_Packages_PackageId",
                table: "EventPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventPackages",
                table: "EventPackages");

            migrationBuilder.RenameTable(
                name: "Packages",
                newName: "PackageEntity");

            migrationBuilder.RenameTable(
                name: "EventPackages",
                newName: "EventPackageEntity");

            migrationBuilder.RenameIndex(
                name: "IX_EventPackages_PackageId",
                table: "EventPackageEntity",
                newName: "IX_EventPackageEntity_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_EventPackages_EventId",
                table: "EventPackageEntity",
                newName: "IX_EventPackageEntity_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageEntity",
                table: "PackageEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventPackageEntity",
                table: "EventPackageEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPackageEntity_Events_EventId",
                table: "EventPackageEntity",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPackageEntity_PackageEntity_PackageId",
                table: "EventPackageEntity",
                column: "PackageId",
                principalTable: "PackageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
