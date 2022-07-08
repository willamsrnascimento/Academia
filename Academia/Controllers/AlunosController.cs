using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Domain.Models;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Academia.Controllers
{
    [Authorize]
    public class AlunosController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IObjetivoRepository _objetivoRepository;
        private readonly IProfessorRepository _professorRepository;

        public AlunosController(IAlunoRepository alunoRepository, IObjetivoRepository objetivoRepository, IProfessorRepository professorRepository)
        {
            _alunoRepository = alunoRepository;
            _objetivoRepository = objetivoRepository;
            _professorRepository = professorRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _alunoRepository.PegarTodos());
        }

        public IActionResult Create()
        {
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "Id", "Nome");
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,Idade,Peso,ProfessorId,FrequenciaSemanal,ObjetivoId")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                await _alunoRepository.Inserir(aluno);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "Id", "Nome", aluno.ObjetivoId);
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "Id", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _alunoRepository.PegarPorIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "Id", "Nome", aluno.ObjetivoId);
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "Id", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,Idade,Peso,ProfessorId,FrequenciaSemanal,ObjetivoId")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _alunoRepository.Atualizar(aluno);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "Id", "Nome", aluno.ObjetivoId);
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "Id", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> Delete(int id)
        {
            await _alunoRepository.Excluir(id);
            return Json("Aluno excluído com sucesso.");
        }

        public async Task<JsonResult> AlunoExiste(string nome, int id)
        {
            if(id == 0)
            {
                if(await _alunoRepository.AlunoExiste(nome))
                {
                    return Json("Aluno já existe");
                }

                return Json(true);
            }
            else
            {
                if (await _alunoRepository.AlunoExiste(nome, id))
                {
                    return Json("Aluno já existe");
                }

                return Json(true);
            }

        }

    }
}
