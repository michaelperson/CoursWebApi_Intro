using FirstWebApi.Models;
using System.Collections.Generic;

namespace FirstWebApi.Interfaces
{
    public interface IContext
    {
        List<Employee> Employees { get; set; }
    }
}