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
    public class CategoriasExerciciosController : Controller
    {
        private readonly ICategoriaExercicioRepository _categoriaExercicioRepository;

        public CategoriasExerciciosController(ICategoriaExercicioRepository categoriaExercicioRepository)
        {
            _categoriaExercicioRepository = categoriaExercicioRepository;
        }

        public IActionResult Index()
        {
            return View(_categoriaExercicioRepository.PegarTodos());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (ModelState.IsValid)
            {
                await _categoriaExercicioRepository.Inserir(categoriaExercicio);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var categoriaExercicio = await _categoriaExercicioRepository.PegarPorIdAsync(id);
            if (categoriaExercicio == null)
            {
                return NotFound();
            }
            return View(categoriaExercicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (id != categoriaExercicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoriaExercicioRepository.Atualizar(categoriaExercicio);

                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaExercicioRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> CategoriaExiste(string nome, int categoriaExercicioId)
        {
            if(categoriaExercicioId == 0)
            {
                if(await _categoriaExercicioRepository.CategoriaExiste(nome))
                {
                    return Json("Categoria já existe!");
                }

                return Json(true);
            }
            else
            {
                if(await _categoriaExercicioRepository.CategoriaExiste(nome, categoriaExercicioId))
                {
                    return Json("Categoria já existe!");
                }

                return Json(true);
            }
        }
    }
}
