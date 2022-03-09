using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.DataAccess.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdressType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryNumber = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccessFailedCount = table.Column<byte>(type: "tinyint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeskCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desk_Company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAdress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    PasswordQuestion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordAnswer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_City_IdCity",
                        column: x => x.IdCity,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountRate = table.Column<double>(type: "float", nullable: false),
                    IdDesk = table.Column<int>(type: "int", nullable: true),
                    IdPaymentMethod = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Desk_IdDesk",
                        column: x => x.IdDesk,
                        principalTable: "Desk",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bill_PaymentMethod_IdPaymentMethod",
                        column: x => x.IdPaymentMethod,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bill_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCompany_C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: true),
                    IdRole = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany_C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompany_C_Company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCompany_C_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCompany_C_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    IdPackageIngredient = table.Column<int>(type: "int", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: true),
                    IdCategory = table.Column<int>(type: "int", nullable: true),
                    IdSubCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Package_Company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Package_SubCategory_IdSubCategory",
                        column: x => x.IdSubCategory,
                        principalTable: "SubCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: true),
                    IdCategory = table.Column<int>(type: "int", nullable: true),
                    IdSubCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_SubCategory_IdSubCategory",
                        column: x => x.IdSubCategory,
                        principalTable: "SubCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adressline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adress_State_IdState",
                        column: x => x.IdState,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTaker = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBill = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Bill_IdBill",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuPackageProduct_C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdMenu = table.Column<int>(type: "int", nullable: true),
                    IdPackage = table.Column<int>(type: "int", nullable: true),
                    IdProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPackageProduct_C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPackageProduct_C_Menu_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuPackageProduct_C_Package_IdPackage",
                        column: x => x.IdPackage,
                        principalTable: "Package",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuPackageProduct_C_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageProduct_C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Piece = table.Column<byte>(type: "tinyint", nullable: false),
                    IdPackage = table.Column<int>(type: "int", nullable: true),
                    IdProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct_C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageProduct_C_Package_IdPackage",
                        column: x => x.IdPackage,
                        principalTable: "Package",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PackageProduct_C_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Adress_C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: true),
                    IdAdress = table.Column<int>(type: "int", nullable: true),
                    IdAdressType = table.Column<int>(type: "int", nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress_C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adress_C_Adress_IdAdress",
                        column: x => x.IdAdress,
                        principalTable: "Adress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adress_C_AdressType_IdAdress",
                        column: x => x.IdAdress,
                        principalTable: "AdressType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adress_C_Company_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adress_C_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderPackageProduct_C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: true),
                    IdMenuPackageProduct_C = table.Column<int>(type: "int", nullable: true),
                    MenuPackageProduct_CId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPackageProduct_C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPackageProduct_C_MenuPackageProduct_C_MenuPackageProduct_CId",
                        column: x => x.MenuPackageProduct_CId,
                        principalTable: "MenuPackageProduct_C",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderPackageProduct_C_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adress_IdState",
                table: "Adress",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_C_IdAdress",
                table: "Adress_C",
                column: "IdAdress");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_C_IdCompany",
                table: "Adress_C",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_C_IdPerson",
                table: "Adress_C",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdDesk",
                table: "Bill",
                column: "IdDesk");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdPaymentMethod",
                table: "Bill",
                column: "IdPaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdUser",
                table: "Bill",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Category_IdCompany",
                table: "Category",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_City_IdCountry",
                table: "City",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdPerson",
                table: "Customer",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Desk_IdCompany",
                table: "Desk",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IdCompany",
                table: "Menu",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPackageProduct_C_IdMenu",
                table: "MenuPackageProduct_C",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPackageProduct_C_IdPackage",
                table: "MenuPackageProduct_C",
                column: "IdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPackageProduct_C_IdProduct",
                table: "MenuPackageProduct_C",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdBill",
                table: "Order",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPackageProduct_C_IdOrder",
                table: "OrderPackageProduct_C",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPackageProduct_C_MenuPackageProduct_CId",
                table: "OrderPackageProduct_C",
                column: "MenuPackageProduct_CId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_IdCategory",
                table: "Package",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Package_IdCompany",
                table: "Package",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Package_IdSubCategory",
                table: "Package",
                column: "IdSubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_C_IdPackage",
                table: "PackageProduct_C",
                column: "IdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_C_IdProduct",
                table: "PackageProduct_C",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCategory",
                table: "Product",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCompany",
                table: "Product",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdSubCategory",
                table: "Product",
                column: "IdSubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_State_IdCity",
                table: "State",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_IdCategory",
                table: "SubCategory",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdPerson",
                table: "User",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_C_IdCompany",
                table: "UserCompany_C",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_C_IdRole",
                table: "UserCompany_C",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_C_IdUser",
                table: "UserCompany_C",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adress_C");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderPackageProduct_C");

            migrationBuilder.DropTable(
                name: "PackageProduct_C");

            migrationBuilder.DropTable(
                name: "UserCompany_C");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "AdressType");

            migrationBuilder.DropTable(
                name: "MenuPackageProduct_C");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
