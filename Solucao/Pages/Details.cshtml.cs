using Microsoft.AspNetCore.Mvc.RazorPages;
using Solucao.Models;
using System.Data;

namespace Solucao.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly DbContext _context;

        public DetailsModel(DbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public void OnGet(int id)
        {
            string sqlQuery = $"SELECT Name, Quantity FROM Products WHERE Id = {id}";
            DataTable dataTable = _context.ExecuteQuery(sqlQuery);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                string name = Convert.ToString(row["Name"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                Product = new Product(id, quantity, name);
            }
        }
    }
}