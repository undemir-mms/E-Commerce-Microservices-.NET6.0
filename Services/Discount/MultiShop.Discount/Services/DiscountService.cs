﻿using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate,IsActive,ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public Task DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCouponDto> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }
    }
}
