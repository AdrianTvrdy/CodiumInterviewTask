using Codium.Interview.EmployeeEvidenceApp.Client.Repositories;
using Codium.Interview.EmployeeEvidenceApp.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Codium.Interview.EmployeeEvidenceApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IPositionRepository, PositionRepository>();
            builder.Services.AddScoped<IPositionService, PositionService>();
            builder.Services.AddScoped<ErrorService>();


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7201") });

            await builder.Build().RunAsync();
        }
    }
}
