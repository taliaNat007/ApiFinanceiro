using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinanceiro.Models
{
    [Table("despesas"), PrimaryKey(nameof(Id))]
    public class Despesa
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("descricao")]
        public required string Descricao { get; set; }

        [Column("categoria")]
        public required string Categoria { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data_vencimento")]
        public DateOnly DataPrevisao{ get; set; }
        // dataVencimento

        [Column("situacao")]
        public required string Situacao { get; set; }

        [Column("data_pagamento")]
        public required DateTime? DataRecebimento { get; set; }
        //DataPAgamento
    }
}
