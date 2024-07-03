using PersonalBloggingPlatformAPI.Application.Interfaces.Tags;
using PersonalBloggingPlatformAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Application.Services
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<Tag>> HandleTags(List<int?> tagsId)
        {
            var tags = new List<Tag>();

            if (tagsId != null && tagsId.Any())
            {
                foreach (int tagId in tagsId)
                {
                    var tag = await _tagRepository.GetTagByIdAsync(tagId);
                    if (tag != null)
                    {
                        tags.Add(tag);
                    }
                }
            }

            return tags;
        }
    }
}
