using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GranShopAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GranShopAPI.Models;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProdutosController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Produtos.Include(i => i.Categoria).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _db.Produtos.Include(i => i.Categoria).FirstOrDefault(f => f.Id == id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult CreateProduto([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Produto informado com problemas");
            _db.Produtos.Add(produto);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), produto.Id, new { produto });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid || id != produto.Id)
                return BadRequest("Produto informado com problemas");
            _db.Produtos.Update(produto);
            _db.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = _db.Produtos.Include(i => i.Categoria).FirstOrDefault(f => f.Id == id);
            if (produto == null)
                return NotFound();
            _db.Produtos.Remove(produto);
            _db.SaveChanges();
            return NoContent();
        }
    }
}