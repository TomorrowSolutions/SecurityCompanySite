using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    public partial class fkfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_GuardedObjects_GuardedObjectId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "GuardedObjectId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GuardedObjectId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_GuardedObjects_GuardedObjectId",
                table: "Events",
                column: "GuardedObjectId",
                principalTable: "GuardedObjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails",
                column: "GuardedObjectId",
                principalTable: "GuardedObjects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_GuardedObjects_GuardedObjectId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GuardedObjectId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuardedObjectId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_GuardedObjects_GuardedObjectId",
                table: "Events",
                column: "GuardedObjectId",
                principalTable: "GuardedObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails",
                column: "GuardedObjectId",
                principalTable: "GuardedObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
