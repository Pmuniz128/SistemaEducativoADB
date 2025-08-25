using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEducativo.Frontend.Models;

namespace SistemaEducativo.Frontend.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly ICarreraApiService _carreraService;
        private readonly IMateriaApiService _materiaService;

        public IndexModel(ICarreraApiService carreraService, IMateriaApiService materiaService)
        {
            _carreraService = carreraService;
            _materiaService = materiaService;
        }

        public List<CarreraViewModel> Carreras { get; set; } = new();
        public List<MateriaViewModel> Materias { get; set; } = new();

        public async Task OnGetAsync()
        {
            Carreras = await _carreraService.GetCarrerasAsync();
            Materias = await _materiaService.GetMateriasAsync();
        }
    }


}


