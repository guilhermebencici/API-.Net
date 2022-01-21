using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProdutos()
        {
            CursoContext cursoContext = new CursoContext();
            var produtos = cursoContext.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet ("{idProduto}")]

        public IActionResult GetProduto(int idProduto)
        {
            CursoContext cursoContext = new CursoContext();
            var produto = cursoContext.Produtos.Find(idProduto);
            if (produto == null)
                return NotFound("Produto não encontrado");
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult InserirProduto(Produto produto)
        {
            var cursoContext = new CursoContext();
            cursoContext.Produtos.Add(produto);

            cursoContext.SaveChanges();

            return CreatedAtAction("GetProduto", new { idProduto = produto.Id }, produto);
        }

        [HttpPut]
        public IActionResult AtualizarProduto(Produto produto, int id)
        {
            var cursoContext = new CursoContext();
            var produtoAtualizar = cursoContext.Produtos.Find(id);
            if (produtoAtualizar == null)
                return BadRequest("Produto não encontrado");

            produtoAtualizar.Nome = produto.Nome;
            produtoAtualizar.Valor = produto.Valor;

            cursoContext.SaveChanges();

            return Ok(produtoAtualizar);
        }
    }
}
