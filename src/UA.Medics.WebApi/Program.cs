using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using UA.Medics.WebApi;

Host
	.CreateDefaultBuilder(args)
	.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
	.Build()
	.Run();