using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsReader.Models;

namespace NewsApp.Utils
{
    public class Helpers
    {
        public static ArticleModels JsonToArticleModel(IEnumerable<ArticleModels> article, bool isDetail)
        {
            ArticleModels temp = null;
            if (article == null)
            {
                
            }
            else
            { 
            
            //foreach (var x in article)
            //{
                temp = new ArticleModels()
                {
                    Description = article.FirstOrDefault().Description,
                    Author = article.FirstOrDefault().Author,
                    //ID = article.FirstOrDefault().ID,
                    PublishedAt = article.FirstOrDefault().PublishedAt,
                    Title = article.FirstOrDefault().Title,
                    Source = article.FirstOrDefault().Source,
                    URL = article.FirstOrDefault().URL,
                    URLToImage = article.FirstOrDefault().URLToImage
                };
            }
            return temp;
        }
    }
}