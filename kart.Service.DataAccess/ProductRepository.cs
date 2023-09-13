using kart.Core.Dto.RequestModel;
using kart.Service.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public class ProductRepository: IProductRepository
    {

        private readonly kartContext _context;

        public ProductRepository(kartContext context)
        {
            _context = context;
        }

        void IProductRepository.AddNewProduct(ProductRequestModel product)
        {
            _context.Products.Add(new Product
            {
                ProductName = product.ProductName,
                ProductDesc = product.ProductDesc,
                CategoryId = product.CategoryId,
                StockQuantity = product.StockQuantity,
                Discount = product.Discount,
                Price = product.Price,
                UserId = product.UserId
            });

            _context.SaveChanges();
        }

        void IProductRepository.DeleteProduct(int productid)
        {
            var itemToRemove = _context.Products.Where(r => r.ProductId == productid)
                           .FirstOrDefault();

            _context.Products.Remove(itemToRemove);

            _context.SaveChanges();
        }

        void IProductRepository.ModifyProduct(int productid, string itemToModify, string value)
        {
            var item = _context.Products.Where(r => r.ProductId == productid)
                                .FirstOrDefault();

            switch (itemToModify.ToLower())
            {
                case "productname":
                    item.ProductName = value; break;

                case "product description":
                    item.ProductDesc = value; break;

                case "stockquantity":
                    item.StockQuantity = int.Parse(value); break;

                case "discount":
                    item.Discount = int.Parse(value); break;

                case "price":
                    item.Price = decimal.Parse(value); break;
            }

            _context.SaveChanges();
        }
    }
}
