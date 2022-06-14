namespace QRCodeMenu.Server.Dto.Mappers.Base
{
    public interface IBaseDtoMapper<TEntity, TDto>
    {
        TDto Map(TEntity entity);
        IEnumerable<TDto> Map(IEnumerable<TEntity> entities)
        {
            return entities.Select(Map);
        }
    }
}
