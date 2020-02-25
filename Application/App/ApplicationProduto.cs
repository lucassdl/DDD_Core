using Application.Interface;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.App
{
    public class ApplicationProduto : IApplicationProduto
    {
        IProduto _IProduto;

        public ApplicationProduto(IProduto iProduto)
        {
            _IProduto = iProduto;
        }

        public void Adicionar(Produto entidade)
        {
            _IProduto.Adicionar(entidade);
        }

        public void Atualizar(Produto entidade)
        {
            _IProduto.Atualizar(entidade);
        }

        public void Deletar(int id)
        {
            _IProduto.Deletar(id);
        }

        public List<Produto> Listar()
        {
            return _IProduto.Listar();
        }
    }
}
