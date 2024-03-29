﻿using API.DTO.Product;
using Entity;

namespace API.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext _Context;

        public ProductRepository(DatabaseContext context)
        {
            _Context = context;
        }

        public IEnumerable<Products> Get()
        {
            return _Context.Products.ToList();
        }

        public Products GetById(int id)
        {
            return _Context.Products.SingleOrDefault(product => product.Id == id) 
                ?? throw new KeyNotFoundException("No existe Producto con ese Id");
        }

        public Products Create(ProductDTO product)
        {
            Products result = new()
            {
                Name = product.Name,
                CategoryId = product.CategoryId
            };
            _Context.Products.Add(result);
            _Context.SaveChanges();
            return result;
        }

        public Products Update(ProductDTO data, int id)
        {
            Products product= _Context.Products.SingleOrDefault(p => p.Id == id) 
                ?? throw new KeyNotFoundException("No existe el Producto para editar");
        
            product.Name = data.Name ?? product.Name;
            product.CategoryId = data.CategoryId ?? product.CategoryId;
            _Context.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            Products products = _Context.Products.Single(product => product.Id == id);
            _Context.Products.Remove(products);
            _Context.SaveChanges();
            return;
        }
    }
}
