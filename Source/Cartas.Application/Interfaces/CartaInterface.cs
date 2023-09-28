using System.Collections.Generic;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICartaService
    {
        List<CartaViewModel> ListarCartas();
        CartaViewModel CriarCarta(CartaViewModel novaCarta);
    }
}
