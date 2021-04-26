namespace Common.Shared.Base
{
    public interface IBaseListQuery
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SearchQuery { get; set; }
    }
}
