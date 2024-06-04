namespace Common.Interfaces
{
    public interface IBaseDTO<TModel, TDto> where TDto : class, new()
    {
        TDto ToDto(TModel model);
        TModel ToModel();
    }
}
