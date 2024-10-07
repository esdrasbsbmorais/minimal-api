using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Requests
{
    [TestClass]
    public class AdministradorRequestTest
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Setup.ClassInit(testContext);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Setup.ClassCleanup();
        }

        [TestMethod]
        public async Task TestarGetSetPropriedades()
        {
            // Arrange
            var loginDTO = new LoginDTO{
                Email = "adm@teste.com",
                Senha = "123456"
            };

            var context = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");

            // Act
            var response = await Setup.client.PostAsync("/administrador/login", content);

            Assert.IsNotNull(admLogado?.Email ?? "");
            Assert.IsNotNull(admLogado?.Perfil ?? "");
            Assert.IsNotNull(admLogado?.Token ?? "");

            // Assert
            Assert.AreEqual(HttpStatusCode.Ok, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        }
    }
}