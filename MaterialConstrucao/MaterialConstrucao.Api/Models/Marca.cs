using System;

namespace MaterialConstrucao.Api.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Guid CodigoMarca { get; set; }
    }
}
