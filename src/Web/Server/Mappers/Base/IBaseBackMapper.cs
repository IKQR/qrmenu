namespace QRCodeMenu.Server.Mappers.Base
{
    public interface IBaseBackMapper<TEntity, TDto>
    {
        TEntity MapBack(TDto dto);
        IEnumerable<TEntity> MapBack(IEnumerable<TDto> dtos)
        {
            return dtos.Select(MapBack);
        }

        TEntity MapUpdate(TEntity entity, TDto dto);

    }
}
