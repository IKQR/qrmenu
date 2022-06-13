using Microsoft.AspNetCore.Mvc;
using QRCodeMenu.Server.Data;

namespace QRCodeMenu.Server.Controllers.Base
{
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly DataDbContext _data;

        public BaseApiController(DataDbContext dataContext)
        {
            this._data = dataContext;
        }
    }
}
