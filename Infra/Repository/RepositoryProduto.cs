using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repository
{
    public class RepositoryProduto:RepositoryGeneric<Produto>, IProduto
    {
    }
}
