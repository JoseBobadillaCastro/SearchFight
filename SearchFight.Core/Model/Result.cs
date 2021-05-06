using System;
using System.Collections.Generic;
using System.Text;
namespace SearchFight.Core.Model
{
    public class Result
    {
        public string query { get; set; }
        public string engineName { get; set; }
        public int total { get; set; }
    }
}