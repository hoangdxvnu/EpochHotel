using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HAHotel.Models;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDatabase _database;

        public ContactRepository(IDatabase database)
        {
            _database = database;
        }

        public bool Delete(int id)
        {
            _database.ExecuteNonQuery($"DELETE FROM Contacts WHERE Id = {id}", null, ExecuteTypeEnum.SqlQuery);

            return true;
        }

        public Contact GetById(int id)
        {
            var query = $"SELECT * FROM Contacts WHERE Id = {id}";
            var data = _database.ExecuteToTable(query, null, ExecuteTypeEnum.SqlQuery);
            if(data != null && data.Rows.Count > 0)
            {
                return SqlMapper<Contact>.Map(data).FirstOrDefault();
            }

            return new Contact();
        }

        public GridModel<Contact> GetListContact(RoomTypeRequest request)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_PageSize", request.PageSize);
            param.Add_Parameter("@_PageIndex", request.PageIndex);

            var data = _database.ExecuteToDataset("Contact_GetList", param, ExecuteTypeEnum.StoredProcedure);
            if (data != null && data.Tables.Count == 2)
            {
                return new GridModel<Contact>
                {
                    Data = SqlMapper<Contact>.Map(data.Tables[0]),
                    TotalRecord = (int)data.Tables[1].Rows[0]["TotalRecord"]
                };
            }

            return new GridModel<Contact>();
        }

        public bool Save(Contact contact)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_Id", contact.Id);
            param.Add_Parameter("@_Name", contact.Name);
            param.Add_Parameter("@_Phone", contact.Phone);
            param.Add_Parameter("@_Email", contact.Email);
            param.Add_Parameter("@_Content", contact.Content);

            var data = _database.ExecuteScalar<int>("Contact_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }
    }
}