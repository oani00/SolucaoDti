using Microsoft.AspNetCore.Mvc.RazorPages;
using Solucao.Models;
using System.Data;

namespace Solucao.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DbContext _context;

        public IndexModel()
        {
            _context = new DbContext();
        }

        public List<Produto> Products { get; set; }

        public void OnGet()
        {
            DataTable dataTable = _context.ExecuteQuery("SELECT produtoid, nome, descrição, valorunitario , quantidade FROM estoque E JOIN produto p ON  e.produtoid = p.id");
            //produtoid nome    descrição valorunitario   quantidade

            Products = new List<Produto>();
            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["produtoid"]);
                int quantity = Convert.ToInt32(row["quantidade"]);
                string name = Convert.ToString(row["nome"]);
                string dscr = Convert.ToString(row["descrição"]);
                double valUnit = Convert.ToDouble(row["valorunitario"]);
                Products.Add(new Produto(id, quantity, valUnit, dscr, name));
            }
        }
    }
}