using DocApi.Entities;
using DocApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DocApi.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocUserRepository _docUserRepository;

        public DocumentsController(IDocUserRepository docUserRepository)
        {
            _docUserRepository = docUserRepository ??
                throw new ArgumentNullException(nameof(docUserRepository));
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
            if (document.Name is string)
            {
                _docUserRepository.AddDocument(document);
            }      
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeDocument(int id, JsonPatchDocument<Document> document)
        {
            if (_docUserRepository.DocumentNotFound(id)) return NotFound();

            var updatedDocument = await _docUserRepository.ChangeDocumentInDb(id, document);

            return Ok(document);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            if (_docUserRepository.DocumentNotFound(id)) return NotFound();

            var document = await _docUserRepository.GetDocumentAsync(id);

            _docUserRepository.DeleteDocumentInDb(document);
            return Ok();
        }

    }
}