using Microsoft.Extensions.Options;
using NSE.BFF.Compras.Extensions;
using System;
using System.Net.Http;

namespace NSE.BFF.Compras.Services
{
    public interface ICatalogoService { }
    public class CatalogoService : ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }
    }
}