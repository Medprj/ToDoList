using System.Collections.Generic;
using Raven.Client;
using Raven.Client.Document;

namespace ToDoList.Models
{
    public class RavenDb
    {
        private readonly DocumentStore _store;
        private readonly IDocumentSession _session;

        public RavenDb()
        {
            _store = new DocumentStore { ConnectionStringName = "RavenDB"};
            _store.Initialize();
            _session = _store.OpenSession();
        }

        public IEnumerable<T> GetAll<T>() where T : Models.IModel
        {
            IEnumerable<T> item = _session.Query<T>();
            
            return item;
        }

        public void Delete<T>(T item) where T: Models.IModel
        {
            var obj = _session.Load<T>(item.Id);
            _session.Delete(obj);
            _session.SaveChanges();
        }

        public void Save<T>(T item) where T : Models.IModel
        {
            _session.Store(item);
            _session.SaveChanges();
        }
    }
}