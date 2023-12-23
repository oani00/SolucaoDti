namespace Solucao.Models
{
    public class Produto
    {
        public readonly int Id;
        public readonly int Quantidade;
        public readonly double ValorUnitario;
        public readonly string Descricao;
        public readonly string Name;

        public Produto(int id, int quantidade, double valorUnitario, string descricao, string name)
        {
            Id = id;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            Name = name;
        }
    }
}