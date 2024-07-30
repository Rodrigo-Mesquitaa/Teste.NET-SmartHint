using System.Collections.Generic;

public class PagedResult<T>
{
    public List<T> Results { get; set; }
    public int Total { get; set; }
}
