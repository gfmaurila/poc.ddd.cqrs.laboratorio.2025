using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Customer.Migrations
{
    /// <inheritdoc />
    public partial class Customer_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var faker = new Faker("pt_BR");
            Guid[] guids = new Guid[]
            {
                new Guid("02759B98-F969-48F7-AD53-C02AFD90C844"),
                new Guid("68888282-EC69-44FA-8303-DD460C117F44"),
                new Guid("F0ACECE8-6C6B-41FF-B523-2364AE602DCC"),
                new Guid("C49642D8-8ED4-4589-9D3A-A4DE441422C4"),
                new Guid("8B0FF838-6445-47DC-8D13-8EC4B22CF9F5"),
                new Guid("A1C5CF35-964D-4D48-944D-B198F3F3649B"),
                new Guid("7FC337F9-93C8-4473-A05B-67D32C66290C"),
                new Guid("A7C54242-CA68-4C0D-8522-F2643A3483D4"),
                new Guid("0126410F-90B2-4CD1-9A6F-FFBD898298FC"),
                new Guid("C523CF8F-9230-4FA1-9B2A-378D16FD0822")
            };

            for (int i = 0; i < guids.Length; i++)
            {
                var createdAt = faker.Date.Past();
                var dtInsertId = faker.Random.Int(1, 1000);

                // Inserir dados na tabela Account (adicionando Status)
                migrationBuilder.InsertData(
                    table: "Account",
                    columns: new[] { "Id", "Name", "Email", "PhoneNumber", "Status" },
                    values: new object[] { guids[i], $"Cliente {i + 1}", $"cliente{i + 1}@email.com", faker.Phone.PhoneNumber("11#########"), true }
                );

                // Inserir dados na tabela SubscriptionPlan
                migrationBuilder.InsertData(
                    table: "SubscriptionPlan",
                    columns: new[] { "Id", "Name", "MonthlyPrice", "EmailLimit", "SmsLimit", "WhatsAppLimit", "OverageCostPerEmail", "OverageCostPerSms", "OverageCostPerWhatsApp", "Status" },
                    values: new object[] { guids[i], $"Plano {i + 1}", 99.90m, 1000, 500, 200, 0.02m, 0.05m, 0.10m, true }
                );

                // Inserir dados na tabela AccountSubscription
                migrationBuilder.InsertData(
                    table: "AccountSubscription",
                    columns: new[] { "Id", "AccountId", "SubscriptionPlanId", "Status" },
                    values: new object[] { guids[i], guids[i], guids[i], true }
                );

                // Inserir dados na tabela AccountProduct
                migrationBuilder.InsertData(
                    table: "AccountProduct",
                    columns: new[] { "Id", "AccountSubscriptionId", "ProductName", "Status" },
                    values: new object[] { guids[i], guids[i], $"Produto {i + 1}", true }
                );

                // Inserir dados na tabela MessageUsage
                migrationBuilder.InsertData(
                    table: "MessageUsage",
                    columns: new[] { "Id", "AccountSubscriptionId", "Period", "Status" },
                    values: new object[] { guids[i], guids[i], faker.Date.Past(1) , true }
                );

                // Inserir dados na tabela MessageUsageItem
                migrationBuilder.InsertData(
                    table: "MessageUsageItem",
                    columns: new[] { "Id", "MessageUsageId", "MessageType", "Quantity", "CostPerUnit", "Status" },
                    values: new object[]
                    {
                        guids[i], guids[i], "Email", faker.Random.Int(100, 500), 0.02m, true
                    }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
