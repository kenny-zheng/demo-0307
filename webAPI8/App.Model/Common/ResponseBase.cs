namespace App.Model
{
    public class ResponseBase<T>
    {
        //public int PageSize { get; set; }
        //public int PageNum { get; set; }
        //public long TotalPages { get; set; }
        public long TotalItems { get; set; }
        public T Entries { get; set; }
        public string Message { get; set; } = string.Empty;
        public EnumStatusCode StatusCode { get; set; } = EnumStatusCode.Fail;
    }

    public enum EnumStatusCode
    {
        Success = 0,
        Fail = 1,
        LoginFail = 30001
    }

}
