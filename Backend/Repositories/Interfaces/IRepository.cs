using Backend.Models;
using System.Collections;
using System.Collections.Generic;

namespace Backend.Repositories.Interfaces
{
    public interface IRepository
    {
        IEnumerable<GuestBookModel> Get();
        GuestBookModel Get(int Id);
        int Insert (GuestBookModel guestBookModel);
        int Update (GuestBookModel guestBookModel, int Id);
        int Delete (int Id);
    }
}
