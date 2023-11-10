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

public class DisciplinaController : ControllerBase
{
    private readonly ILogger<DisciplinaController> _logger;
    private readonly ApiUniversidadeContext _context;

    public DisciplinaController(ILogger<DisciplinaController> logger, ApiUniversidadeContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetDisciplina")]
    public ActionResult<IEnumerable<Disciplina>> Get()
    {
        var disciplinas = _context.Disciplinas.ToList();
        if(disciplinas is null)
            return NotFound();
        
        return disciplinas;
    }

    [HttpPost]
    public ActionResult Post(Disciplina disciplinas)
    {
        _context.Disciplinas.Add(disciplinas);
        _context.SaveChanges();
        
        return new CreatedAtRouteResult("GetDisciplina",
            new{id = disciplinas.Id},
            disciplinas);
    }

    [HttpGet("{id:int}", Name="GetDisciplinas")]
    public ActionResult<Disciplina> Get(int id)
    {
        var disciplinas = _context.Disciplinas.FirstOrDefault(p => p.Id == id);
        if(disciplinas is null)
            return NotFound("Disciplina não encontrada.");

        return disciplinas;
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Disciplina disciplinas)
    {
        if(id != disciplinas.Id)
            return BadRequest();

        _context.Entry(disciplinas).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(disciplinas);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var disciplinas = _context.Disciplinas.FirstOrDefault(p => p.Id == id);

        if (disciplinas is null)
            return NotFound();

        _context.Disciplinas.Remove(disciplinas);
        _context.SaveChanges();

        return Ok(disciplinas);
    }
}