using Microsoft.AspNetCore.Mvc.RazorPages;
using Solucao.Models;
using System.Data;

namespace Solucao.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly DbContext _context;

        public DetailsModel()
        {
            _context = new DbContext();
        }

        public Produto Product { get; set; }

        public void OnGet(int id)
        {
            string sqlQuery = $"SELECT produtoid, nome, descrição, valorunitario , quantidade FROM estoque E JOIN produto p ON  e.produtoid = p.id WHERE produtoid = {id}";
            //produtoid nome    descrição valorunitario   quantidade

            DataTable dataTable = _context.ExecuteQuery(sqlQuery);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                string name = Convert.ToString(row["nome"]);
                string descricao = Convert.ToString(row["descrição"]);
                int quantity = Convert.ToInt32(row["quantidade"]);
                double valUnit = Convert.ToDouble(row["valorunitario"]);
                Product = new Produto(id, quantity, valUnit, descricao, name);
            }
        }
    }
}