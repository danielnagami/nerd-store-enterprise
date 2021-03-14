using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebAPI.Core.Usuario;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using Polly;
using System;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddHttpClient<ICatalogoService, CatalogoService>()
                    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                    .AddPolicyHandler(PollyExtensions.EsperarTentar())
                    .AddTransientHttpErrorPolicy
                    (
                        p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30))
                    );

            #region Refit
            //services.AddHttpClient("Refit", options =>
            //        {
            //            options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);
            //        })
            //        .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //        .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>); 
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
        }
    }
}