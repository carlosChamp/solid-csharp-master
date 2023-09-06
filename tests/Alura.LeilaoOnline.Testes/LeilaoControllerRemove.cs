using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Controllers;
using Xunit.Sdk;
using System.Reflection;
using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.Testes
{
    public class LeilaoControllerRemove
    {
        MockUpData.MockAdminService mock = new MockUpData.MockAdminService();

        public LeilaoControllerRemove()
        {
            Leilao LeilaoEmPregao = new Leilao()
            {
                Id = 1,
                Categoria = new Categoria()
                {
                    Descricao = "Teste",
                    Id = 1,
                    Imagem = ""
                },
                Descricao = "Teste Leil�o",
                IdCategoria = 1,
                Inicio = DateTime.Now,
                Situacao = SituacaoLeilao.Pregao,
                Titulo = "Teste 1 - Leil�o teste 1"
            };
            Leilao LeilaoEmRascunho = new Leilao()
            {
                Id = 2,
                Categoria = new Categoria()
                {
                    Descricao = "Teste",
                    Id = 1,
                    Imagem = ""
                },
                Descricao = "Teste Leil�o 2",
                IdCategoria = 1,
                Inicio = DateTime.Now,
                Situacao = SituacaoLeilao.Rascunho,
                Titulo = "Teste 1 - Leil�o teste 1"
            };


            mock.CadastraLeilao(LeilaoEmPregao);
            mock.CadastraLeilao(LeilaoEmRascunho);
        }

        [Fact]
        public void DadoLeilaoInexistenteEntaoRetorna404()
        {
            // arrange
            var idLeilaoInexistente = 11232; // preciso entrar no banco para saber qual � inexistente!! teste deixa de ser autom�tico...
            var actionResultEsperado = typeof(NotFoundResult);
            var controller = new LeilaoController(mock);

            // act
            var result = controller.Remove(idLeilaoInexistente);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmPregaoEntaoRetorna405()
        {
            // arrange
            var idLeilaoEmPregao = 1; // qual leilao est� em preg�o???!! 
            var actionResultEsperado = typeof(StatusCodeResult);
            var controller = new LeilaoController(mock);

            // act
            var result = controller.Remove(idLeilaoEmPregao);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmRascunhoEntaoExcluiORegistro()
        {
            // arrange
            var idLeilaoEmRascunho = 2; // qual leilao est� em rascunho???!!
            var actionResultEsperado = typeof(NoContentResult);
            var controller = new LeilaoController(mock);

            // act
            var result = controller.Remove(idLeilaoEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

    }

    
}
