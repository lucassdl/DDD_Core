using Application.Interface;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.App
{
    public class ApplicationProduto : IApplicationProduto
    {
        private readonly IProduto _produto;

        public ApplicationProduto(IProduto produto)
        {
            _produto = produto;
        }

        public void Adicionar(Produto produto)
        {
            _produto.Adicionar(produto);
        }

        public void Atualizar(Produto produto)
        {
            _produto.Atualizar(produto);
        }

        public void Deletar(int id)
        {
            _produto.Deletar(id);
        }

        public List<Produto> Listar()
        {
            return _produto.Listar();
        }
    }
}
