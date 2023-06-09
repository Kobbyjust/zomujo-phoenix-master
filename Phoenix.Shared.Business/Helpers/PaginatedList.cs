﻿using Newtonsoft.Json;

namespace Phoenix.Shared.Business.Helpers;

public class PaginatedList<T>
{
    public List<T> Data { get; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; }
    public int TotalCount { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public int From => ((CurrentPage - 1) * PageSize) + 1;
    public int To => (From + PageSize) - 1;
    public int CurrentPage { get; }

    public PaginatedList(List<T> data,
        int totalCount,
        int currentPage,
        int pageSize)
    {
        Data = data;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
    
    public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}

public class PaginatedCommand
{
    private int _pageSize = 10;
    private int _pageNumber = 1;
    private int _lastEntityId = 0;

    public int PageSize
    {
        get => _pageSize <= 0 ? 10 : _pageSize;
        set => _pageSize = value;
    }

    [JsonProperty("currentPage")]
    public int PageNumber
    {
        get => _pageNumber <= 0 ? 1 : _pageNumber;
        set => _pageNumber = value;
    }

    [JsonProperty("start")]
    public int Take { get; set; } = 0;
    public string? OrderBy { get; set; }
    public int Skip => (_pageNumber - 1) * _pageSize;

    public int LastEntityId
    {
        get => _lastEntityId < 0 ? 0 : _lastEntityId;
        set => _lastEntityId = value;
    }

    public Direction Direction { get; set; } = Direction.Forward;
    public string? Filter { get; set; }

    public string? Search { get; set; }
    public string? OtherJson { get; set; }
}

public enum Direction
{
    Backward = 0,
    Forward
}
