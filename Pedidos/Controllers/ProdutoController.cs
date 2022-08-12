using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Models;

namespace Pedidos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Context _context;

        public ProdutoController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> NovoProduto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DtCadastro = DateTime.Now;
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarProduto(int IdProduto)
        {
            Produto produto = await _context.Produtos.FindAsync(IdProduto);
            produto.DtCadastro = DateTime.Now;
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        [HttpPost]
        public async Task<JsonResult> Excluir(int id)
        {
            Produto produto = await _context.Produtos.FindAsync(id);

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Json(new { });
        }
    }
}
