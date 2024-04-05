using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asignacionKensysBackend.Models;
using Microsoft.AspNetCore.Mvc;
using asignacionKensysBackend.DTO;
using asignacionKensysBackend.Services;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asignacionKensysBackend.Controllers
{
    [Route("api/[controller]")]
    public class PermisoController : Controller
    {
        private readonly AppDbContext _dbContext;
        public PermisoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permisos = await _dbContext.Permisos.Include(x=>x.TipoPermiso).ToListAsync();

            return Ok(permisos);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var permiso = await _dbContext.Permisos.FindAsync(id);
            if(permiso == null)
            {
                return NotFound();
            }
            return Ok(permiso);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PermisoUpsertDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permiso permiso;
            bool isInsert = dto.Id == null;
            if (dto.Id == null)
            {
                permiso = new Permiso();
            }
            else
            {
                permiso = await _dbContext.Permisos.FindAsync(dto.Id.Value);

                if(permiso == null)
                {
                    return NotFound();
                }
            }

            TipoPermiso tipoPermiso = await _dbContext.TipoPermisos.FindAsync(dto.TipoPermisoId);
            if(tipoPermiso == null)
            {
                ModelState.AddModelError(nameof(dto.TipoPermisoId), $"{nameof(dto.TipoPermisoId)} not found");
                return BadRequest(ModelState);
            }

            permiso.NombreEmpleado = dto.NombreEmpleado;
            permiso.ApellidosEmpleado = dto.ApellidosEmpleado;
            permiso.FechaPermiso = dto.FechaPermiso;
            permiso.TipoPermisoId = dto.TipoPermisoId.Value;


            if (isInsert)
            {
                await _dbContext.Permisos.AddAsync(permiso);
            }
            else
            {
                _dbContext.Permisos.Update(permiso);
            }
            await _dbContext.SaveChangesAsync();
            return Ok(permiso);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Permiso permiso = await _dbContext.Permisos.FindAsync(id);
            if(permiso == null)
            {
                return NotFound();
            }
            _dbContext.Permisos.Remove(permiso);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

