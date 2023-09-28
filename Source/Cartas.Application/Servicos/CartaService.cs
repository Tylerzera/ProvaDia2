using System.Collections.Generic;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain;

namespace Application.Servicos
{
    public class CartaService : ICartaService
    {
        private readonly ICartaRepository _cartaRepository;
        private readonly IMapper _mapper;

        public CartaService(ICartaRepository cartaRepository, IMapper mapper)
        {
            _cartaRepository = cartaRepository;
            _mapper = mapper;
        }

        public List<CartaViewModel> ListarCartas()
        {
            var cartas = _cartaRepository.LerCartasDoArquivo();
            return _mapper.Map<List<CartaViewModel>>(cartas);
        }

        public CartaViewModel CriarCarta(CartaViewModel novaCarta)
        {
            var cartas = _cartaRepository.LerCartasDoArquivo();

            var novaCartaEntidade = _mapper.Map<CartaDoPapaiNoel>(novaCarta);

            cartas.Add(novaCartaEntidade);
            _cartaRepository.EscreverCartasNoArquivo(cartas);

            return novaCarta;
        }
    }
}
