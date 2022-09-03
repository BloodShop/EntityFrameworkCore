using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReverseEnginereeingEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(name: "Company Name", type: "TEXT", unicode: false, maxLength: 24, nullable: false),
                    Website = table.Column<string>(type: "TEXT", maxLength: 124, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Alpha2Code = table.Column<string>(name: "Alpha-2 Code", type: "TEXT", maxLength: 2, nullable: false),
                    Alpha3Code = table.Column<string>(name: "Alpha-3 Code", type: "TEXT", maxLength: 3, nullable: false),
                    Numeric = table.Column<string>(type: "TEXT", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Experience Levels",
                columns: table => new
                {
                    Level = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Experien__AAF899630983E740", x => x.Level);
                });

            migrationBuilder.CreateTable(
                name: "House types",
                columns: table => new
                {
                    TypeID = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__House ty__516F0395EF75E4DB", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(name: "First Name", type: "TEXT", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "TEXT", maxLength: 30, nullable: false),
                    CompanyID = table.Column<int>(type: "INTEGER", nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "TEXT", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK__People__CompanyI__35BCFE0A",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "SalesMen",
                columns: table => new
                {
                    SalesManID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyID = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(name: "First Name", type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "TEXT", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "TEXT", maxLength: 100, nullable: true),
                    HireDate = table.Column<DateTime>(name: "Hire Date", type: "datetime", nullable: false),
                    BirthDate = table.Column<DateTime>(name: "Birth Date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMen", x => x.SalesManID);
                    table.ForeignKey(
                        name: "FK__SalesMen__Compan__3A81B327",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK__Cities__CountryI__2B3F6F97",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SalesManID = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeID = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 20, nullable: false),
                    Level = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Speciali__6F0E227E4CD88706", x => new { x.SalesManID, x.TypeID });
                    table.ForeignKey(
                        name: "FK__Specializ__Level__440B1D61",
                        column: x => x.Level,
                        principalTable: "Experience Levels",
                        principalColumn: "Level");
                    table.ForeignKey(
                        name: "FK__Specializ__Sales__4222D4EF",
                        column: x => x.SalesManID,
                        principalTable: "SalesMen",
                        principalColumn: "SalesManID");
                    table.ForeignKey(
                        name: "FK__Specializ__TypeI__4316F928",
                        column: x => x.TypeID,
                        principalTable: "House types",
                        principalColumn: "TypeID");
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    NeighborhoodID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.NeighborhoodID);
                    table.ForeignKey(
                        name: "FK__Neighborh__CityI__2E1BDC42",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    BuiltAt = table.Column<DateTime>(name: "Built At", type: "datetime", nullable: true),
                    SizeM2 = table.Column<int>(name: "Size (M^2)", type: "INTEGER", nullable: false),
                    Rooms = table.Column<int>(type: "INTEGER", nullable: false),
                    WantedPrice = table.Column<decimal>(name: "Wanted Price", type: "money", nullable: false),
                    ForSale = table.Column<bool>(name: "For Sale", type: "INTEGER", nullable: false),
                    OwnerID = table.Column<int>(type: "INTEGER", nullable: true),
                    TypeID = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 20, nullable: false),
                    NeighborhoodID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseID);
                    table.ForeignKey(
                        name: "FK__Houses__Neighbor__4CA06362",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhoods",
                        principalColumn: "NeighborhoodID");
                    table.ForeignKey(
                        name: "FK__Houses__OwnerID__4AB81AF0",
                        column: x => x.OwnerID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK__Houses__TypeID__4BAC3F29",
                        column: x => x.TypeID,
                        principalTable: "House types",
                        principalColumn: "TypeID");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HouseID = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyerID = table.Column<int>(type: "INTEGER", nullable: true),
                    SellerID = table.Column<int>(type: "INTEGER", nullable: false),
                    SalesManID = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalPrice = table.Column<decimal>(name: "Final Price", type: "money", nullable: true),
                    Income = table.Column<float>(type: "REAL", nullable: false, defaultValueSql: "((0.05))"),
                    Saledate = table.Column<DateTime>(name: "Sale date", type: "datetime", nullable: true),
                    PublishDate = table.Column<DateTime>(name: "Publish Date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK__Sales__BuyerID__5165187F",
                        column: x => x.BuyerID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK__Sales__HouseID__5070F446",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "HouseID");
                    table.ForeignKey(
                        name: "FK__Sales__SalesManI__5441852A",
                        column: x => x.SalesManID,
                        principalTable: "SalesMen",
                        principalColumn: "SalesManID");
                    table.ForeignKey(
                        name: "FK__Sales__SellerID__52593CB8",
                        column: x => x.SellerID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UQ__Countrie__E056F201DD0CDF79",
                table: "Countries",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Countrie__FD07398E83A4904D",
                table: "Countries",
                column: "Numeric",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_NeighborhoodID",
                table: "Houses",
                column: "NeighborhoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerID",
                table: "Houses",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_TypeID",
                table: "Houses",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_CityId",
                table: "Neighborhoods",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CompanyID",
                table: "People",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "UQ__People__79578B9366CF0684",
                table: "People",
                column: "Phone Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerID",
                table: "Sales",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_HouseID",
                table: "Sales",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesManID",
                table: "Sales",
                column: "SalesManID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SellerID",
                table: "Sales",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Sales__1EE3C41E0DBBEAF7",
                table: "Sales",
                column: "SaleID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesMen_CompanyID",
                table: "SalesMen",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "UQ__SalesMen__79578B93B9FBA71A",
                table: "SalesMen",
                column: "Phone Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_Level",
                table: "Specialization",
                column: "Level");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_TypeID",
                table: "Specialization",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Experience Levels");

            migrationBuilder.DropTable(
                name: "SalesMen");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "House types");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
