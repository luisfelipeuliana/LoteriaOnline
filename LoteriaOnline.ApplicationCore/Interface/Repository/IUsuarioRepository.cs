﻿using LoteriaOnline.ApplicationCore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Interface.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario RecuperarPorLogin(string login);
    }
}