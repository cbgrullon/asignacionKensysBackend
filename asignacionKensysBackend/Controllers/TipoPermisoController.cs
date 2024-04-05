using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asignacionKensysBackend.DTO;
using asignacionKensysBackend.Services;
using asignacionKensysBackend.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asignacionKensysBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPermisoController : Controller
    {
        private readonly AppDbContext _dbContext;
        public TipoPermisoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tipoPermisos = await _dbContext.TipoPermisos.ToListAsync();
            return Ok(tipoPermisos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            TipoPermiso tipoPermiso = await _dbContext.TipoPermisos.FindAsync(id);
            if(tipoPermiso == null)
            {
                return NotFound();
            }
            return Ok(tipoPermiso);
        }
    }
}