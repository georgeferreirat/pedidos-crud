using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pedidos.Models;

namespace Pedidos.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Context _context;

        public PedidoController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedidos.Include(p => p.Fornecedor).Include(p => p.Produto).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> NovoPedido()
        {
            ViewData["ProdutoIdProduto"] = new SelectList(await _context.Produtos.ToListAsync(), "IdProduto", "Descricao");

            ViewData["FornecedorIdFornecedor"] = new SelectList(await _context.Fornecedores.ToListAsync(), "IdFornecedor", "RazaoSocial");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoPedido(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                Produto produto = await _context.Produtos.FindAsync(pedido.ProdutoIdProduto);
                pedido.ValorTotal = produto.Valor * pedido.QtdeProdutos;
                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProdutoIdProduto"] = new SelectList(await _context.Produtos.ToListAsync(), "IdProduto", "Descricao", pedido.ProdutoIdProduto);
            ViewData["FornecedorIdFornecedor"] = new SelectList(await _context.Fornecedores.ToListAsync(), "IdFornecedor", "RazaoSocial", pedido.FornecedorIdFornecedor);
            return View(pedido);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarPedido(int IdPedido)
        {
            Pedido pedido = await _context.Pedidos.FindAsync(IdPedido);

            ViewData["ProdutoIdProduto"] = new SelectList(await _context.Produtos.ToListAsync(), "IdProduto", "Descricao", pedido.ProdutoIdProduto);

            ViewData["FornecedorIdFornecedor"] = new SelectList(await _context.Fornecedores.ToListAsync(), "IdFornecedor", "RazaoSocial", pedido.FornecedorIdFornecedor);

            return View(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarPedido(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                Produto produto = await _context.Produtos.FindAsync(pedido.ProdutoIdProduto);
                pedido.ValorTotal = produto.Valor * pedido.QtdeProdutos;
                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProdutoIdProduto"] = new SelectList(await _context.Produtos.ToListAsync(), "IdProduto", "Descricao", pedido.ProdutoIdProduto);
            ViewData["FornecedorIdFornecedor"] = new SelectList(await _context.Fornecedores.ToListAsync(), "IdFornecedor", "RazaoSocial", pedido.FornecedorIdFornecedor);
            return View(pedido);
        }

        [HttpPost]
        public async Task<JsonResult> Excluir(int id)
        {
            Pedido pedido = await _context.Pedidos.FindAsync(id);

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return Json(new { });
        }
    }
}
