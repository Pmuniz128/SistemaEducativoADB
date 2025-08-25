using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaEducativo.Frontend.Models;


public interface ICarreraApiService
{
    Task<List<CarreraViewModel>> GetCarrerasAsync();
}

