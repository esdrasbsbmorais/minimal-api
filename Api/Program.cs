using minimal_api;

IHostBuilder CreateHostBuilder(String[] args)
{
    return Host.CreateApplicationBuilder(args).ConfigurateWebHostDefaults(webBuilder => 
    {
        webBuilder.UseStartup<Startup>();
    });
}