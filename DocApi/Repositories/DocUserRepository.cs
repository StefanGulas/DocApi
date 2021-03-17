using DocApi.DbContexts;
using DocApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Repositories
{
    public class DocUserRepository : IDocUserRepository, IDisposable
    {
        private readonly DocApiContext _context;

        public DocUserRepository(DocApiContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Document>> GetDocumentsAsync()
        {
            return await _context.Documents.ToListAsync();
        }
        public async Task<Document> GetDocumentAsync(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Document>> GetDocumentsByUserAsync(int userId)
        {
            return _context.Documents.Where(c => c.UserId == userId).ToList();
        }
        public bool DocumentNotFound(int id)
        {
            return (_context.Documents.Find(id) == null);
        }
        public void AddDocument(Document document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));

            _context.Add(document);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }
        public bool UserNotFound(int id)
        {
            return (_context.Users.Find(id) == null);
        }
        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            _context.Add(user);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
        //public IEnumerable<Document> GetAllDocuments()
        //{


        //    return _context.Courses
        //                .Where(c => c.AuthorId == authorId)
        //                .OrderBy(c => c.Title).ToList();
        //}

        //public void AddDocument(int? userId, Document document)
        //{
        //    if (userId == null)
        //    {
        //        throw new ArgumentNullException(nameof(userId));
        //    }

        //    if (document == null)
        //    {
        //        throw new ArgumentNullException(nameof(document));
        //    }
        //    document.UserId = (int)userId;
        //    _context.Documents.Add(document); 
        //}

        //public void DeleteCourse(Course course)
        //{
        //    _context.Courses.Remove(course);
        //}

        //public Course GetCourse(Guid authorId, Guid courseId)
        //{
        //    if (authorId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(authorId));
        //    }

        //    if (courseId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(courseId));
        //    }

        //    return _context.Courses
        //      .Where(c => c.AuthorId == authorId && c.Id == courseId).FirstOrDefault();
        //}

        //public IEnumerable<Course> GetCourses(Guid authorId)
        //{
        //    if (authorId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(authorId));
        //    }

        //    return _context.Courses
        //                .Where(c => c.AuthorId == authorId)
        //                .OrderBy(c => c.Title).ToList();
        //}

        //public void UpdateCourse(Course course)
        //{
        //    // no code in this implementation
        //}

        //public void AddAuthor(Author author)
        //{
        //    if (author == null)
        //    {
        //        throw new ArgumentNullException(nameof(author));
        //    }

        //    // the repository fills the id (instead of using identity columns)
        //    author.Id = Guid.NewGuid();

        //    foreach (var course in author.Courses)
        //    {
        //        course.Id = Guid.NewGuid();
        //    }

        //    _context.Authors.Add(author);
        //}

        //public bool AuthorExists(Guid authorId)
        //{
        //    if (authorId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(authorId));
        //    }

        //    return _context.Authors.Any(a => a.Id == authorId);
        //}

        //public void DeleteAuthor(Author author)
        //{
        //    if (author == null)
        //    {
        //        throw new ArgumentNullException(nameof(author));
        //    }

        //    _context.Authors.Remove(author);
        //}

        //public Author GetAuthor(Guid authorId)
        //{
        //    if (authorId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(authorId));
        //    }

        //    return _context.Authors.FirstOrDefault(a => a.Id == authorId);
        //}

        //public IEnumerable<Author> GetAuthors()
        //{
        //    return _context.Authors.ToList<Author>();
        //}

        //public IEnumerable<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        //{
        //    if (authorsResourceParameters == null)
        //    {
        //        throw new ArgumentNullException(nameof(authorsResourceParameters));
        //    }

        //    if (string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory)
        //         && string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
        //    {
        //        return GetAuthors();
        //    }

        //    var collection = _context.Authors as IQueryable<Author>;

        //    if (!string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory))
        //    {
        //        var mainCategory = authorsResourceParameters.MainCategory.Trim();
        //        collection = collection.Where(a => a.MainCategory == mainCategory);
        //    }

        //    if (!string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
        //    {

        //        var searchQuery = authorsResourceParameters.SearchQuery.Trim();
        //        collection = collection.Where(a => a.MainCategory.Contains(searchQuery)
        //            || a.FirstName.Contains(searchQuery)
        //            || a.LastName.Contains(searchQuery));
        //    }

        //    return collection.ToList();
        //}

        //public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds)
        //{
        //    if (authorIds == null)
        //    {
        //        throw new ArgumentNullException(nameof(authorIds));
        //    }

        //    return _context.Authors.Where(a => authorIds.Contains(a.Id))
        //        .OrderBy(a => a.FirstName)
        //        .OrderBy(a => a.LastName)
        //        .ToList();
        //}

        //public void UpdateAuthor(Author author)
        //{
        //    // no code in this implementation
        //}

        //public bool Save()
        //{
        //    return (_context.SaveChanges() >= 0);
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
