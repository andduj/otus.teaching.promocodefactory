﻿using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public List<RoleItemResponse> Roles { get; set; }

        public int AppliedPromocodesCount { get; set; }

        public static explicit operator EmployeeResponse(Employee employee)
        {
            var response = new EmployeeResponse()
            {
                Id = employee.Id,
                Email = employee.Email,               
                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            if (employee.Roles != null)
            {
                response.Roles = employee.Roles.Select(x => new RoleItemResponse()
                {
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
            }

            return response;
        }
    }
}