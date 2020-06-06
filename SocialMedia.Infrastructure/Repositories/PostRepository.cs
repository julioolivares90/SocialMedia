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

        public async Task DeletePost(int id)
        {
            var post = await _Context.Posts.FindAsync(id);
            if (post != null)
            {
                _Context.Posts.Remove(post);
                await _Context.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<Post>> GetPost()
        {
            var publicaciones = await  _Context.Posts.ToListAsync();

            return publicaciones;
        }

        public  async Task<Post> GetPostByID(int id)
        {
            var post = await _Context.Posts.FindAsync(id);
            return post;
        }

        public Task<Post> GetPostByID()
        {
            throw new NotImplementedException();
        }

        public async Task InsertPost(Post post)
        {
            await _Context.Posts.AddAsync(post);
            await _Context.SaveChangesAsync();
        }

        public async Task UpdatePost(Post post)
        {
             _Context.Posts.Update(post);
            await _Context.SaveChangesAsync();
        }
    }
}
