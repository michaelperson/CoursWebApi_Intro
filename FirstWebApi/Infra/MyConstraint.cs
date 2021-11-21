using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks; 

namespace FirstWebApi.Infra
{
    public class MyConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, 
                          RouteDirection routeDirection)
        {
            if (values.ContainsKey("Id"))
            {
                try
                {
                    return (int.Parse(values["Id"].ToString())) > 0;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
