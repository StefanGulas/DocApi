﻿using DocApi.DbContexts;
using DocApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocApi.Repositories
{
    public interface IDocUserRepository
    {
        Task<IEnumerable<Entities.Document>> GetDocumentsAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        //IEnumerable<Document> GetDocumentsByUser(int userId);
        //Document GetDocument(int userId, int documentId);
        //void AddDocument(Guid userId, Document document);
        //void UpdateDocument(Document document);
        //void DeleteDocument(Document document);
        //IEnumerable<User> GetUsers();
        //User GetUser(int userId);
        //IEnumerable<User> GetUsers(IEnumerable<int> userIds);
        //void AddUser(User user);
        //void DeleteUser(User user);
        //void UpdateUser(User user);
        //bool UserExists(int userId);
        //bool Save();
    }
}
