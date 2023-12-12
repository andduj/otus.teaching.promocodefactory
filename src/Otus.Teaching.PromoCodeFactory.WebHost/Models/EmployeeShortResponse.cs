using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using System;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class EmployeeShortResponse
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }

        public string Email { get; set; }


        public static explicit operator EmployeeShortResponse(Employee employee)
        {
            return new EmployeeShortResponse()
            {
                Id = employee.Id,
                Email = employee.Email,
                FullName = employee.FullName,
            };
        }
    }
}