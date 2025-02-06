using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Person.Migrations
{
    /// <inheritdoc />
    public partial class Person_Data : Migration
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

            for (int i = 0; i < 10; i++)
            {
                var dtInsert = faker.Date.Past();
                var dtInsertId = faker.Random.Int(1, 1000);

                migrationBuilder.InsertData(
                    table: "Person",
                    columns: new[] { "Id", "CustomerId", "UserId", "Name", "Type", "Discriminator", "Status", "DtInsert", "DtInsertId" },
                    values: new object[] { guids[i], guids[i], guids[i], faker.Name.FullName(), "F", "PersonEntity", true, dtInsert, i }
                );

                migrationBuilder.InsertData(
                    table: "Document",
                    columns: new[] { "Id", "CustomerId", "UserId", "Type", "Number", "IssueDate", "IssuingAuthority", "Country", "PersonId", "Status", "DtInsert", "DtInsertId" },
                    values: new object[] { guids[i], guids[i], guids[i], "CPF", faker.Random.Replace("###.###.###-##"), DateTime.UtcNow.AddYears(-faker.Random.Int(18, 60)), "SSP", "BR", guids[i], true, dtInsert, i }
                );

                migrationBuilder.InsertData(
                    table: "Address",
                    columns: new[] { "Id", "CustomerId", "UserId", "Type", "Street", "Number", "Neighborhood", "City", "State", "ZipCode", "Country", "PersonId", "Status", "DtInsert", "DtInsertId" },
                    values: new object[] { guids[i], guids[i], guids[i], "Residencial", faker.Address.StreetName(), faker.Address.BuildingNumber(), faker.Address.City(), faker.Address.City(), faker.Address.StateAbbr(), faker.Address.ZipCode(), "BR", guids[i], true, dtInsert, i }
                );

                migrationBuilder.InsertData(
                    table: "Email",
                    columns: new[] { "Id", "CustomerId", "UserId", "Address", "Type", "PersonId", "Status", "DtInsert", "DtInsertId" },
                    values: new object[] { guids[i], guids[i], guids[i], faker.Internet.Email(), "Pessoal", guids[i], true, dtInsert, i }
                );

                migrationBuilder.InsertData(
                    table: "Phone",
                    columns: new[] { "Id", "CustomerId", "UserId", "Type", "AreaCode", "Number", "PersonId", "Status", "DtInsert", "DtInsertId" },
                    values: new object[] { guids[i], guids[i], guids[i], "Celular", faker.Random.Replace("##"), faker.Phone.PhoneNumber("9########"), guids[i], true, dtInsert, i }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
