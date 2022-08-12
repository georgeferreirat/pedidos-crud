using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pedidos.Models;

namespace Pedidos.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly Context _context;

        public FornecedorController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedores.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> NovoFornecedor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoFornecedor(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _context.Fornecedores.AddAsync(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarFornecedor(int IdFornecedor)
        {
            Fornecedor fornecedor = await _context.Fornecedores.FindAsync(IdFornecedor);
            return View(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarFornecedor(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(fornecedor);
        }

        [HttpPost]
        public async Task<JsonResult> Excluir(int id)
        {
            Fornecedor fornecedor = await _context.Fornecedores.FindAsync(id);

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return Json(new { });
        }
    }
}
