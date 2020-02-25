using System.Collections.Generic;

namespace Application.Interface.Generic
{
    public interface IApplicationGeneric<T> where T : class
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Deletar(int id);
        List<T> Listar();
    }
}
