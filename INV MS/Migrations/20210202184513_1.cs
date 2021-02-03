using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INV_MS.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "tblAccountHead",
                columns: table => new
                {
                    accountHeadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountHeadName = table.Column<string>(nullable: false),
                    account_Head_Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccountHead", x => x.accountHeadId);
                });

            migrationBuilder.CreateTable(
                name: "tblCompany",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyrCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompany", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "tblItemcategory",
                columns: table => new
                {
                    catId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catName = table.Column<string>(nullable: false),
                    catDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblItemcategory", x => x.catId);
                });

            migrationBuilder.CreateTable(
                name: "tblItemUnit",
                columns: table => new
                {
                    unitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblItemUnit", x => x.unitId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAccount",
                columns: table => new
                {
                    accountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountHeadId = table.Column<int>(nullable: false),
                    accountCode = table.Column<int>(nullable: false),
                    accountTitle = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccount", x => x.accountId);
                    table.ForeignKey(
                        name: "FK_tblAccount_tblAccountHead_accountHeadId",
                        column: x => x.accountHeadId,
                        principalTable: "tblAccountHead",
                        principalColumn: "accountHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblItem",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    ItemCode = table.Column<string>(nullable: false),
                    itemName = table.Column<string>(nullable: false),
                    purchase_Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    sale_Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblItem", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_tblItem_tblItemUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "tblItemUnit",
                        principalColumn: "unitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblItem_tblItemcategory_catId",
                        column: x => x.catId,
                        principalTable: "tblItemcategory",
                        principalColumn: "catId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblInvoice",
                columns: table => new
                {
                    invoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_Code = table.Column<string>(nullable: false),
                    Invoice_type = table.Column<int>(nullable: false),
                    payment_Mode = table.Column<int>(nullable: false),
                    invoice_Date = table.Column<DateTime>(nullable: false),
                    Due_Date = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<int>(nullable: false),
                    accountId = table.Column<int>(nullable: false),
                    customerName = table.Column<int>(nullable: false),
                    Created_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInvoice", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_tblInvoice_tblCompany_CompanyName",
                        column: x => x.CompanyName,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblInvoice_tblAccount_accountId",
                        column: x => x.accountId,
                        principalTable: "tblAccount",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblInvoice_Customer_customerName",
                        column: x => x.customerName,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblInvoiceDetail",
                columns: table => new
                {
                    invoiceDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInvoiceDetail", x => x.invoiceDetailId);
                    table.ForeignKey(
                        name: "FK_tblInvoiceDetail_tblInvoice_invoiceId",
                        column: x => x.invoiceId,
                        principalTable: "tblInvoice",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblInvoiceDetail_tblItem_itemId",
                        column: x => x.itemId,
                        principalTable: "tblItem",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblVoucher",
                columns: table => new
                {
                    voucherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voucherCode = table.Column<string>(nullable: false),
                    voucherDate = table.Column<DateTime>(nullable: false),
                    invoiceId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    voucher_Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVoucher", x => x.voucherId);
                    table.ForeignKey(
                        name: "FK_tblVoucher_tblInvoice_invoiceId",
                        column: x => x.invoiceId,
                        principalTable: "tblInvoice",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblVoucherDetail",
                columns: table => new
                {
                    voucherdetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voucherId = table.Column<int>(nullable: false),
                    Narration = table.Column<string>(nullable: true),
                    debitAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    creditAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVoucherDetail", x => x.voucherdetailId);
                    table.ForeignKey(
                        name: "FK_tblVoucherDetail_tblVoucher_voucherId",
                        column: x => x.voucherId,
                        principalTable: "tblVoucher",
                        principalColumn: "voucherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccount_accountHeadId",
                table: "tblAccount",
                column: "accountHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_CompanyName",
                table: "tblInvoice",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_accountId",
                table: "tblInvoice",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoice_customerName",
                table: "tblInvoice",
                column: "customerName");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoiceDetail_invoiceId",
                table: "tblInvoiceDetail",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoiceDetail_itemId",
                table: "tblInvoiceDetail",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_tblItem_UnitId",
                table: "tblItem",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_tblItem_catId",
                table: "tblItem",
                column: "catId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVoucher_invoiceId",
                table: "tblVoucher",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVoucherDetail_voucherId",
                table: "tblVoucherDetail",
                column: "voucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tblInvoiceDetail");

            migrationBuilder.DropTable(
                name: "tblVoucherDetail");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblItem");

            migrationBuilder.DropTable(
                name: "tblVoucher");

            migrationBuilder.DropTable(
                name: "tblItemUnit");

            migrationBuilder.DropTable(
                name: "tblItemcategory");

            migrationBuilder.DropTable(
                name: "tblInvoice");

            migrationBuilder.DropTable(
                name: "tblCompany");

            migrationBuilder.DropTable(
                name: "tblAccount");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "tblAccountHead");
        }
    }
}
