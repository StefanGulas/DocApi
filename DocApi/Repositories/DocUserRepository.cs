﻿using DocApi.DbContexts;
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
            var newDocument = new Document();
            newDocument.Name = document.Name;
            if (document.Typ == "string" || document.Typ == null)  newDocument.Typ = "";
            else newDocument.Typ = document.Typ;
            if (document.ZeitpunktDesHochladens.Year == 0) newDocument.ZeitpunktDesHochladens = new(2021,01,01);
            else newDocument.ZeitpunktDesHochladens = document.ZeitpunktDesHochladens;
            if (newDocument.Größe >= 0) newDocument.Größe = document.Größe;
            else newDocument.Größe = 100;
            if (document.UserId > 0) newDocument.UserId = document.UserId;
            else newDocument.UserId = 1;

            _context.Documents.Add(newDocument);
            _context.SaveChanges();


            //_context.Documents.Add(new Document
            //{
            //    Name = newDocument.Name,
            //    Größe = newDocument.Größe,
            //    Typ = newDocument.Typ,
            //    ZeitpunktDesHochladens = newDocument.ZeitpunktDesHochladens,
            //    UserId = newDocument.UserId
            //});
        }
        public void ChangeDocumentInDb(Document document, Document existingDocument)
        {
            existingDocument.Id = document.Id;
            if (document.Name is string) existingDocument.Name = document.Name;
            if (document.Größe > 0) existingDocument.Größe = document.Größe;
            if (document.Typ is string) existingDocument.Typ = document.Typ;
            if (document.UserId > 0) existingDocument.UserId = document.UserId;

            _context.Update(document);
            _context.SaveChanges();
        }

        public void DeleteDocumentInDb(Document document)
        {
            _context.Remove(document);
            _context.SaveChanges();

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
            var newUser = new User();
            newUser.Nachname = user.Nachname;
            if (user.Anrede == "string" || user.Anrede == null) newUser.Anrede = "";
            else newUser.Anrede = user.Anrede;
            if (user.Email == "string" || user.Email == null) newUser.Email = "";
            else newUser.Email = user.Email;
            if (user.Password == "string" || user.Password == null) newUser.Password = "";
            else newUser.Password = user.Password;
            if (user.RoleId > 0) newUser.RoleId = user.RoleId;
            else newUser.RoleId = 1;

            _context.Users.Add(newUser);
            _context.SaveChanges();
            
            
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }
        public void ChangeUserInDb(User user, User existingUser)
        {
            existingUser.Id = user.Id;
            if (user.Anrede is string) existingUser.Anrede = user.Anrede;
            if (user.Vorname is string) existingUser.Vorname = user.Vorname;
            if (user.Nachname is string) existingUser.Nachname = user.Nachname;
            if (user.Password is string) existingUser.Password = user.Password;
            if (user.RoleId > 0) existingUser.RoleId = user.RoleId;
            
            //_context.Update(existingUser);
            _context.SaveChanges();
        }

        public void DeleteUserInDb(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();

        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(c => c.RoleId == id);
        }
        public bool RoleNotFound(int id)
        {
            return (_context.Roles.Find(id) == null);
        }
        public void AddRole(Role role)
        {
            var newRole = new Role();
            newRole.RoleName = role.RoleName;
            if (role.Beschreibung == "string" || role.Beschreibung == null) newRole.Beschreibung = "";

            _context.Roles.Add(newRole);
            _context.SaveChanges();


        }

        public void ChangeRoleInDb(Role role, Role existingRole)
        {
            existingRole.RoleId = role.RoleId;
            if (role.RoleName is string) existingRole.RoleName = role.RoleName;
            if (role.Beschreibung is string) existingRole.Beschreibung = role.Beschreibung;

            _context.SaveChanges();
        }

        public void DeleteRoleInDb(Role role)
        {
            _context.Remove(role);
            _context.SaveChanges();

        }
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

        //public Task<bool> SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}
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

    }
}
