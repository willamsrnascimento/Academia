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
    public class FichasController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IFichaRepository _fichaRepository;

        public FichasController(IAlunoRepository alunoRepository, IFichaRepository fichaRepository)
        {
            _alunoRepository = alunoRepository;
            _fichaRepository = fichaRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.AlunoId = id;
            return View(await _fichaRepository.PegarTodasFichasPeloAlunoId(id));
        }

        // GET: Fichas/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var ficha = await _fichaRepository.PegarFichaPeloAlunoId(id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // GET: Fichas/Create
        public IActionResult Create(int AlunoId)
        {
            Ficha ficha = new Ficha();
            ficha.AlunoId = AlunoId; 
            return View(ficha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataCadastro,DataValidade,AlunoId")] Ficha ficha)
        {
            ficha.DataCadastro = DateTime.Parse(DateTime.Now.ToShortDateString());
            ficha.DataValidade = DateTime.Parse(DateTime.Now.AddYears(1).ToShortDateString());

            if (ModelState.IsValid)
            {
                await _fichaRepository.Inserir(ficha);
                return RedirectToAction(nameof(Index), new {Id = ficha.AlunoId});
            }

            return View(ficha);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ficha = await _fichaRepository.PegarPorIdAsync(id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataCadastro,DataValidade,AlunoId")] Ficha ficha)
        {
            if (id != ficha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _fichaRepository.Atualizar(ficha);
                return RedirectToAction(nameof(Index), new { Id = ficha.AlunoId });
            }

            return View(ficha);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> Delete(int id)
        {
            await _fichaRepository.Excluir(id);
            return Json("Ficha excluida com sucesso.");
        }
        
        public async Task<JsonResult> FichaExiste(string nome, int id)
        {
            if(id == 0)
            {
                if(await _fichaRepository.FichaExiste(nome))
                {
                    return Json("Ficha já cadastrada.");
                }

                return Json(true);
            }
            else
            {
                if (await _fichaRepository.FichaExiste(nome, id))
                {
                    return Json("Ficha já cadastrada.");
                }

                return Json(true);
            }
        }
    }
}
