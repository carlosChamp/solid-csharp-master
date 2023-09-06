using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Testes.MockUpData
{
    internal class MockAdminService : IAdminService
    {
        public List<Leilao> ListaLeiloes { get; set; } = new List<Leilao>();    

        public MockAdminService() 
        {

        }
        public void CadastraLeilao(Leilao leilao)
        {
            ListaLeiloes.Add(leilao);
        }


        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return new List<Categoria>(){
                new Categoria()
                    {
                        Descricao = "Teste",
                        Id = 1,
                        Imagem = ""
                    },

            };
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return new Leilao()
            {
                Id = id,
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
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return ListaLeiloes;
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            
        }

        public void ModificaLeilao(Leilao leilao)
        {
            
        }

        public void RemoveLeilao(Leilao leilao)
        {
            
        }
    }
}
