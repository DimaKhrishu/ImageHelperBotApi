using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageHelperBot.Models
{
    public class GetImageModel
    {
        public class Rootobject
        {

            public Result result { get; set; }
        }

        public class Result
        {

            public string file_path { get; set; }
        }
    }
}
