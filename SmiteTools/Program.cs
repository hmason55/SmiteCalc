using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SmiteTools;
using SmiteTools.Models;
using System.Net.Http.Json;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        await Globals.Initialize(builder.HostEnvironment.BaseAddress);

        builder.Services.AddMudServices();
        builder.Services.AddScoped(sp => Globals.Client);

        await builder.Build().RunAsync();
    }
}