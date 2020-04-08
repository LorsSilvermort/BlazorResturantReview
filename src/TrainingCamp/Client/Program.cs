using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TrainingCamp.Client.SessionState;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace TrainingCamp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<AddState>();
            builder.Services.AddScoped<PresentationState>();
            builder.RootComponents.Add<App>("app");
            await builder.Build().UseLocalTimeZone().RunAsync();
        }
       
    }
}
