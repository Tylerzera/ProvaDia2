using System.Collections.Generic;

namespace Application
{
    public interface ICartaService
    {
        List<CartaDoPapaiNoel> ListarCartas();
        CartaDoPapaiNoel CriarCarta(CartaDoPapaiNoel novaCarta);
    }
}
