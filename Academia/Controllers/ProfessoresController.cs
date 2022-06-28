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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Academia.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProfessoresController(IProfessorRepository professorRepository, IHostingEnvironment hostingEnvironment)
        {
            _professorRepository = professorRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _professorRepository.PegarTodos().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Foto,Telefone,Turno")] Professor professor, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "imagens");

                if(arquivo != null)
                {
                    using(var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        professor.Foto = $"~/imagens/{arquivo.FileName}";
                    }
                }              

                await _professorRepository.Inserir(professor);
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var professor = await _professorRepository.PegarPorIdAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            TempData["Professor"] = professor.Foto;

            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Foto,Telefone,Turno")] Professor professor, IFormFile arquivo)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "imagens");

                if (arquivo != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        professor.Foto = $"~/imagens/{arquivo.FileName}";
                    }
                }
                else
                {
                    professor.Foto = TempData["Professor"].ToString();
                }

                await _professorRepository.Atualizar(professor);

                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _professorRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> ProfessorExiste(string nome, int id)
        {
            if(id == 0)
            {
                if (await _professorRepository.ProfessorExiste(nome))
                {
                   return Json("Professor já exste.");
                }

                return Json(true);
            }
            else
            {
                if (await _professorRepository.ProfessorExiste(nome, id))
                {
                    return Json("Professor já exste.");
                }

                return Json(true);
            }
        }
    }
}
