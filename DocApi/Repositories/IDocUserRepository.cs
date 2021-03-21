using DocApi.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocApi.Repositories
{
    public interface IDocUserRepository
    {
        Task<IEnumerable<Entities.Document>> GetDocumentsAsync();
        Task<Document> GetDocumentAsync(int id);
        Task<IEnumerable<Document>> GetDocumentsByUserAsync(int userId);
        public bool Save();
        public bool DocumentNotFound(int id);
        public void AddDocument(Document document);
        void ChangeDocumentInDb(Document document, Document existingDocument);
        void DeleteDocumentInDb(Document document);

        Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserAsync(int id);
        bool UserNotFound(int id);
        void AddUser(Entities.User user);
        void ChangeUserInDb(User user, User existingUser);
        void DeleteUserInDb(User user);

        Task<IEnumerable<Role>> GetRolesAsync();
        public Task<Role> GetRoleAsync(int id);
        bool RoleNotFound(int id);
        void AddRole(Role role);
        public Task<JsonPatchDocument<Role>> ChangeRoleInDb(int id, JsonPatchDocument<Role> role);
        void DeleteRoleInDb(Role role);

    }
}
