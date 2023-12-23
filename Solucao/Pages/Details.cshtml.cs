using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solucao.Models;
using System.Data;
using System.Xml.Linq;

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
            if (id == 0)
            {
                Product = new Produto(id, 0, 0, "", "");
            }

            string sqlQuery = $"SELECT produtoid, nome, descrição, valorunitario , quantidade FROM estoque E JOIN produto p ON  e.produtoid = p.id WHERE produtoid = {id}";
            //produtoid nome descrição valorunitario quantidade

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

        public IActionResult OnPostCreateOrUpdate(int id, string name, string descricao, int quantity, double valUnit)
        {
            string sqlQuery = $"SELECT * FROM Produto WHERE Id = {id}";
            DataTable dataTable = _context.ExecuteQuery(sqlQuery);
            if (dataTable.Rows.Count > 0)
            {
                string updt = $"UPDATE Produto SET Nome = '{name}', Descrição = '{descricao}', ValorUnitario = {valUnit} WHERE Id = {id}";
                _context.ExecuteQuery(updt);

                updt = $"UPDATE Estoque SET Quantidade = {quantity} WHERE ProdutoId = {id}";
                _context.ExecuteQuery(updt);
            }
            else
            {
                string insert = $"INSERT INTO Produto (Id, Nome, Descrição, ValorUnitario) VALUES ({id}, '{name}', '{descricao}', {valUnit})";
                _context.ExecuteQuery(insert);

                insert = $"INSERT INTO Estoque (ProdutoId, Quantidade) VALUES ({id}, {quantity})";
                _context.ExecuteQuery(insert);
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete(int id)
        {
            string sqlQuery = $"DELETE FROM estoque WHERE produtoid = {id}";
            _context.ExecuteQuery(sqlQuery);

            return RedirectToPage("Index");
        }
    }
}