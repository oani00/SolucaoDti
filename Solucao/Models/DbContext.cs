using System.Data;
using System.Data.SqlClient;

namespace Solucao.Models
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext()
        {
            _connectionString = $@"  Data Source=OANI-PC;
                                    Initial Catalog=Solucao;
                                    User ID=sa;
                                    Password={File.ReadAllText(@"C:\backupsON\password.txt")};
                                    Connect Timeout=30;
                                    Encrypt=False;
                                    TrustServerCertificate=False;
                                    ApplicationIntent=ReadWrite;
                                    MultiSubnetFailover=False";
            //Le a senha de um simples arquivo de texto fora do projeto que contém apenas a senha.
        }

        public DataTable ExecuteQuery(string sqlQuery)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
    }
}