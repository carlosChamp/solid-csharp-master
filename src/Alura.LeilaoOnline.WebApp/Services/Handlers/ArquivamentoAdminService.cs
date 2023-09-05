using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {
        readonly IAdminService _adminServiceDefault;

        public ArquivamentoAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _adminServiceDefault = new DefaultAdminService(leilaoDao, categoriaDao);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _adminServiceDefault.CadastraLeilao(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _adminServiceDefault.ConsultaCategorias();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _adminServiceDefault.ConsultaLeilaoPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _adminServiceDefault
                .ConsultaLeiloes()
                .Where(l=> l.Situacao != SituacaoLeilao.Arquivado);
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            _adminServiceDefault.FinalizaPregaoDoLeilaoComId(id);
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            _adminServiceDefault.IniciaPregaoDoLeilaoComId(id);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _adminServiceDefault.ModificaLeilao(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && 
                leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _adminServiceDefault.ModificaLeilao(leilao);
            }
                
        }
    }
}
