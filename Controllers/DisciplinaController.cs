using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;

namespace apiUniversidade.Controllers;

[ApiController]
[Route("[controller]")]

public class DisciplinaController : ControllerBase
{
    [HttpGet(Name = "disciplinas")]

    public List<Disciplina> GetDisciplina()
    {
        List<Disciplina> disciplinas = new List<Disciplina>();

        disciplinas.Add(new Disciplina{
            Nome = "Programação para Internet",
            CargaHoraria = 60,
            Semestre = 4
        });
        disciplinas.Add(new Disciplina{
            Nome = "Pragamação Orientada a Objetos",
            CargaHoraria = 80,
            Semestre = 2
        });
        disciplinas.Add(new Disciplina{
            Nome = "Desenvolvimento Back-End",
            CargaHoraria = 80,
            Semestre = 4
        });
        return disciplinas;
    }
}