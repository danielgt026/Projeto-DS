using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDS.Data;
using ProjetoDS.Models;

namespace ProjetoDS2._0.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class Tarefas : ControllerBase
    {
        private readonly DataContext _context;

        public Tarefas (DataContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Tarefas t = await _context.TB_TAREFAS.FirstOrDefaultAsync(tBusca => tBusca.Id == id);

                return Ok(t);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public static implicit operator Tarefas?(ProjetoDS.Models.Tarefas? v)
        {
            throw new NotImplementedException();
        }

    }
}