using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CategoriasController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Categorias.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoria = _db.Categorias.FirstOrDefault(f => f.Id == id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult CreateCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest("Categoria informada com problemas");
            _db.Categorias.Add(categoria);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), categoria.Id, new { categoria });
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateCategoria(int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid || id != categoria.Id)
                return BadRequest("Categoria informada com problemas");
            _db.Categorias.Update(categoria);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var categoria = _db.Categorias.FirstOrDefault(f => f.Id == id);
            if (categoria == null)
                return NotFound();
            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
            return NoContent();
        }
    }
}