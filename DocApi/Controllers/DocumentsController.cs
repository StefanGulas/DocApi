using AutoMapper;
using DocApi.Entities;
using DocApi.Models;
using DocApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocUserRepository _docUserRepository;
        private readonly IMapper _mapper;

        public DocumentsController(IDocUserRepository docUserRepository,
            IMapper mapper)
        {
            _docUserRepository = docUserRepository ??
                throw new ArgumentNullException(nameof(docUserRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _docUserRepository.GetDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDocument(int id)
        {
            if (_docUserRepository.DocumentNotFound(id)) return NotFound();

            var document = await _docUserRepository.GetDocumentAsync(id);

            return Ok(document);
        }

        [HttpGet]
        [Route("user/{userid}")]
        public async Task<IActionResult> GetDocumentsByUser(int userid)
        {
            var documents = await _docUserRepository.GetDocumentsByUserAsync(userid);
            return Ok(documents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument(Document document)
        {
            if (document.Name != null) _docUserRepository.AddDocument(document);

            await _docUserRepository.SaveChangesAsync();

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeDocument(int id, Document document)
        {
            if (_docUserRepository.DocumentNotFound(id)) return NotFound();

            var existingDocument = await _docUserRepository.GetDocumentAsync(id);
            existingDocument.Id = id;
            if (document.Name != null) existingDocument.Name = document.Name;
            if (document.Größe > 0) existingDocument.Größe = document.Größe;
            if (document.Typ != null) existingDocument.Typ = document.Typ;
            if (document.UserId > 0) existingDocument.UserId = document.UserId;
            _docUserRepository.ChangeDocumentInDb(existingDocument);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            if (_docUserRepository.DocumentNotFound(id)) return NotFound();

            var document = await _docUserRepository.GetDocumentAsync(id);

            _docUserRepository.DeleteDocumentInDb(document);
            return Ok();
        }
        //[HttpGet("{courseId}", Name = "GetCourseForAuthor")]
        //public ActionResult<CourseDto> GetCourseForAuthor(Guid authorId, Guid courseId)
        //{
        //    if (!_courseLibraryRepository.AuthorExists(authorId))
        //    {
        //        return NotFound();
        //    }

        //    var courseForAuthorFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);

        //    if (courseForAuthorFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<CourseDto>(courseForAuthorFromRepo));
        //}

        //[HttpPost]
        //public ActionResult<CourseDto> CreateCourseForAuthor(
        //    Guid authorId, CourseForCreationDto course)
        //{
        //    if (!_courseLibraryRepository.AuthorExists(authorId))
        //    {
        //        return NotFound();
        //    }

        //    var courseEntity = _mapper.Map<Entities.Course>(course);
        //    _courseLibraryRepository.AddCourse(authorId, courseEntity);
        //    _courseLibraryRepository.Save();

        //    var courseToReturn = _mapper.Map<CourseDto>(courseEntity);
        //    return CreatedAtRoute("GetCourseForAuthor",
        //        new { authorId = authorId, courseId = courseToReturn.Id }, 
        //        courseToReturn);
        //}

        //[HttpPut("{courseId}")]
        //public IActionResult UpdateCourseForAuthor(Guid authorId, 
        //    Guid courseId, 
        //    CourseForUpdateDto course)
        //{
        //    if (!_courseLibraryRepository.AuthorExists(authorId))
        //    {
        //        return NotFound();
        //    }

        //    var courseForAuthorFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);

        //    if (courseForAuthorFromRepo == null)
        //    {
        //        var courseToAdd = _mapper.Map<Entities.Course>(course);
        //        courseToAdd.Id = courseId;

        //        _courseLibraryRepository.AddCourse(authorId, courseToAdd);

        //        _courseLibraryRepository.Save();

        //        var courseToReturn = _mapper.Map<CourseDto>(courseToAdd);

        //        return CreatedAtRoute("GetCourseForAuthor",
        //            new { authorId, courseId = courseToReturn.Id },
        //            courseToReturn);
        //    }

        //    // map the entity to a CourseForUpdateDto
        //    // apply the updated field values to that dto
        //    // map the CourseForUpdateDto back to an entity
        //    _mapper.Map(course, courseForAuthorFromRepo);

        //    _courseLibraryRepository.UpdateCourse(courseForAuthorFromRepo);

        //    _courseLibraryRepository.Save();
        //    return NoContent();
        //}

        //[HttpPatch("{courseId}")]
        //public ActionResult PartiallyUpdateCourseForAuthor(Guid authorId, 
        //    Guid courseId,
        //    JsonPatchDocument<CourseForUpdateDto> patchDocument)
        //{
        //    if (!_courseLibraryRepository.AuthorExists(authorId))
        //    {
        //        return NotFound();
        //    }

        //    var courseForAuthorFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);

        //    if (courseForAuthorFromRepo == null)
        //    {
        //        var courseDto = new CourseForUpdateDto();
        //        patchDocument.ApplyTo(courseDto, ModelState);

        //        if (!TryValidateModel(courseDto))
        //        {
        //            return ValidationProblem(ModelState);
        //        }

        //        var courseToAdd = _mapper.Map<Entities.Course>(courseDto);
        //        courseToAdd.Id = courseId;

        //        _courseLibraryRepository.AddCourse(authorId, courseToAdd);
        //        _courseLibraryRepository.Save();

        //        var courseToReturn = _mapper.Map<CourseDto>(courseToAdd);

        //        return CreatedAtRoute("GetCourseForAuthor",
        //            new { authorId, courseId = courseToReturn.Id }, 
        //            courseToReturn);
        //    }

        //    var courseToPatch = _mapper.Map<CourseForUpdateDto>(courseForAuthorFromRepo);
        //    // add validation
        //    patchDocument.ApplyTo(courseToPatch, ModelState);

        //    if (!TryValidateModel(courseToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(courseToPatch, courseForAuthorFromRepo);

        //    _courseLibraryRepository.UpdateCourse(courseForAuthorFromRepo);

        //    _courseLibraryRepository.Save();

        //    return NoContent();
        //}

        //[HttpDelete("{courseId}")]
        //public ActionResult DeleteCourseForAuthor(Guid authorId, Guid courseId)
        //{
        //    if (!_courseLibraryRepository.AuthorExists(authorId))
        //    {
        //        return NotFound();
        //    }

        //    var courseForAuthorFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);

        //    if (courseForAuthorFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    _courseLibraryRepository.DeleteCourse(courseForAuthorFromRepo);
        //    _courseLibraryRepository.Save();

        //    return NoContent();
        //}

        //public override ActionResult ValidationProblem(
        //    [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        //{
        //    var options = HttpContext.RequestServices
        //        .GetRequiredService<IOptions<ApiBehaviorOptions>>();
        //    return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        //}
    }
}