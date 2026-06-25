using System;
using System.Collections.Generic;
using System.Text;
using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catteria.Infraestructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // Campo privado que armazena a instância do DbContext
        private readonly CatteriaDbContext _context;

        // Construtor do repositório de categorias
        public CategoryRepository(CatteriaDbContext context)
        {
            // Recebe o DbContext via injeção de dependência
            // e atribui ao campo privado para uso nos métodos da classe
            _context = context;
        }

        // Método responsável por buscar todas as categorias cadastradas no banco de dados
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            // Acessa a tabela de categorias
            return await _context.Categories
                .Include(c => c.Products) // Carrega também os produtos relacionados a cada categoria
                .OrderBy(c => c.Name)  // Ordena as categorias em ordem alfabética pelo nome
                .ToListAsync(); // Executa a consulta e retorna o resultado como uma lista assíncrona
        }

        // Método responsável por buscar uma categoria específica pelo seu ID
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Products)  // Carrega também os produtos relacionados à categoria
                .FirstOrDefaultAsync(c => c.Id == id); // Procura a primeira categoria que possui o ID informado
                                                       // Retorna null caso não encontre nenhuma categoria
        }

        // Método responsável por cadastrar uma nova categoria no banco de dados
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category); // Adiciona a categoria recebida ao DbSet Categories
            await _context.SaveChangesAsync(); // Persiste as alterações no banco de dados
        }

        // Método responsável por atualizar uma categoria existente no banco de dados
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);  // Marca a entidade como modificada no contexto do Entity Framework
            await _context.SaveChangesAsync(); // Salva as alterações realizadas no banco de dados
        }

        // Método responsável por remover uma categoria do banco de dados pelo ID
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);  // Busca a categoria pelo ID no banco de dados
            
            if (category != null) // Verifica se a categoria existe antes de tentar remover
            {
                _context.Categories.Remove(category); // Remove a entidade do contexto do Entity Framework
                await _context.SaveChangesAsync(); // Persiste a exclusão no banco de dados
            }
        }

        // Método responsável por contar o total de categorias no banco de dados
        public async Task<int> CountAsync()
        {
            return await _context.Categories.CountAsync(); // Executa uma contagem diretamente no banco de dados
        }
    }
}
