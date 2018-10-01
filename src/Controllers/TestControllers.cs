using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ODataBase
{
    [Produces("application/json")]
    public class TestController : ODataController
    {
        private readonly TestContext _context;
 
        public TestController(TestContext context) => this._context = context;

        [EnableQuery]
        public IQueryable<Test> Get() => this._context.Test;
    }
}
