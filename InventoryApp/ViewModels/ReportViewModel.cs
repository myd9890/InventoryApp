namespace InventoryApp.ViewModels
{
    public class ReportViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public required List<ProductReportDto> Top5ByValue { get; set; }
        
        public required List<ProductReportDto> LowStockItems { get; set; }

    }

    public class ProductReportDto
    {
        public required String Name { get; set; }
        public int Quantity { get; set; }

        public decimal LineValue { get; set; }

    }
}
