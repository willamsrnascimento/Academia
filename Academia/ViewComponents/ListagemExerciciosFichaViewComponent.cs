using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.ViewComponents
{
    public class ListagemExerciciosFichaViewComponent : ViewComponent
    {
        private readonly AcademiaContext _academiaContext;

        public ListagemExerciciosFichaViewComponent(AcademiaContext academiaContext)
        {
            _academiaContext = academiaContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _academiaContext.ListaExercicios.Include(l => l.Exercicio).Where(l => l.FichaId == id).ToListAsync());
        }
    }
}
