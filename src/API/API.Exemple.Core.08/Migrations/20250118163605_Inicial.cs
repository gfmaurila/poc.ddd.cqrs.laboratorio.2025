using Bogus;
using Common.Core._08.Domain.Enumerado;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Exemple.Core._08.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exemple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Notification = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", unicode: false, maxLength: 254, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInsertId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DtUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtUpdateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DtDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtDeleteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemple", x => x.Id);
                });


            var faker = new Faker();

            // Obtemos todos os valores do enum ERole como uma lista
            var roles = Enum.GetValues(typeof(ERole))
                            .Cast<ERole>() // Converte para IEnumerable<ERole>
                            .OrderBy(_ => faker.Random.Double()) // Randomiza a ordem
                            .Take(2) // Seleciona 2 valores aleatórios
                            .Select(role => role.ToString()) // Converte para string
                            .ToArray();


            // Lista para armazenar os dados gerados
            var mockData = new List<object>();

            for (int i = 0; i < 100; i++)
            {
                mockData.Add(new
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Gender = faker.PickRandom<EGender>(), // Enum EGender
                    Notification = faker.PickRandom<ENotificationType>().ToString(), // Enum ENotificationType
                    Email = faker.Internet.Email(),
                    Phone = faker.Phone.PhoneNumber("+1##########"),
                    Role = string.Join(",", roles), // Combina múltiplas permissões em uma string,
                    DtInsert = DateTime.Now,
                    DtInsertId = Guid.NewGuid(),
                    Status = true
                });
            }

            // Inserção dos dados no banco de dados
            foreach (var data in mockData)
            {
                migrationBuilder.InsertData(
                    table: "Exemple",
                    columns: new[] { "Id", "FirstName", "LastName", "Gender", "Notification", "Email", "Phone", "Role", "DtInsert", "DtInsertId", "Status" },
                    values: new object[]
                    {
                        ((dynamic)data).Id,
                        ((dynamic)data).FirstName,
                        ((dynamic)data).LastName,
                        ((dynamic)data).Gender.ToString(),
                        ((dynamic)data).Notification,
                        ((dynamic)data).Email,
                        ((dynamic)data).Phone,
                        ((dynamic)data).Role,
                        ((dynamic)data).DtInsert,
                        ((dynamic)data).DtInsertId,
                        ((dynamic)data).Status
                    }
                );
            }

            migrationBuilder.Sql("UPDATE [API_Exemple].[dbo].[Exemple] SET Role = '[\"ADMIN_AUTH\", \"EMPLOYEE_AUTH\"]' ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemple");
        }
    }
}
