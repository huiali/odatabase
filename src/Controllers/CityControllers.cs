using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ODataBase
{
    [Produces("application/json")]
    public class CityController : ODataController
    {
        private readonly WorldContext _context;
 
        public CityController(WorldContext context) => this._context = context;

        [EnableQuery]
        public IQueryable<City> Get() => this._context.City;
    }
}
