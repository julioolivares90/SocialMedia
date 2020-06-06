using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;

        private readonly IMapper _mapper;

        public PostController(IPostRepository repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var posts = await _repository.GetPost();

            //con linq
            var PostsDto = _mapper.Map<IEnumerable<PostDTO>>(posts);

            return Ok(PostsDto);
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _repository.GetPostByID(id);
            if (post == null)
            {
                return Problem(detail: "No se encontro el post solicitado",statusCode:400,title:"Post no encontrado");
            }
            var postDto = _mapper.Map<PostDTO>(post);
            return Ok(postDto);
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            await _repository.InsertPost(post);
            return Ok(post);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeletePost(id);
            return Ok();
        }
    }
}
