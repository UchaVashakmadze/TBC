﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Domain.SeedWork;

namespace Common.Shared.Base
{
    public interface IBaseListModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SearchQuery { get; set; }
    }

    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PagedList()
        {
        }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static async Task<PagedList<T>> Create<E>(
            IGenericRepository<E> repository,
            IQueryable<E> data,
            int? pageNumber,
            int? pageSize,
            IMapper mapper,
            CancellationToken cancellationToken) where E : class
        {
            var count = await repository.CountAsync(data, cancellationToken);
            pageSize ??= 10;
            pageSize = pageSize > 10 ? 10 : pageSize;
            pageNumber = (pageNumber != null && pageNumber > 0) ? pageNumber.Value : 1;
            var skip = (pageNumber.Value - 1) * pageSize;
            data = data.Skip(skip.Value).Take(pageSize.Value);
            var items = mapper.Map<List<T>>(await repository.ToListAsync(data, cancellationToken));
            return new PagedList<T>(items, count, pageNumber.Value, pageSize.Value);
        }

        public static PagedList<TE> Create<TE>(
            IQueryable<TE> data,
            int? pageNumber,
            int? pageSize) where TE : class
        {
            var count = data.Count();
            pageSize ??= 10;
            pageSize = pageSize > 10 ? 10 : pageSize;
            pageNumber = (pageNumber != null && pageNumber > 0) ? pageNumber.Value : 1;
            var skip = (pageNumber.Value - 1) * pageSize;
            data = data.Skip(skip.Value).Take(pageSize.Value);
            return new PagedList<TE>(data.ToList(), count, pageNumber.Value, pageSize.Value);
        }
    }

}
