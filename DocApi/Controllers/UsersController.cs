using AutoMapper;
using DocApi.Entities;
using DocApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IDocUserRepository _docUserRepository;
        private readonly IMapper _mapper;

        public UsersController(IDocUserRepository docUserRepository,
            IMapper mapper)
        {
            _docUserRepository = docUserRepository ??
                throw new ArgumentNullException(nameof(docUserRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user = await _docUserRepository.GetUsersAsync();
            return Ok(user);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _docUserRepository.GetUserAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        //[HttpGet()]
        //[HttpHead]
        //public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
        //    [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        //{
        //    var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);
        //    return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        //}

        //[HttpGet("{authorId}", Name ="GetAuthor")]
        //public IActionResult GetAuthor(Guid authorId)
        //{
        //    var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

        //    if (authorFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        //}

        //[HttpPost]
        //public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        //{
        //    var authorEntity = _mapper.Map<Entities.Author>(author);
        //    _courseLibraryRepository.AddAuthor(authorEntity);
        //    _courseLibraryRepository.Save();

        //    var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
        //    return CreatedAtRoute("GetAuthor",
        //        new { authorId = authorToReturn.Id },
        //        authorToReturn);
        //}

        //[HttpOptions]
        //public IActionResult GetAuthorsOptions()
        //{
        //    Response.Headers.Add("Allow", "GET,OPTIONS,POST");
        //    return Ok();
        //}

        //[HttpDelete("{authorId}")]
        //public ActionResult DeleteAuthor(Guid authorId)
        //{
        //    var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

        //    if (authorFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    _courseLibraryRepository.DeleteAuthor(authorFromRepo);

        //    _courseLibraryRepository.Save();

        //    return NoContent();
        //}
    }
}
