using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Domain.Servico
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTest()
        {
            var assemblyPath = Path.GetDiretoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder().SetBasePath(path ?? Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(builder);
        }
        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            // Arrange
            var context = CriarContextoDeTest();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "teste@teste.com";
            adm.Senha = "123456";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            // Act
            administradorServico.Incluir(adm);

            // Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count());
        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            // Arrange
            var context = CriarContextoDeTest();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "teste@teste.com";
            adm.Senha = "123456";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            // Act
            administradorServico.Incluir(adm);
            var admDoBanco = administradorServico.BuscaPorId(adm.Id);

            // Assert
            Assert.AreEqual(1, admDoBanco.Id);
        }
    }
}