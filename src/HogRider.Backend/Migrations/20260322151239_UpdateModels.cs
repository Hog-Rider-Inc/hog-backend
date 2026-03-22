using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogRider.Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemCategories_DietaryTags_DietaryTagId",
                table: "MenuItemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_MenuItems_MenuItemId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MenuItemId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemCategories_DietaryTagId",
                table: "MenuItemCategories");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DietaryTagId",
                table: "MenuItemCategories");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Restaurants",
                newName: "address_id");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Orders",
                newName: "restaurant_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                newName: "IX_Orders_restaurant_id");

            migrationBuilder.AlterColumn<int>(
                name: "restaurant_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "client_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "total_price",
                table: "Orders",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "account_id",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Clients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "Clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "Clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "Clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Clients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_account_id",
                table: "Restaurants",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_address_id",
                table: "Restaurants",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_address_id",
                table: "Orders",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_client_id",
                table: "Orders",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_account_id",
                table: "Clients",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_address_id",
                table: "Clients",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Accounts_account_id",
                table: "Clients",
                column: "account_id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Address_address_id",
                table: "Clients",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_address_id",
                table: "Orders",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_client_id",
                table: "Orders",
                column: "client_id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_restaurant_id",
                table: "Orders",
                column: "restaurant_id",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Accounts_account_id",
                table: "Restaurants",
                column: "account_id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Address_address_id",
                table: "Restaurants",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Accounts_account_id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Address_address_id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_address_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_client_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_restaurant_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Accounts_account_id",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Address_address_id",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_account_id",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_address_id",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Orders_address_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_client_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Clients_account_id",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_address_id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "client_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "total_price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "account_id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "address_id",
                table: "Restaurants",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "restaurant_id",
                table: "Orders",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_restaurant_id",
                table: "Orders",
                newName: "IX_Orders_RestaurantId");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DietaryTagId",
                table: "MenuItemCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MenuItemId",
                table: "Reviews",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCategories_DietaryTagId",
                table: "MenuItemCategories",
                column: "DietaryTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemCategories_DietaryTags_DietaryTagId",
                table: "MenuItemCategories",
                column: "DietaryTagId",
                principalTable: "DietaryTags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_MenuItems_MenuItemId",
                table: "Reviews",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id");
        }
    }
}
