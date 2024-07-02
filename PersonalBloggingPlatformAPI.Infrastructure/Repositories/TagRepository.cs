using PersonalBloggingPlatformAPI.Application.Interfaces.Tags;
using PersonalBloggingPlatformAPI.Domain.Entities;
using PersonalBloggingPlatformAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _appDbContext;
        public TagRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Tag?> GetTagByIdAsync(int tagId)
        {
            return await _appDbContext.Tags.FindAsync(tagId);
        }
    }
}
