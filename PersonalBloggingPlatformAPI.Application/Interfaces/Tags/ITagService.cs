using PersonalBloggingPlatformAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Application.Interfaces.Tags
{
    public interface ITagService
    {
        Task<List<Tag>> HandleTags(List<int?> tagsId);
    }
}
