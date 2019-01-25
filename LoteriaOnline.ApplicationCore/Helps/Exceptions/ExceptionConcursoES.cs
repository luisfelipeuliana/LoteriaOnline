using System;
using System.Collections.Generic;
using System.Text;

namespace ConcursoES.ApplicationCore.Exceptions
{
    public class ExceptionConcursoES : Exception
    {
        public ExceptionConcursoES(string mensagem) : base(mensagem)
        {
        }
    }
}
