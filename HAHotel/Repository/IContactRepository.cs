using HAHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAHotel.Repository
{
    public interface IContactRepository
    {
        GridModel<Contact> GetListContact(RoomTypeRequest request);

        bool Save(Contact roomType);

        bool Delete(int id);

        Contact GetById(int id);
    }
}
