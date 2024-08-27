using Locacoes.Data;
using Locacoes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locacoes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly LocacoesContext _context;

        public ClienteController(LocacoesContext context)
        {
            _context = context;
        }


        //public static List<Cliente> Clientes = new List<Cliente>
        //{
        //    new Cliente { Id = 1, Nome = "João", Email = "johnfon@gmail.com", 
        //        Telefone = "(14)999999999", Cidade = "São Paulo" },

        //    new Cliente { Id = 2, Nome = "Maria", Email = "maria@gmail.com", 
        //        Telefone = "(21)888888888", Cidade = "Rio de Janeiro" },
        //};

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.OrderBy(cli => cli.Nome).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(cliente);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente =  await._context.Clientes.SingleOrDefaultAsync(cli => cli.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {

            if (id != cliente.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException) 
                {
                    if (!ModelState.IsValid)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("Index");
            }
            return View(cliente);

        }

        //        public IActionResult Details(int id)
        //        {
        //            return View(Clientes.Where(cli => cli.Id == id).First());
        //        }
        //        public IActionResult Delete(int id)
        //        {
        //            return View(Clientes.Where(cli => cli.Id == id).First());
        //        }
        //        public IActionResult DeleteConfirmed(int id)
        //        {
        //            var cliente = Clientes.Where(cli => cli.Id == id).First();
        //            Clientes.Remove(cliente);
        //            return RedirectToAction("Index");
        //        }
    }
}
