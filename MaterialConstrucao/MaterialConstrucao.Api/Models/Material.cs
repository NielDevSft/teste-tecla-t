using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialConstrucao.Api.Models
{
    public class Material
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Marca Marca { get; set; }

    }
}
