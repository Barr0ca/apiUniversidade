using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;

namespace apiUniversidade.Controllers;

[ApiController]
[Route("[controller]")]

public class AlunosController : ControllerBase
{
    [HttpGet(Name = "alunos")]

    public List<Aluno> GetAlunos()
    {
        List<Aluno> alunos = new List<Aluno>();

        alunos.Add(new Aluno{
            Nome = "Ian",
            CPF = "555-444",
            DataNascimento = DateTime.Now
        });
        alunos.Add(new Aluno{
            Nome = "Iago",
            CPF = "111-777",
            DataNascimento = DateTime.Now
        });

        return alunos;
    }
}