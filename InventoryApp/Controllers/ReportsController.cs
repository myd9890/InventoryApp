using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using InventoryApp.Data;
using InventoryApp.Models;
using InventoryApp.ViewModels;

namespace InventoryApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;
        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // /Reports/Inventory?from=&to=
        public async Task<IActionResult> Inventory(DateTime? from, DateTime? to)
        {
            var query = _context.Products.AsQueryable();

            if (from.HasValue)
                query = query.Where(p => p.CreatedAt >= from.Value);

            if (to.HasValue)
                query = query.Where(p => p.CreatedAt <= to.Value);

            var products = await query.ToListAsync();

            var vm = new ReportViewModel
            {
                TotalProducts = products.Count,
                TotalQuantity = products.Sum(p => p.Quantity),
                TotalInventoryValue = products.Sum(p => p.Price * p.Quantity),
                Top5ByValue = products
                    .OrderByDescending(p => p.Price * p.Quantity)
                    .Take(5)
                    .Select(p => new ProductReportDto
                    {
                        Name = p.Name,
                        Quantity = p.Quantity,
                        LineValue = p.Price * p.Quantity,
                    })
                    .ToList(),
                LowStockItems = products
                   .Where(p => p.Quantity < 5)
                   .Select(p => new ProductReportDto
                   {
                       Name = p.Name,
                       Quantity = p.Quantity,
                       LineValue = p.Price * p.Quantity,
                   })
                   .ToList()
            };

            return View(vm);
        }

        // /Reports/InventoryCsv
        public async Task<IActionResult> InventoryCsv(DateTime? from, DateTime? to)
        {
            var query = _context.Products.AsQueryable();

            if (from.HasValue)
                query = query.Where(p => p.CreatedAt >= from.Value);

            if (to.HasValue)
                query = query.Where(p => p.CreatedAt <= to.Value);

            var products = await query.ToListAsync();

            var sb = new StringBuilder();
            sb.AppendLine("Id,Name,Price,Quantity,CreatedAt,LineValue");

            foreach (var p in products)
            {
                var lineValue = p.Price * p.Quantity;
                sb.AppendLine($"{p.Id},{p.Name},{p.Price},{p.Quantity},{p.CreatedAt},{lineValue}");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "InventoryReport.csv");
        }
    }
}