using PersonalBloggingPlatformAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Application.Helpers
{
    public static class ErrorHandler
    {
        public static List<string> ArticleErrorHandler(Article article)
        {
            List<string> errors = new List<string>();

            if (article.Title is null)
            {
                errors.Add("A Title is required");
            } else if (article.Title.Length is < 3 or > 30)
            {
                errors.Add("Title length must be between 3 and 30 chars");
            }

            if (article.BodyText is null)
            {
                errors.Add("Body Text is required");
            } else if (article.BodyText.Length is < 30 or > 1000)
            {
                errors.Add("Body Text must be between 30 and 1000 chars");
            }

            return errors;
        }
    }
}
