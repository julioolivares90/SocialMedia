using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPost();
        Task<Post> GetPostByID( int id);

        Task InsertPost(Post post);

        Task<bool> DeletePost(int id);

        Task<bool> UpdatePost(Post post);

    }
}
