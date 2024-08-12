using Locacoes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locacoes.Controllers
{
    public class FabricanteController : Controller
    {
        public static List<Fabricante> Fabricantes = new List<Fabricante>
        {
            new Fabricante { Id = 1, Nome = "Fiat", Pais = "Itália" },
            new Fabricante { Id = 2, Nome = "Volkswagen", Pais = "Alemanha" },
            new Fabricante { Id = 3, Nome = "Ford", Pais = "Estados Unidos" },
        };
        public IActionResult Index()
        {
            return View(Fabricantes);
        }
    }
}
