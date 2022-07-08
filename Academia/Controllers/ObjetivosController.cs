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
    public class ObjetivosController : Controller
    {
        private readonly IObjetivoRepository _objetivoRepository;

        public ObjetivosController(IObjetivoRepository objetivoRepository)
        {
            _objetivoRepository = objetivoRepository;
        }

        // GET: Objetivos
        public async Task<IActionResult> Index()
        {
            return View(await _objetivoRepository.PegarTodos().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                await _objetivoRepository.Inserir(objetivo);
                return RedirectToAction(nameof(Index));
            }
            return View(objetivo);
        }

        // GET: Objetivos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var objetivo = await _objetivoRepository.PegarPorIdAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }
            return View(objetivo);
        }

        // POST: Objetivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] Objetivo objetivo)
        {
            if (id != objetivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _objetivoRepository.Atualizar(objetivo);
                return RedirectToAction(nameof(Index));
            }
            return View(objetivo);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _objetivoRepository.Excluir(id);
            return Json("Objetivo excluído com sucesso.");
        }
        
        public async Task<JsonResult> ObjetivoExiste(string nome, int id)
        {
            if(id == 0)
            {
                if(await _objetivoRepository.ObjetivoExiste(nome))
                {
                    return Json("Objetivo já existe.");
                }
                
                return Json(true);
            }
            else
            {
                if (await _objetivoRepository.ObjetivoExiste(nome, id))
                {
                    return Json("Objetivo já existe.");
                }

                return Json(true);
            }

        }
    }
}
