using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models;
using DL.DatabaseSpecific;
using DL.EntityClasses;
using DL.HelperClasses;
using DL.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using QueryParameters = BookStoreApp.API.Models.QueryParameters;

namespace BookStoreApp.API.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : CommonEntityBase
{
    private readonly IDataAccessAdapter context;
    private readonly LinqMetaData linq;
    private readonly IMapper mapper;
    public GenericRepository(IDataAccessAdapter context, LinqMetaData linq, IMapper mapper)
    {
        this.context = context;
        this.linq = linq;
        this.mapper = mapper;
    }
    
    public async Task<T> AddAsync(T entity)
    {
        await context.SaveEntityAsync(entity);

        return entity;
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        await context.DeleteEntityAsync(entity);
    }
    public async Task<bool> Exists(int id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }
    public async Task<List<T>> GetAllAsync()
    {
        var retCollection = new EntityCollection<T>();
        context.FetchEntityCollection(retCollection, null);
        return retCollection.ToList();
    }
    public async Task<T> GetAsync(int? id)
    {
        if (id == null)
        {
            return null;
        }

        return (await GetAllAsync())
            .FirstOrDefault(zz => (int)zz.Fields["Id"].CurrentValue == id.Value);
    }

    public async Task<VirtualiseResponse<TResult>> GetAllAsync<TResult>(QueryParameters queryParam) where TResult : class
    {
        var totalSize = linq.GetQueryableForEntity<T>().Count();
        var query = linq.GetQueryableForEntity<T>()
            .Skip(queryParam.StartIndex)
            .Take(queryParam.PageSize)
            .ToList();

        var items = query.Select(zz => mapper.Map<TResult>(zz)).ToList();

        return new VirtualiseResponse<TResult>
        {
            Items = items, 
            TotalSize = totalSize
        };
    }
    public async Task UpdateAsync(T entity)
    {
        await context.SaveEntityAsync(entity);
    }
}