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
                Descricao = "Teste Leilão",
                IdCategoria = 1,
                Inicio = DateTime.Now,
                Situacao = SituacaoLeilao.Pregao,
                Titulo = "Teste 1 - Leilão teste 1"
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
                Descricao = "Teste Leilão 2",
                IdCategoria = 1,
                Inicio = DateTime.Now,
                Situacao = SituacaoLeilao.Rascunho,
                Titulo = "Teste 1 - Leilão teste 1"
            };


            mock.CadastraLeilao(LeilaoEmPregao);
            mock.CadastraLeilao(LeilaoEmRascunho);
        }

        [Fact]
        public void DadoLeilaoInexistenteEntaoRetorna404()
        {
            // arrange
            var idLeilaoInexistente = 11232; // preciso entrar no banco para saber qual é inexistente!! teste deixa de ser automático...
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
            var idLeilaoEmPregao = 1; // qual leilao está em pregão???!! 
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
            var idLeilaoEmRascunho = 2; // qual leilao está em rascunho???!!
            var actionResultEsperado = typeof(NoContentResult);
            var controller = new LeilaoController(mock);

            // act
            var result = controller.Remove(idLeilaoEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

    }

    
}
