using At.API.Data;
using At.API.Models;
using At.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace At.API.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public CategoriaRepositorio(SistemaVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            CategoriaModel CategoriaPorId = await BuscarPorId(id);

            if (CategoriaPorId == null)
            {
                throw new Exception($"Categoria do Id: {id} não foi encontrada.");
            }

            _dbContext.Categorias.Remove(CategoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do Id: {id} não encontrada.");
            }

            categoriaPorId.Nome = categoria.Nome;
            categoriaPorId.Status = categoria.Status;

            _dbContext.Categorias.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoriaPorId;
        }

        public async Task<CategoriaModel> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriaModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
    }
}
