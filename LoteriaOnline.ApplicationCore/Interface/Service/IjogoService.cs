using LoteriaOnline.ApplicationCore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Interface.Service
{
    public interface IJogoService
    {
        Jogo Cadastrar(Jogo jogo);
        void Excluir(long jogoId);
        IEnumerable<Jogo> RecuperaTodos();
        Jogo RecuperarPorId(long jogoId);
        IEnumerable<int> GerarJogoAleatorio(int quantidadeNumeros, int numeroMinimo, int numeroMaximo);
        List<int> RecuperaNumeroJogo(long jogoId);
        IEnumerable<Jogo> RecuperarJogosGanhadores(long concursoId);
        List<int> RecuperarListaNumeroJogo(string numeroJogo);
        void AtualizarPremiu(long jogoId, int acertos);
    }
}
