using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    [Route("Catalogo")]
    public class CatalogoController : MainController
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet]
        [Route("")]
        [Route("Vitrine")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _catalogoService.ObterTodos();

            return View(produtos);
        }

        [HttpGet]
        [Route("Produto-Detalhe/{id}")]
        public async Task<IActionResult> Index(Guid id)
        {
            var produto = await _catalogoService.ObterPorId(id);

            return View(produto);
        }
    }
}
