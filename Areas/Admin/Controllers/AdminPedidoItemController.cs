using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaisSabor2.Context;
using MaisSabor2.Models;
using MaisSabor2.Migrations;

namespace MaisSabor2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPedidoItemController : Controller
    {
        private readonly AppDbContext _context;

        public AdminPedidoItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminPedidoItem
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PedidoItens.Include(p => p.Item).Include(p => p.Pedido);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/AdminPedidoItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PedidoItens == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItens
                .Include(p => p.Item)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.PedidoItemId == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // GET: Admin/AdminPedidoItem/Create
        public IActionResult Create(int PedidoId)
        {
            ViewData["ItemId"] = new SelectList(_context.Itens, "ItemId", "Nome");
            ViewData["PedidoId"] = PedidoId;
            return View();
        }

        // POST: Admin/AdminPedidoItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoItemId,PedidoId,ItemId,Quantidade,Preco")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                double PrecoItem = _context.Itens.FirstOrDefault(m => m.ItemId == pedidoItem.ItemId).Preco;
                pedidoItem.Preco = Convert.ToDecimal(PrecoItem);
                _context.Add(pedidoItem);
                await _context.SaveChangesAsync();
                UpdatePedido(pedidoItem.PedidoId);
                return RedirectToAction("PedidoItens", "AdminPedido", new { id = pedidoItem.PedidoId });
            }
            ViewData["ItemId"] = new SelectList(_context.Itens, "ItemId", "Cor", pedidoItem.ItemId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "Cep", pedidoItem.PedidoId);
            return View(pedidoItem);
        }

        // GET: Admin/AdminPedidoItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PedidoItens == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItens.FindAsync(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Itens, "ItemId", "Nome", pedidoItem.ItemId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", pedidoItem.PedidoId);
            return View(pedidoItem);
        }

        // POST: Admin/AdminPedidoItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoItemId,PedidoId,ItemId,Quantidade,Preco")] PedidoItem pedidoItem)
        {
            if (id != pedidoItem.PedidoItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    double PrecoItem = _context.Itens.FirstOrDefault(m => m.ItemId == pedidoItem.ItemId).Preco;
                    pedidoItem.Preco = Convert.ToDecimal(PrecoItem);
                    _context.Update(pedidoItem);
                    await _context.SaveChangesAsync();
                    UpdatePedido(pedidoItem.PedidoId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoItemExists(pedidoItem.PedidoItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("PedidoItens", "AdminPedido", new { id = pedidoItem.PedidoId });
            }
            ViewData["ItemId"] = new SelectList(_context.Itens, "ItemId", "Cor", pedidoItem.ItemId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "Cep", pedidoItem.PedidoId);
            return View(pedidoItem);
        }

        

        private bool PedidoItemExists(int pedidoItemId)
        {
            throw new NotImplementedException();
        }

        // GET: Admin/AdminPedidoMovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PedidoItens == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItens
                .Include(p => p.Item)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.PedidoItemId == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // POST: Admin/AdminPedidoMovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PedidoItens == null)
            {

                return Problem("Entity set 'AppDbContext.PedidoItens'  is null.");
            }
            var pedidoItem = await _context.PedidoItens.FindAsync(id);
            if (pedidoItem != null)
            {
                _context.PedidoItens.Remove(pedidoItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("PedidoItens", "AdminPedido", new { id = pedidoItem.PedidoId });
        }

        public void UpdatePedido(int pedidoId)
        {
            List<PedidoItem> itens = _context.PedidoItens.Include(i => i.Item).Where(p => p.PedidoId == pedidoId).ToList();

            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            foreach (PedidoItem pm in itens)
            {
                totalItensPedido += pm.Quantidade;
                precoTotalPedido += (Convert.ToDecimal(pm.Item.Preco) * pm.Quantidade);
            }

            Pedido p = _context.Pedidos.FirstOrDefault(p => p.PedidoId == pedidoId);

            p.TotalItensPedido = totalItensPedido;
            p.PedidoTotal = precoTotalPedido;

            try
            {
                _context.Update(p);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
    }
}
