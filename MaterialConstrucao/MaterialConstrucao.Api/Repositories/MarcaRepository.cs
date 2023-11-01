using MaterialConstrucao.Api.Models;
using System;
using System.Linq;

namespace MaterialConstrucao.Api.Repositories
{
    public class MarcaRepository : Repository<Marca>, IDisposable
    {
        public void Dispose()
        {
            //como não tem contexto não tem o que que dar dispose
            return;
        }

        public Marca FindById(int Id)
        {
            try
            {
                var marcas = this.GetListObjectFromJson("Data/data.json");
                return marcas.First(mar => mar.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
