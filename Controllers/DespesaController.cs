using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceiro.Controllers
{
    [Route("/despesas")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private static List<Despesa> listaDespesas = new()
        {
      
        };

      
        //Create: método para criar
        [HttpPost()]
        public ActionResult Create([FromBody] DespesaDto novaDespesa)
        {
            var despesa = new Despesa
            { 
                Descricao = novaDespesa.Descricao,
                Valor = novaDespesa.Valor,
                Categoria = novaDespesa.Categoria,
                DataPrevisao = novaDespesa.DataPrevisao,
                DataRecebimento = novaDespesa.DataRecebimento,
                Situacao = " "
            };

            listaDespesas.Add(despesa);

            return Created("", despesa);
        }

        //Read: método para buscar os cadastro e fazer a leitura. É a lista
        [HttpGet()]
        public ActionResult FindAll()
        {
            return Ok(listaDespesas);
        }

        //Update: Atualiza todos os campos
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] DespesaUpdateDto despesaDto)
        {
            var despesa = listaDespesas.FirstOrDefault(d => d.Id == id);
            if (despesa is null)
            {
                return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
            }
            despesa.Descricao = despesaDto.Descricao;
            despesa.Valor = despesaDto.Valor;
            despesa.DataPrevisao = despesaDto.DataPrevisao;
            despesa.Categoria = despesaDto.Categoria;
            despesa.Situacao = despesaDto.Situacao;
            despesa.DataRecebimento = despesa.DataRecebimento;
            
            var dataPagamento = new DateTime(despesaDto.DataRecebimento.Year, despesaDto.DataRecebimento.Month, despesaDto.DataRecebimento.Day);
            return Ok(despesa);
        }

        //Delete: Deleta os dados
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id, [FromBody] DespesaUpdateDto despesaDto)
        {
            var despesa = listaDespesas.FirstOrDefault(d => d.Id == id);
            if (despesa is null)
            {
                return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
            }
            listaDespesas.Remove(despesa);
            return NoContent();
        }
    }
}
