using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Academia.ViewComponents
{
    public class DadosAlunoViewComponent : ViewComponent
    {
        private readonly IAlunoRepository _alunoRepository;

        public DadosAlunoViewComponent(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _alunoRepository.PegarDadosAlunoPeloId(id));
        }

    }
}
