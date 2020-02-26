using Domain.Interfaces.Generic;
using Infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private DbContextOptionsBuilder<Context> _OptionsBuilder;

        public RepositoryGeneric()
        {
            _OptionsBuilder = new DbContextOptionsBuilder<Context>();
        }

        ~RepositoryGeneric()
        {
            Dispose(false);
        }

        public void Adicionar(T entidade)
        {
            using (var banco = new Context(_OptionsBuilder.Options))
            {
                banco.Add(entidade);
                banco.SaveChanges();
            }
        }

        public void Atualizar(T entidade)
        {
            using (var banco = new Context(_OptionsBuilder.Options))
            {
                banco.Update(entidade);
                banco.SaveChanges();
            }
        }

        public List<T> Listar()
        {
            using (var banco = new Context(_OptionsBuilder.Options))
            {
                return banco.Set<T>().ToList();
            }
        }

        public void Deletar(int id)
        {
            using(var banco = new Context(_OptionsBuilder.Options))
            {
                var entidade = banco.Set<T>().Find(id);
                banco.Remove(entidade);
                banco.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool status)
        {
            if (!status)
                return;
        }
    }
}
