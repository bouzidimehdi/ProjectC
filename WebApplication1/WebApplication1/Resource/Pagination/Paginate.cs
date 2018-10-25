using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Resource.Pagination;

namespace WebApplication1.Resource.Pagination
{
    using WebApplication1.Resource.Option;

    public static class Paginate
    {
        public static Option<Page<T>> GetPage<T>(this Microsoft.EntityFrameworkCore.DbSet<T> List, int Page_index, int page_size, Func<T, object> order_by_selector)
            where T : class
        {
            T[] res = List.OrderBy(order_by_selector)
                .Skip(Page_index * page_size)
                .Take(page_size)
                .ToArray();

            if (res == null || res.Length == 0)
                return new Empty<Page<T>>();

            var tot_items = List.Count();

            var tot_pages = tot_items / page_size;

            if (tot_items < page_size) tot_pages = 1;

            return new Some<Page<T>>(new Page<T>(){Index = Page_index, Items = res, TotalPages = tot_pages});
        }

        public static Option<Page<T>> GetPageSearch<T>(List<T> List, int Page_index, int page_size, Func<T, object> order_by_selector)
            where T : class
        {
            T[] res = List.OrderBy(order_by_selector)
                .Skip(Page_index * page_size)
                .Take(page_size)
                .ToArray();

            if (res == null || res.Length == 0)
                return new Empty<Page<T>>();

            var tot_items = List.Count();

            var tot_pages = tot_items / page_size;

            if (tot_items < page_size) tot_pages = 1;

            return new Some<Page<T>>(new Page<T>() { Index = Page_index, Items = res, TotalPages = tot_pages });
        }
    }
}