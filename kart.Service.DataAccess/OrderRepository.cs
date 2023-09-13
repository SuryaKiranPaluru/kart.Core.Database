using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public class OrderRepository : IOrderRepository
    {

        private readonly kartContext _context;

        public OrderRepository(kartContext context)
        {
            _context = context;
        }

        void IOrderRepository.PlaceOrder(OrderRequestModel order)
        {
           
            var cartItems = (from ci in _context.Carts
                             where ci.UserId == order.UserId
                             select ci).ToList();

            decimal totalAmount = 0;

            Random rnd = new Random();  

            foreach (var cartItem in cartItems)
            {
                var product = _context.Products.Where(p => p.ProductId == cartItem.ProductId).FirstOrDefault();

                if (product.StockQuantity < cartItem.Quantity)
                {
                    throw new Exception("Out of stock");
                }
                var buyPrice = (product.Price - ((product.Price * product.Discount) / 100));
                totalAmount += buyPrice * cartItem.Quantity;

                
            }

            var TransId = rnd.Next(10000, 99999);

            _context.Add(new Transaction
            {
                TransactionId = TransId,
                TransactionType = order.PaymentMethod,
                TransactionStatus = "Success"
            }); 
            
            
            _context.Add(new Order
            {
                UserId = order.UserId,
                ShipmentStatus = "CONFIRMED",
                TotalAmount = totalAmount,
                TransactionId = TransId,
                ShipmentAddress = order.ShipmentAddress,
                OrderDate = DateTime.Now
            });

            _context.SaveChanges();

            var createdOrder = _context.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault();
            int orderId = createdOrder.OrderId;

            foreach (var cartItem in cartItems)
            {
                _context.Add(new OrderItem
                {
                    OrderId = orderId,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                });

            }

            _context.SaveChanges();

        }
    }

    
    
}
