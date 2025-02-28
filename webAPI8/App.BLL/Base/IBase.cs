namespace App.BLL
{
    public interface IBase
    {
        ResponseBase<List<EnumResponse>> GetEnumList<T>(int Type = 0);

        Task<ResponseBase<List<EnumResponse>>> GetFunction(int Type = 0);
    }
}