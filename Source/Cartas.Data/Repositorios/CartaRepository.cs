using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Cartas.Domain.Entities;
using Cartas.Domain.Interfaces;

namespace Revisao.Data.Repositories
{
    public class CartasRepository : ICartasRepository
    {
        private readonly string _cartasCaminhoArquivo;

        public CartasRepository()
        {
            _cartasCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "cartas.json");
        }

        public void AdicionarCartaDoPapaiNoel(CartaDoPapaiNoel carta)
        {
            var cartas = LerCartasDoArquivo();
            cartas.Add(carta);
            EscreverCartasNoArquivo(cartas);
        }

        public IEnumerable<CartaDoPapaiNoel> ObterTodasAsCartasDoPapaiNoel()
        {
            return LerCartasDoArquivo();
        }

        private List<CartaDoPapaiNoel> LerCartasDoArquivo()
        {
            if (!File.Exists(_cartasCaminhoArquivo))
                return new List<CartaDoPapaiNoel>();
            string json = File.ReadAllText(_cartasCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<CartaDoPapaiNoel>>(json);
        }

        private void EscreverCartasNoArquivo(List<CartaDoPapaiNoel> cartas)
        {
            string json = JsonConvert.SerializeObject(cartas);
            File.WriteAllText(_cartasCaminhoArquivo, json);
        }
    }
}
