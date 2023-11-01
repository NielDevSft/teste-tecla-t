using MaterialConstrucao.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialConstrucao.Api.Repositories
{
    public class MaterialRepository : Repository<Material>, IDisposable
    {
        public MaterialRepository()
        {
        }

        public void Dispose()
        {
            //como não tem contexto não tem o que que dar dispose
            return;
        }

        public List<Material> SelectByFilter(string name, string ordPrice, bool unicByMarca, int numItems = 10)
        {
            try
            {
                var materiais = this.GetListObjectFromJson("Data/data.json");

                //filtra se o número de caracteres bate
                if (!String.IsNullOrWhiteSpace(name))
                    materiais = materiais.FindAll(mat => mat.Nome.ToLower().Contains(name.ToLower()) && name.Length > 2);
                //filtra se é acendente ou descedente a ordem dos precos
                if (!String.IsNullOrWhiteSpace(ordPrice))
                    switch (ordPrice)
                    {
                        case "ASC":
                            {
                                materiais = materiais.OrderBy(mat => mat.Preco).ToList();
                                break;
                            }
                        case "DESC":
                            {
                                materiais = materiais.OrderByDescending(mat => mat.Preco).ToList();
                                break;
                            }
                    }



                //adiciona a marca aos materiais
                using (var repository = new MarcaRepository())
                {
                    materiais.ForEach(mat =>
                    mat.Marca = repository.FindById(mat.IdMarca));
                }


                //filtra por marca ou não
                if (unicByMarca)
                {
                    var materiaisTemp = materiais;
                    materiais = new List<Material>();
                    materiaisTemp.ForEach(matTemp =>
                    {
                        if (materiais.FindIndex(mat => mat.IdMarca == matTemp.IdMarca) < 0)
                            materiais.Add(matTemp);
                    });
                }

                //seleciona um range
                numItems = (materiais.Count < numItems) ? materiais.Count : numItems;

                return materiais.GetRange(0, numItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
