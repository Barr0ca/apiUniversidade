using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;

namespace apiUniversidade.Controllers;

[ApiController]
[Route("[controller]")]

public class CursosController : ControllerBase
{
    [HttpGet(Name = "cursos")]   

    public List<Curso> GetCursos()
    {
        List<Aluno> alunos = new List<Aluno>();
        List<Disciplina> disciplinasInf = new List<Disciplina>();
        List<Disciplina> disciplinaMsi = new List<Disciplina>();
        List<Curso> cursos = new List<Curso>();

        disciplinasInf.Add(new Disciplina{
            Nome = "Programação para Internet",
            CargaHoraria = 60,
            Semestre = 4
        });
        disciplinasInf.Add(new Disciplina{
            Nome = "Pragamação Orientada a Objetos",
            CargaHoraria = 80,
            Semestre = 2
        });
        disciplinasInf.Add(new Disciplina{
            Nome = "Desenvolvimento Back-End",
            CargaHoraria = 80,
            Semestre = 4
        });


        disciplinaMsi.Add(new Disciplina{
            Nome  = "Manutenção de Computadores",
            CargaHoraria = 60,
            Semestre = 1
        });
        disciplinaMsi.Add(new Disciplina{
            Nome = "Eletricidade Instrumental",
            CargaHoraria = 80,
            Semestre = 4
        });
        disciplinaMsi.Add(new Disciplina{
            Nome = "Eletricidade",
            CargaHoraria = 60,
            Semestre = 2
        });

        cursos.Add(new Curso{
            Nome = "Informática",
            Area = "Computação",
            Duracao = 6, 
            Disciplinas = disciplinasInf,
            Alunos = alunos
        });

        cursos.Add(new Curso{
            Nome = "Manutenção e Suporte para Informática",
            Area = "Eletrônica",
            Duracao = 6,
            Disciplinas = disciplinaMsi,
            Alunos = alunos
        });


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

        return cursos;
    }
}