using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    public partial class orddetfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "GuardedObjectId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails",
                column: "GuardedObjectId",
                principalTable: "GuardedObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "GuardedObjectId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ObjectId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_GuardedObjects_GuardedObjectId",
                table: "OrderDetails",
                column: "GuardedObjectId",
                principalTable: "GuardedObjects",
                principalColumn: "Id");
        }
    }
}
