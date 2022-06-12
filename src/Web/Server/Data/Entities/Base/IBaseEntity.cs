using System.ComponentModel.DataAnnotations;

namespace QRCodeMenu.Server.Data.Entities.Base
{
    public interface IBaseEntity : IBaseEntity<int>
    {

    }

    public interface IBaseEntity<T> 
        where T : struct
    {
        [Key]
        public T Id { get; init; }
    }
}
