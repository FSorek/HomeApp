using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWebApp;
using BookRecommendations.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Services;
using MediatR;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddMediatR(typeof(GetAllBooksRequest));
builder.Services.AddMediatR(typeof(GetBookDetailsRequest));

#if DEBUG
builder.Services.AddScoped<IBookRepository, FakeBookRepository>();
builder.Services.AddScoped<IGoogleBooksClient, FakeGoogleBooksClient>();
#else
builder.Services.AddScoped<IGoogleBooksClient, GoogleBooksClient>();
builder.Services.AddScoped<IBookRepository, MyBookRepository>();
#endif
await builder.Build().RunAsync();