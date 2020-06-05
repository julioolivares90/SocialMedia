using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _Context;
        public PostRepository(SocialMediaContext context)
        {
            _Context = context;
        }

        

        public async Task<IEnumerable<Post>> GetPost()
        {
            var publicaciones = await  _Context.Posts.ToListAsync();

            return publicaciones;
        }
    }
}
