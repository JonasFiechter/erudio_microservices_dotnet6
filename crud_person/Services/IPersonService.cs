using crud_person.Model;
using System.Collections.Generic;

namespace crud_person.Services
{
    public interface IPersonService
    {
        void Create();
        void Update();
        Person FindByID(long id);
        string FindAll();
        void Delete(long id);
    }
}