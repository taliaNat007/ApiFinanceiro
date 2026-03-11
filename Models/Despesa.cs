namespace ApiFinanceiro.Models
{
    public class Despesa
    {
        // , , , data previsão, data recebimento
        // , 
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Descricao { get; set; }
        public required string Categoria { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataPrevisao{ get; set; } 
        // dataVencimento
        public required string Situacao { get; set; }
        public required DateTime? DataRecebimento { get; set; }
        //DataPAgamento
    }
}
