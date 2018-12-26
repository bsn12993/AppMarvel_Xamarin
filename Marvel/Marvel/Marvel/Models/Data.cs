using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Models
{
    public class Data
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public List<Result> results { get; set; }
    }
}
