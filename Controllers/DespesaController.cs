using ApiFinanceiro.DataContexts;
using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiFinanceiro.Controllers
{
    [Route("/despesas")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
      
        private readonly AppDbContext _context;
        public DespesaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var listaDespesas = await _context.Despesas.ToListAsync();

                return Ok(listaDespesas);
            }
            catch (Exception e)
            {

                return Problem(e .Message);
            }
            
        }

        [HttpPost()]
        public async Task<ActionResult>  Create([FromBody] DespesaDto novaDespesa)
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

           await _context.Despesas.AddAsync(despesa);
           await _context.SaveChangesAsync();

            return Created("", despesa);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var despesa = await _context.Despesas.FirstOrDefaultAsync(x => x.Id == id);

                if (despesa is null)
                {
                    return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
                }

                return Ok(despesa);

            }
            catch (Exception e)
            {

                return Problem(e .Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DespesaUpdateDto despesaDto)
        {
            var despesa = await _context.Despesas.FirstOrDefaultAsync(d => d.Id == id);
            if (despesa is null)
            {
                return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
            }

            var dataPagamento = new DateTime(despesaDto.DataPagamento.Year, despesaDto.DataPagamento.Month, despesaDto.DataPagamento.Day);

            despesa.Descricao = despesaDto.Descricao;
            despesa.Valor = despesaDto.Valor;
            despesa.DataPrevisao = despesaDto.DataPrevisao;
            despesa.Categoria = despesaDto.Categoria;
            despesa.Situacao = despesaDto.Situacao;
            despesa.DataRecebimento = dataPagamento;

            _context.Despesas.Update(despesa);
            await _context.SaveChangesAsync();
            return Ok(despesa);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Remove(int id, [FromBody] DespesaUpdateDto despesaDto)
        {
            try
            {
                var despesa = await _context.Despesas.FirstOrDefaultAsync(d => d.Id == id);
                if (despesa is null)
                {
                    return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
                }
                _context.Despesas.Remove(despesa);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        //private static List<Despesa> listaDespesas = new()
        //{

        //};

        //    //Create: método para criar
        //    [HttpPost()]
        //    public ActionResult Create([FromBody] DespesaDto novaDespesa)
        //    {
        //        var despesa = new Despesa
        //        { 
        //            Descricao = novaDespesa.Descricao,
        //            Valor = novaDespesa.Valor,
        //            Categoria = novaDespesa.Categoria,
        //            DataPrevisao = novaDespesa.DataPrevisao,
        //            DataRecebimento = novaDespesa.DataRecebimento,
        //            Situacao = " "
        //        };

        //        listaDespesas.Add(despesa);

        //        return Created("", despesa);
        //    }


        //    //Update: Atualiza todos os campos
        //    [HttpPut("{id}")]
        //    public ActionResult Update(Guid id, [FromBody] DespesaUpdateDto despesaDto)
        //    {
        //        var despesa = listaDespesas.FirstOrDefault(d => d.Id == id);
        //        if (despesa is null)
        //        {
        //            return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
        //        }
        //        despesa.Descricao = despesaDto.Descricao;
        //        despesa.Valor = despesaDto.Valor;
        //        despesa.DataPrevisao = despesaDto.DataPrevisao;
        //        despesa.Categoria = despesaDto.Categoria;
        //        despesa.Situacao = despesaDto.Situacao;
        //        despesa.DataRecebimento = despesa.DataRecebimento;

        //        var dataPagamento = new DateTime(despesaDto.DataRecebimento.Year, despesaDto.DataRecebimento.Month, despesaDto.DataRecebimento.Day);
        //        return Ok(despesa);
        //    }

        //    //Delete: Deleta os dados
        //    [HttpDelete("{id}")]
        //    public ActionResult Remove(Guid id, [FromBody] DespesaUpdateDto despesaDto)
        //    {
        //        var despesa = listaDespesas.FirstOrDefault(d => d.Id == id);
        //        if (despesa is null)
        //        {
        //            return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
        //        }
        //        listaDespesas.Remove(despesa);
        //        return NoContent();
        //    }
    }
}
