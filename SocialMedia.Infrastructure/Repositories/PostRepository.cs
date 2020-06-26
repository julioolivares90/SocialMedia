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

        public async Task<bool> DeletePost(int id)
        {
            var currentPost =  await GetPostByID(id);
                _Context.Posts.Remove(currentPost);
                var filas = await _Context.SaveChangesAsync();

                return filas > 0;  
        }

        public async Task<IEnumerable<Post>> GetPost()
        {
            var publicaciones = await  _Context.Posts.ToListAsync();

            return publicaciones;
        }

        public  async Task<Post> GetPostByID(int id)
        {
            var post = await _Context.Posts.FirstOrDefaultAsync(x=>x.PostId == id);
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

        public async Task< bool> UpdatePost(Post post)
        {
            var currentPost = await GetPostByID(post.PostId);

            currentPost.Date = post.Date;
            currentPost.Description = post.Description;
            currentPost.Image = post.Image;

           var rs = await _Context.SaveChangesAsync();

            return rs > 0;

        }
    }
}
