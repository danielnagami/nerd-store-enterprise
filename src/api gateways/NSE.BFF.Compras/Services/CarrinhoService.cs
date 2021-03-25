using Microsoft.Extensions.Options;
using NSE.BFF.Compras.Extensions;
using System;
using System.Net.Http;

namespace NSE.BFF.Compras.Services
{
    public interface ICarrinhoService { }
    public class CarrinhoService : ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }
    }
}