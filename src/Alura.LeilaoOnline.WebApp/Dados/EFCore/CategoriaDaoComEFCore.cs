using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoComEFCore : ICategoriaDao
    {

        private readonly AppDbContext _context;

        public CategoriaDaoComEFCore(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return _context.Categorias
                 .Include(c => c.Leiloes);
        }

        public Categoria BuscarPorId(int id)
        {
            return _context.Categorias
                 .Include(c => c.Leiloes)
                 .First(c => c.Id == id);
        }

    }
}
