using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IApplicationProduto _applicationProduto;

        public ProdutoController(IApplicationProduto applicationProduto)
        {
            _applicationProduto = applicationProduto;
        }

        /// <summary>
        /// Método responsável por listar todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Tituto"] = "Lista de Produtos";
            var produtosModel = new List<ProdutoModel>();

            _applicationProduto.Listar()
                .ForEach(p => produtosModel.Add(new ProdutoModel() { Id = p.Id, NomeDoProduto = p.NomeDoProduto }));

            return View(produtosModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Salvar()
        {
            ViewData["Tituto"] = "Novo Produto";

            return View(new ProdutoModel());
        }

        /// <summary>
        /// Método responsável por cadastrar um novo produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Salvar(ProdutoModel produto)
        {
            ViewData["Titulo"] = "Novo Produto";
            _applicationProduto.Adicionar(new Produto() { Id = produto.Id, NomeDoProduto = produto.NomeDoProduto });

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            ViewData["Tituto"] = "Editar Produto";
            var produto = _applicationProduto.Listar().Find(p => p.Id == Id);

            return View(new ProdutoModel() { Id = produto.Id, NomeDoProduto = produto.NomeDoProduto });
        }

        /// <summary>
        /// Método responsável por atualizar um produto
        /// </summary>
        /// <param name="produtoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            ViewData["Titulo"] = "Editar Produto";
            var produto = _applicationProduto.Listar().Find(p => p.Id == produtoModel.Id);

            produto.NomeDoProduto = produtoModel.NomeDoProduto;

            _applicationProduto.Atualizar(produto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            ViewData["Titulo"] = "Deletar Produto";
            var produto = _applicationProduto.Listar().Find(p => p.Id == Id);

            return View(new ProdutoModel() { Id = produto.Id, NomeDoProduto = produto.NomeDoProduto });
        }

        /// <summary>
        /// Método responsável por excluir um produto
        /// </summary>
        /// <param name="produtoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Excluir(ProdutoModel produtoModel)
        {
            ViewData["Titulo"] = "Exclusão de Produto";
            _applicationProduto.Deletar(produtoModel.Id);

            return RedirectToAction("Index");
        }
    }
}
