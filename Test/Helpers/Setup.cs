using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Helpers
{
    public class Setup
    {
        public const string PORT = "5001";
        public static TestContext testContext = default!;
        public static WebApplicationFactory<Startupp> http = default!;
        public static HttpClient client = default!;
        public static void ClassInit(TestContext context)
        {
            Setup.testContext = testContext;
            Setup.http = new WebApplicationFactory<Startupp>();

            Setup.http = Setup.http.WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");

                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<AdministradorServico, AdministradorServicoMock>();
                });
            });

            Setup.client = Setup.http.CreateClient();
        }

        public static void ClassCleanup()
        {
            Setup.http.Dispose();
        }
    }
}