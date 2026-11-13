using System;
using System.Collections.Generic;
using System.Linq;
using Day3_sv.Models;
namespace Day3_sv.Services
{
    public class ProductService
    {
        private readonly List<Product> _allProducts;

        public ProductService()
        {
            _allProducts = Enumerable.Range(1, 100).Select(i => new Product { Id = i, Name = $"Laptop {i}" }).ToList();
        }
        public (List<Product> Items, int TotalPages) Search(string keyword, int page, int pageSize)
        {
            var query = _allProducts.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return (items, totalPages);
        }
        // Lấy sản phẩm theo ID
        public Product? GetById(int id)
        {
            return _allProducts.FirstOrDefault(p => p.Id == id);
        }
        // Cập nhật sản phẩm
        public bool Update(Product product)
        {
            var existingProduct = _allProducts
                .FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;

            return true;
        }
        // Xóa sản phẩm
        public bool Delete(int id)
        {
            var product = _allProducts
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            _allProducts.Remove(product);

            return true;
        }
        // Thêm sản phẩm
        public void Create(Product product)
        {
            int newId = _allProducts.Any()
                ? _allProducts.Max(p => p.Id) + 1
                : 1;

            product.Id = newId;

            _allProducts.Add(product);
        }
    }
}
