using MaterialConstrucao.Api.Models;
using MaterialConstrucao.Api.Repositories;
using System.Collections.Generic;

namespace MaterialConstrucao.Api.Services
{
    public class MaterialService
    {        
        public List<Material> SelectByFilter(string name, string ordPrice, bool unicByMarca, int numItems)
        {
            using (var repository = new MaterialRepository())
            {
                return repository.SelectByFilter(name, ordPrice, unicByMarca, numItems);
            }
        }
    }
}
