﻿using Blazor.Fluxor;
using BlazorApp.Services;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp
{
    public class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddSingleton<IMovieService, ImdbService>();
                services.AddSingleton<IForecastService, ForecastService>();
                services.AddFluxor(options => options
                    .UseDependencyInjection(typeof(Program).Assembly)
                    .AddMiddleware<Blazor.Fluxor.ReduxDevTools.ReduxDevToolsMiddleware>()
                    .AddMiddleware<Blazor.Fluxor.Routing.RoutingMiddleware>()
                );
                services.AddSingleton<DownloadManager>();
                services.AddStorage();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }

#endregion Methods
    }
}
