using System.Linq;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICommand<T>
    {

        void Incluir(T obj);
        void Alterar(T obj);

        void Excluir(T obj);
    }

    public interface IQuery<T>
    {
        IEnumerable<T> BuscarTodos();

        T BuscarPorId(int id);
    }
}
