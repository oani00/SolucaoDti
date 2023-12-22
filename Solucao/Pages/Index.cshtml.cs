using Microsoft.AspNetCore.Mvc.RazorPages;
using Solucao.Models;
using System.Data;

namespace Solucao.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DbContext _context;

        public IndexModel(DbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }

        public void OnGet()
        {
            DataTable dataTable = _context.ExecuteQuery("SELECT * FROM Products");
            Products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                string name = Convert.ToString(row["Name"]);
                Products.Add(new Product(id, quantity, name));
            }
        }
    }
}