using System.Collections.Generic;

namespace Domain.Interfaces.Generic
{
    public interface IGeneric<T> where T : class
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Deletar(int id);
        List<T> Listar();
    }
}
