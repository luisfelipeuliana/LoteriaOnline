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
                Nome = "Administrador",
                Cpf = "49786054075",
                DataNascimento = new DateTime(1991, 10, 25),
                Email = "administrador@email.com",
                Login = "admin",
                Senha = "123456",
                Administrador = true
            },
            new Usuario
            {
                UsuarioId = 2,
                Nome = "Maria da Penha Pereira",
                Cpf = "68348138102",
                DataNascimento = new DateTime(1987, 4, 15),
                Email = "maria.penha@email.com",
                Login = "usuario2",
                Senha = "123456"
            },
            new Usuario
            {
                UsuarioId = 3,
                Nome = "João da Silva",
                Cpf = "49786054075",
                DataNascimento = new DateTime(1987, 2, 2),
                Email = "joao.silva@email.com",
                Login = "usuario3",
                Senha = "123456"
            },
            new Usuario
            {
                UsuarioId = 4,
                Nome = "Murilo Caio Gabriel Cavalcanti",
                Cpf = "71743571305",
                DataNascimento = new DateTime(1995, 9, 15),
                Email = "murilocaiogabrielcavalcanti@gmail.com",
                Login = "usuario4",
                Senha = "123456"
            },
            new Usuario
            {
                UsuarioId = 5,
                Nome = "Carlos Eduardo Luís Corte Real",
                Cpf = "23104795940",
                DataNascimento = new DateTime(1970, 12, 22),
                Email = "carloseduardoluiscortereal@mail.com.br",
                Login = "usuario5",
                Senha = "123456"
            },
            new Usuario
            {
                UsuarioId = 6,
                Nome = "Ruan Yuri Antonio Souza",
                Cpf = "35912919943",
                DataNascimento = new DateTime(1977, 4, 30),
                Email = "rruanyuriantoniosouza@gmail.com.br",
                Login = "usuario6",
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
                NumeroSorteado = "3-5-18-39-45-50",
                Acumulou = false,
                TipoConcurso = TipoConcursoEnum.MegaSena,              
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
                DataJogo = new DateTime(2019, 1, 18),
                NumeroJogo = "3-5-18-39-45-50",                
                Premiu = PremiuEnum.Sena,
            },
            new Jogo
            {
                JogoId = 2,
                ConcursoId = 1,
                UsuarioId = 3,
                DataJogo = new DateTime(2019, 1, 17),
                NumeroJogo = "3-10-18-39-45-50",
                Premiu = PremiuEnum.Quina,
            },
            new Jogo
            {
                JogoId = 3,
                ConcursoId = 1,
                UsuarioId = 3,
                DataJogo = new DateTime(2019, 1, 16),
                NumeroJogo = "3-10-18-39-44-50",
                Premiu = PremiuEnum.Quina,
            },
            new Jogo
            {
                JogoId = 4,
                ConcursoId = 1,
                UsuarioId = 4,
                DataJogo = new DateTime(2019, 1, 15),
                NumeroJogo = "9-10-18-22-45-50",
                Premiu = PremiuEnum.Quadra
            },
            new Jogo
            {
                JogoId = 5,
                ConcursoId = 1,
                UsuarioId = 5,
                DataJogo = new DateTime(2019, 1, 18),
                NumeroJogo = "3-15-18-40-45-50",
                Premiu = PremiuEnum.Quadra,
            },
            new Jogo
            {
                JogoId = 6,
                ConcursoId = 1,
                UsuarioId = 6,
                DataJogo = new DateTime(2019, 1, 18),
                NumeroJogo = "7-17-20-43-56-59",
                Premiu = PremiuEnum.NaoPremiado,
            },
            new Jogo
            {
                JogoId = 7,
                ConcursoId = 1,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 17),
                NumeroJogo = "11-16-18-43-45-56",
                Premiu = PremiuEnum.NaoPremiado,
            },
            new Jogo
            {
                JogoId = 8,
                ConcursoId = 1,
                UsuarioId = 5,
                DataJogo = new DateTime(2019, 1, 16),
                NumeroJogo = "1-10-19-44-45-51",
                Premiu = PremiuEnum.NaoPremiado,
            },
            new Jogo
            {
                JogoId = 9,
                ConcursoId = 1,
                UsuarioId = 6,
                DataJogo = new DateTime(2019, 1, 15),
                NumeroJogo = "8-19-21-45-58-59",
            },
            new Jogo
            {
                JogoId = 10,
                ConcursoId = 1,
                UsuarioId = 4,
                DataJogo = new DateTime(2019, 1, 15),
                NumeroJogo = "2-4-18-30-45-59",
            },


            new Jogo
            {
                JogoId = 11,
                ConcursoId = 2,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "3-5-18-39-45-50",
                Premiu = PremiuEnum.Sena,
            },
            new Jogo
            {
                JogoId = 12,
                ConcursoId = 2,
                UsuarioId = 3,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "3-10-18-39-45-50",
            },
            new Jogo
            {
                JogoId = 13,
                ConcursoId = 2,
                UsuarioId = 3,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "3-10-18-39-44-50",
            },
            new Jogo
            {
                JogoId = 14,
                ConcursoId = 2,
                UsuarioId = 4,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "9-10-18-22-45-50",
            },
            new Jogo
            {
                JogoId = 15,
                ConcursoId = 2,
                UsuarioId = 5,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "3-15-18-40-45-50",
            },
            new Jogo
            {
                JogoId = 16,
                ConcursoId = 2,
                UsuarioId = 6,
                DataJogo = new DateTime(2019, 1, 23),
                NumeroJogo = "7-17-20-43-56-59",
            },
            new Jogo
            {
                JogoId = 17,
                ConcursoId = 2,
                UsuarioId = 2,
                DataJogo = new DateTime(2019, 1, 24),
                NumeroJogo = "11-16-18-43-45-56",
            },
            new Jogo
            {
                JogoId = 18,
                ConcursoId = 2,
                UsuarioId = 5,
                DataJogo = new DateTime(2019, 1, 22),
                NumeroJogo = "1-10-19-44-45-51",
            },
            new Jogo
            {
                JogoId = 19,
                ConcursoId = 2,
                UsuarioId = 6,
                DataJogo = new DateTime(2019, 1, 23),
                NumeroJogo = "8-19-21-45-58-59",
            },
            new Jogo
            {
                JogoId = 20,
                ConcursoId = 2,
                UsuarioId = 4,
                DataJogo = new DateTime(2019, 1, 24),
                NumeroJogo = "2-4-18-30-45-59",
            },
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
