using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;
using apiUniversidade.Context;
using Microsoft.EntityFrameworkCore;

namespace apiUniversidade.Controllers;

[ApiController]
[Route("[controller]")]

public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly ApiUniversidadeContext _context;

    public CursoController(ILogger<CursoController> logger, ApiUniversidadeContext context)
    {
        _logger = logger;
        _context = context;
    }  

    [HttpGet]
    public ActionResult<IEnumerable<Curso>> Get()
    {
        var cursos = _context.Cursos.ToList();
        if(cursos is null)
            return NotFound();
        
        return cursos;
    }

    [HttpPost]
    public ActionResult Post(Curso cursos)
    {
        _context.Cursos.Add(cursos);
        _context.SaveChanges();
        
        return new CreatedAtRouteResult("GetCurso",
            new{id = cursos.Id},
            cursos);
    }

    [HttpGet("{id:int}", Name="GetCurso")]
    public ActionResult<Curso> Get(int id)
    {
        var cursos = _context.Cursos.FirstOrDefault(p => p.Id == id);
        if(cursos is null)
            return NotFound("Curso não encontrado.");

        return cursos;
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Curso cursos)
    {
        if(id != cursos.Id)
            return BadRequest();

        _context.Entry(cursos).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(cursos);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var cursos = _context.Cursos.FirstOrDefault(p => p.Id == id);

        if (cursos is null)
            return NotFound();

        _context.Cursos.Remove(cursos);
        _context.SaveChanges();

        return Ok(cursos);
    }
}