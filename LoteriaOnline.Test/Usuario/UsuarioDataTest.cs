﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LoteriaOnline.ApplicationCore.Model.Entity;

namespace LoteriaOnline.Test
{
    
    public class NovoUsuarioDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Usuario { Cpf = "13752976780", DataNascimento = DateTime.Now, Email = "felipedaf@gmail.com", Nome = "Luis felipe", Login = "teste", Senha = "123", Administrador = true} },

            new object[] { new Usuario { UsuarioId = 1000, Cpf = "137529545480", DataNascimento = DateTime.Now, Email = "felipe@gmail.com", Nome = "Luis Paulo", Login = "teste123", Senha = "123456", Administrador = false } },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class EditarUsuarioDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Usuario { UsuarioId = 2, Cpf = "13752976780", DataNascimento = DateTime.Now, Email = "felipedaf@gmail.com", Nome = "Luis felipe", Login = "teste1", Senha = "1234", Administrador = true } },
            new object[] { new Usuario { UsuarioId = 1, Cpf = "137529545480", DataNascimento = DateTime.Now, Email = "felipe@gmail.com", Nome = "Luis Paulo", Login = "teste123", Senha = "123456", Administrador = true} },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
