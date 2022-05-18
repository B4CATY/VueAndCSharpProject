using CSharpBackEnd.Models.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBackEnd.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParametrInResponse<T>(this HttpContext httpContext,
            IQueryable<T> queryble, PaginationDTO model)
        {
            double count = await queryble.CountAsync();
            double padesQuantity = Math.Ceiling(count / model.PageSize);
            if (padesQuantity < model.Page)
                throw new Exception();
            httpContext.Response.Headers.Add("X-Total-Count", padesQuantity.ToString());
        }
    }
}
