using ProjetoUFCD1790.App.Data;
using ProjetoUFCD1790.App.Model;
using System.Collections.Generic;

namespace ProjetoUFCD1790.App.Service
{
    public class CategoriaService
    {
        private readonly CategoriaRepository categoriaRepository = new CategoriaRepository();
        public List<CategoriaModel> getCategorias()
        {
            

            return categoriaRepository.obterCategorias();
        }
    }
}
