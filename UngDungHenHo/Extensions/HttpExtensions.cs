﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;
using UngDungHenHo.Helpers;

namespace UngDungHenHo.Extensions
{
    public static class HttpExtensions
    {
        public static void  AddPaginationHeader<T>(this HttpResponse response, PagedList<T> data)
        {
            var paginationHeader = new PaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader, jsonOptions));

            response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
