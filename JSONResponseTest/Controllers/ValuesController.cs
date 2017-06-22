using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeroFormatter;
using ZeroFormatter.Formatters;

namespace JSONResponseTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var p1 = new YogaPose()
            {
                PoseId = 123456789,
                PoseName = "pose1"
            };
            var p2 = new YogaPose()
            {
                PoseId = 123456799,
                PoseName = "pose2"
            };
            var p3 = new YogaPose()
            {
                PoseId = 12346799,
                PoseName = "pose3"
            };
            List<YogaPose> yogList = new List<YogaPose>();
            yogList.Add(p1);
            yogList.Add(p2);
            yogList.Add(p3);

            var bytes = ZeroFormatterSerializer.Serialize(yogList);

            var myJson = System.Text.Encoding.UTF8.GetString(bytes);


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [ZeroFormattable]
    public class YogaPose
    {
        [Index(0)]
        public virtual long PoseId { get; set; }
        [Index(1)]
        public virtual string PoseName { get; set; }
    } 
}
