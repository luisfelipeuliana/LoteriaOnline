using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.ApplicationCore.Model.Enum;

namespace LoteriaOnline.Infrastructure.Data
{
    public static class LoteriaOnlineData
    {
        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>
        {
            new Usuario
            {
                UsuarioId = 1,
                Nome = "João da Silva",
                Cpf = "49786054075",
                DataNascimento = new DateTime(1991, 10, 25),
                Email = "joao.silva@email.com",
                Login = "admin",
                Senha = "123456"
            },
            new Usuario
            {
                UsuarioId = 2,
                Nome = "Maria da Penha Pereira",
                Cpf = "48675954034",
                DataNascimento = new DateTime(1987, 4, 15),
                Email = "maria.penha@email.com",
                Login = "admin",
                Senha = "123456"
            }
        };

        public static List<Concurso> Concursos { get; set; } = new List<Concurso>
        {
            new Concurso
            {
                ConcursoId = 1,
                DataCriacao = new DateTime(2019, 1, 14),
                DataSorteio = new DateTime(2019, 1, 18),
                NumeroSorteado = "50-18-45-03-05-39",
                Acumulou = false,
                TipoConcurso = TipoConcursoEnum.MegaSena
            },
            new Concurso
            {
                ConcursoId = 2,
                DataCriacao = new DateTime(2019, 1, 21),
                DataSorteio = new DateTime(2019, 1, 24),
                NumeroSorteado = "",
                Acumulou = false,
                TipoConcurso = TipoConcursoEnum.MegaSena
            },
        };

        public static List<Jogo> Jogos { get; set; } = new List<Jogo>
        {
            new Jogo
            {
                JogoId = 1,
                ConcursoId = 1,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "04-22-33-47-49-60",                
            },
            new Jogo
            {
                JogoId = 2,
                ConcursoId = 1,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "03-12-36-40-45-51",
            },
            new Jogo
            {
                JogoId = 3,
                ConcursoId = 2,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "09-15-25-41-43-50",
            },
            new Jogo
            {
                JogoId = 4,
                ConcursoId = 2,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "04-09-14-24-33-48",
            },
            new Jogo
            {
                JogoId = 5,
                ConcursoId = 1,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "03-12-36-40-45-51",
            },
            new Jogo
            {
                JogoId = 6,
                ConcursoId = 2,
                UsuarioId = 1,
                DataJogo = new DateTime(2019, 1, 23),
                NumeroJogo = "09-11-19-21-36-56",
            },
            new Jogo
            {
                JogoId = 7,
                ConcursoId = 2,
                UsuarioId = 1,
                DataJogo = new DateTime(2019, 1, 24),
                NumeroJogo = "17-25-27-30-33-48",
            }

        };

        public static long UltimoConcursoId { get; set; } = Concursos.OrderByDescending(x => x.ConcursoId).FirstOrDefault()?.ConcursoId ?? 0;

        public static long UltimoUsuarioId { get; set; } = Usuarios.OrderByDescending(x => x.UsuarioId).FirstOrDefault()?.UsuarioId ?? 0;

        public static long UltimoJogoId { get; set; } = Jogos.OrderByDescending(x => x.JogoId).FirstOrDefault()?.JogoId ?? 0;

        public static long RecuperaUltimoConcursoId()
        {
            return ++UltimoConcursoId;
        }

        public static long RecuperaUltimoUsuarioId()
        {
            return ++UltimoUsuarioId;
        }

        public static long RecuperaUltimoJogoId()
        {
            return ++UltimoJogoId;
        }
    }
}
