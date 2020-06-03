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
    public class PublicacionRepository : IPublicacionRepository
    {
        private readonly SocialMediaContext _Context;
        public PublicacionRepository(SocialMediaContext context)
        {
            _Context = context;
        }

        

        public async Task<IEnumerable<Publicacion>> GetPublicaciones()
        {
            var publicaciones = await  _Context.Publicacion.ToListAsync();

            return publicaciones;
        }
    }
}
