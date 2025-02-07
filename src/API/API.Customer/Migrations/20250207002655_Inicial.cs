using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Customer.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<int>(type: "int", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<int>(type: "int", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmailLimit = table.Column<int>(type: "int", nullable: false),
                    SmsLimit = table.Column<int>(type: "int", nullable: false),
                    WhatsAppLimit = table.Column<int>(type: "int", nullable: false),
                    OverageCostPerEmail = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverageCostPerSms = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverageCostPerWhatsApp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<int>(type: "int", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<int>(type: "int", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<int>(type: "int", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<int>(type: "int", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseEntity_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountSubscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<int>(type: "int", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<int>(type: "int", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSubscription_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountSubscription_SubscriptionPlan_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalTable: "SubscriptionPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<int>(type: "int", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<int>(type: "int", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountProduct_AccountSubscription_AccountSubscriptionId",
                        column: x => x.AccountSubscriptionId,
                        principalTable: "AccountSubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageUsage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<int>(type: "int", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<int>(type: "int", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageUsage_AccountSubscription_AccountSubscriptionId",
                        column: x => x.AccountSubscriptionId,
                        principalTable: "AccountSubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageUsageItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageUsageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CostPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<int>(type: "int", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<int>(type: "int", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUsageItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageUsageItem_MessageUsage_MessageUsageId",
                        column: x => x.MessageUsageId,
                        principalTable: "MessageUsage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountProduct_AccountSubscriptionId",
                table: "AccountProduct",
                column: "AccountSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubscription_AccountId",
                table: "AccountSubscription",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubscription_SubscriptionPlanId",
                table: "AccountSubscription",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_AccountId",
                table: "BaseEntity",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUsage_AccountSubscriptionId",
                table: "MessageUsage",
                column: "AccountSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUsageItem_MessageUsageId",
                table: "MessageUsageItem",
                column: "MessageUsageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountProduct");

            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "MessageUsageItem");

            migrationBuilder.DropTable(
                name: "MessageUsage");

            migrationBuilder.DropTable(
                name: "AccountSubscription");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "SubscriptionPlan");
        }
    }
}
