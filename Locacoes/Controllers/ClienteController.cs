using Locacoes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locacoes.Controllers
{
    public class ClienteController : Controller
    {
        public static List<Cliente> Clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "João", Email = "johnfon@gmail.com", 
                Telefone = "(14)999999999", Cidade = "São Paulo" },

            new Cliente { Id = 2, Nome = "Maria", Email = "maria@gmail.com", 
                Telefone = "(21)888888888", Cidade = "Rio de Janeiro" },
        };
        public IActionResult Index()
        {
            return View(Clientes);
        }
    }
}
