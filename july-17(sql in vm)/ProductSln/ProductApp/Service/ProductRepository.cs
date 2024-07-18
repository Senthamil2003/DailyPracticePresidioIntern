using Microsoft.EntityFrameworkCore;
using ProductApp.Context;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApp.Service
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Product cannot be null");

            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding the Product. " + ex);
            }
        }

        public async Task<Product> Delete(int key)
        {
            try
            {
                var product = await Get(key);
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting the Product. " + ex);
            }
        }

        public async Task<Product> Get(int key)
        {
            try
            {
                return await _context.Products.SingleOrDefaultAsync(u => u.ProductId == key)
                    ?? throw new Exception($"No Product found with given id {key}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching data from Product. " + ex);
            }
        }

        public async Task<IEnumerable<Product>> Get()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching the Products. " + ex);
            }
        }

        public async Task<Product> Update(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Product cannot be null");

            try
            {
                var product = await Get(item.ProductId);
                _context.Entry(product).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating the Product. " + ex);
            }
        }
    }
}
