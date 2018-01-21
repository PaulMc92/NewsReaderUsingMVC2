using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsReader.Models
{
    public class ArticleModels
    {
        //public Guid ID
        //{
        //    get
        //    {
        //        Guid id = Guid.NewGuid();
        //        return id;
        //    }
        //}
        public ArticleSourceModels Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string URLToImage { get; set; }
        public DateTime PublishedAt { get; set; }

    }
}