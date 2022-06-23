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

namespace Academia.Controllers
{
    public class ExerciciosController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
        private readonly ICategoriaExercicioRepository _categoriaExercicioRepository;

        public ExerciciosController(IExercicioRepository exercicioRepository, ICategoriaExercicioRepository categoriaExercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
            _categoriaExercicioRepository = categoriaExercicioRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _exercicioRepository.PegarTodos());
        }

        public IActionResult Create()
        {
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                await _exercicioRepository.Inserir(exercicio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "Id", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var exercicio = await _exercicioRepository.PegarPorIdAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "Id", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (id != exercicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _exercicioRepository.Atualizar(exercicio);

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "Id", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _exercicioRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> ExercicioExiste(string nome, int id)
        {
            if(id == 0)
            {
                if(await _exercicioRepository.ExercicioExiste(nome))
                {
                    return Json("Exercício já existe!");
                }

                return Json(true);
            }
            else
            {
                if (await _exercicioRepository.ExercicioExiste(nome, id))
                {
                    return Json("Exercício já existe!");
                }

                return Json(true);
            }
        }
    }
}
