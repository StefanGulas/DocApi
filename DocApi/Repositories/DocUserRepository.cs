using DocApi.DbContexts;
using DocApi.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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

        }
        //public void ChangeDocumentInDb(Document document, Document existingDocument)
        //{
        //    existingDocument.Id = document.Id;
        //    if (document.Name is string) existingDocument.Name = document.Name;
        //    if (document.Größe > 0) existingDocument.Größe = document.Größe;
        //    if (document.Typ is string) existingDocument.Typ = document.Typ;
        //    if (document.UserId > 0) existingDocument.UserId = document.UserId;

        //    _context.Update(document);
        //    _context.SaveChanges();
        //}
        public async Task<JsonPatchDocument<Document>> ChangeDocumentInDb(int id, JsonPatchDocument<Document> document)
        {
            var existingDocument = await _context.Documents.FindAsync(id);
            if (existingDocument != null)
            {
                document.ApplyTo(existingDocument);
                _context.SaveChanges();
            }
            return document;
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
        public async Task<JsonPatchDocument<User>> ChangeUserInDb(int id, JsonPatchDocument<User> user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser != null)
            {
                user.ApplyTo(existingUser);
                _context.SaveChanges();
            }
            return user;
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

        public async Task<JsonPatchDocument<Role>> ChangeRoleInDb(int id, JsonPatchDocument<Role> role)
        {
            var existingRole = await _context.Roles.FindAsync(id);
            if(existingRole != null)
            {
                role.ApplyTo(existingRole);
                _context.SaveChanges();
            }

            return role;
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
            }
        }



    }
}
