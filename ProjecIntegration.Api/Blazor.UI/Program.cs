using Blazor.UI;
using Blazor.UI.data.services.authorization;
using Blazor.UI.extensionMethods;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor.UI.data.services.Policies;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//custom middle ware to integrate jwt token
builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
//inject in all htpcclient my jwt token in my header allowing my request to be validated in my
//api side 
builder.Services.AddHttpClient("projectAPI",client => //you need to register your api  base url here
                 client.BaseAddress = new Uri("https://localhost:44337/api"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>()
    .SetHandlerLifetime(TimeSpan.FromMinutes(2))  //retry policies
        .AddPolicyHandler(Policices.GetRetryPolicy()); ;

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>()
                                        .CreateClient("projectAPI"));
//dependency injection with all my middleware 
//a service to controle them all
builder.Services.AddLocalStorageServices();
builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazor(builder.Configuration);
builder.Services.AddWMBSC();
//----------------------------------------------------
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
await builder.Build().RunAsync();
