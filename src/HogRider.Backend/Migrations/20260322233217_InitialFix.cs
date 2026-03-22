using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogRider.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_client_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_restaurant_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_client_id",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_account_id",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_OrderMenuItems_order_id",
                table: "OrderMenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemDietaryTags_menu_item_id",
                table: "MenuItemDietaryTags");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemCategories_menu_item_id",
                table: "MenuItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_Clients_account_id",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_ClientItemInteractions_client_id",
                table: "ClientItemInteractions");

            migrationBuilder.DropIndex(
                name: "IX_ClientFavourites_client_id",
                table: "ClientFavourites");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Text",
                keyValue: null,
                column: "Text",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reviews",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "phone_number",
                keyValue: null,
                column: "phone_number",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "Restaurants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "RestaurantLogoImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "RestaurantLogoImages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "RestaurantLogoImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Orders",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "OrderMenuItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "OrderMenuItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "price_at_order",
                table: "OrderMenuItems",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "OrderMenuItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "MenuItemImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "MenuItemImages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "MenuItemImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "Clients",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "last_name",
                keyValue: null,
                column: "last_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "Clients",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "first_name",
                keyValue: null,
                column: "first_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "Clients",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "ClientRecommendations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "ClientRecommendations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "ClientItemInteractions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "interaction",
                table: "ClientItemInteractions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "ClientItemInteractions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "postal_code",
                table: "Address",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "account_type",
                table: "Accounts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Accounts",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_client_id_restaurant_id_order_id",
                table: "Reviews",
                columns: new[] { "client_id", "restaurant_id", "order_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_account_id",
                table: "Restaurants",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_order_id_menu_item_id",
                table: "OrderMenuItems",
                columns: new[] { "order_id", "menu_item_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemDietaryTags_menu_item_id_dietary_tag_id",
                table: "MenuItemDietaryTags",
                columns: new[] { "menu_item_id", "dietary_tag_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCategories_menu_item_id_category_id",
                table: "MenuItemCategories",
                columns: new[] { "menu_item_id", "category_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_account_id",
                table: "Clients",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_phone_number",
                table: "Clients",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientItemInteractions_client_id_menu_item_id",
                table: "ClientItemInteractions",
                columns: new[] { "client_id", "menu_item_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientFavourites_client_id_menu_item_id",
                table: "ClientFavourites",
                columns: new[] { "client_id", "menu_item_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Country_City_Street_postal_code",
                table: "Address",
                columns: new[] { "Country", "City", "Street", "postal_code" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_client_id",
                table: "Orders",
                column: "client_id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_restaurant_id",
                table: "Orders",
                column: "restaurant_id",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_client_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_restaurant_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_client_id_restaurant_id_order_id",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_account_id",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_OrderMenuItems_order_id_menu_item_id",
                table: "OrderMenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemDietaryTags_menu_item_id_dietary_tag_id",
                table: "MenuItemDietaryTags");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemCategories_menu_item_id_category_id",
                table: "MenuItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_Clients_account_id",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_phone_number",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_ClientItemInteractions_client_id_menu_item_id",
                table: "ClientItemInteractions");

            migrationBuilder.DropIndex(
                name: "IX_ClientFavourites_client_id_menu_item_id",
                table: "ClientFavourites");

            migrationBuilder.DropIndex(
                name: "IX_Address_Country_City_Street_postal_code",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Email",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Username",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "RestaurantLogoImages");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "RestaurantLogoImages");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "RestaurantLogoImages");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderMenuItems");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "OrderMenuItems");

            migrationBuilder.DropColumn(
                name: "price_at_order",
                table: "OrderMenuItems");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "OrderMenuItems");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "MenuItemImages");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "MenuItemImages");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "MenuItemImages");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "ClientRecommendations");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "ClientRecommendations");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "ClientItemInteractions");

            migrationBuilder.DropColumn(
                name: "interaction",
                table: "ClientItemInteractions");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "ClientItemInteractions");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "Restaurants",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "Clients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "Clients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "Clients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "postal_code",
                table: "Address",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "account_type",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Accounts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_client_id",
                table: "Reviews",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_account_id",
                table: "Restaurants",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_order_id",
                table: "OrderMenuItems",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemDietaryTags_menu_item_id",
                table: "MenuItemDietaryTags",
                column: "menu_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCategories_menu_item_id",
                table: "MenuItemCategories",
                column: "menu_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_account_id",
                table: "Clients",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientItemInteractions_client_id",
                table: "ClientItemInteractions",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFavourites_client_id",
                table: "ClientFavourites",
                column: "client_id");

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
        }
    }
}
