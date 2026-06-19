using Catteria.Application.DTOs;
using Catteria.Application.Interfaces;
using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(MapToDto);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : MapToDto(product);
        }

        public async Task<IEnumerable<ProductDto>> GetFeaturedAsync()
        {
            var products = await _productRepository.GetFeaturedAsync();
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetByCategoryAsync(categoryId);
            return products.Select(MapToDto);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CoverImageUrl = dto.CoverImageUrl,
                CategoryId = dto.CategoryId,
                IsFeatured = dto.IsFeatured,
                CreatedAt = DateTime.Now
            };

            await _productRepository.AddAsync(product);

            return MapToDto(product);
        }

        public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.CoverImageUrl = dto.CoverImageUrl;
            product.CategoryId = dto.CategoryId;
            product.IsFeatured = dto.IsFeatured;
            product.CreatedAt = DateTime.Now;

            await _productRepository.UpdateAsync(product);
            return MapToDto(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }

            await _productRepository.DeleteAsync(id);
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _productRepository.CountAsync();
        }

        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CoverImageUrl = product.CoverImageUrl,
                CategoryId = product.CategoryId,
                IsFeatured = product.IsFeatured,
                CreatedAt = product.CreatedAt
            };

        }
    }
}
