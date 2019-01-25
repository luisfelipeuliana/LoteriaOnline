using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entity);
        void Editar(TEntity entity);
        void Excluir(TEntity entity);
        IEnumerable<TEntity> RecuperaTodos();
        TEntity RecuperarPorId(long id);
    }
}
