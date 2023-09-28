using System;
using System.Collections.Generic;

namespace MinhaApp.Interfaces
{
    public interface ICartaRepository
    {
        IEnumerable<CartaDoPapaiNoel> ListarTodas();

        void AdicionarCarta(CartaDoPapaiNoel carta);
    }
}

