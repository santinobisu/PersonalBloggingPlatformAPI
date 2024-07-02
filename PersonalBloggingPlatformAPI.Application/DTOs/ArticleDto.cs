using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Application.DTOs
{
    public class ArticleDto
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; } = null!;
        public string BodyText { get; set; } = null!;
        public DateTime PublishingDate { get; set; }
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
