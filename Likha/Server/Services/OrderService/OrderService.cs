﻿using Likha.Server.Data;
using Likha.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likha.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _data;

        public OrderService(DataContext data)
        {
            _data = data;
        }

        List<Order> Orders = new List<Order>();

        public async Task<List<Order>> AddProduct(Order newOrder)
        {
            await _data.Orders.AddAsync(newOrder);
            await _data.SaveChangesAsync();
            List<Order> Orders = await _data.Orders.ToListAsync();
            return Orders;
        }

        public async Task<List<Order>> GetOrderByBuyer(int UserId)
        {
            return Orders = await _data.Orders.Where(o => o.UserId == UserId).ToListAsync();
        }
    }
}