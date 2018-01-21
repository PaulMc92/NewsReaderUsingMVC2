using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsReader.Models
{
    public class JsonModels
    {
        //public Guid ID
        //{
        //    get
        //    {
        //        Guid id = Guid.NewGuid();
        //        return id;
        //    }
        //}
        public string Status { get; set; }
        public string TotalResults { get; set; }
        public IEnumerable<ArticleModels> Articles { get; set; }
    }
}   