using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HAHotel.Helpers;
using HAHotel.Models;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDatabase _database;

        public AccountRepository(IDatabase database)
        {
            _database = database;
        }

        public bool CreateAccount(Account account)
        {
            if (account == null || string.IsNullOrEmpty(account.UserName) || string.IsNullOrEmpty(account.Password))
            {
                return false;
            }

            var param = new SqlServerParameter();
            param.Add_Parameter("@_UserName", account.UserName);
            param.Add_Parameter("@_Password", account.Password);
            param.Add_Parameter("@_Type", (int)account.AccountType);

            var data = _database.ExecuteScalar<int>("Account_Create", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }

        public Account Validate(Account account)
        {
            if (account == null || string.IsNullOrEmpty(account.UserName) || string.IsNullOrEmpty(account.Password))
                return null;

            var query = $"SELECT * FROM Account WHERE LOWER(UserName) = '{account.UserName.ToLower()}'";
            var data = _database.ExecuteToTable(query, null, Common.ExecuteTypeEnum.SqlQuery);
            if (data == null || data.Rows.Count <= 0)
            {
                return null;
            }

            var tempAcc = SqlMapper<Account>.Map(data).FirstOrDefault();
            if (!AccountUtils.VerifyPassword(tempAcc.Password, account.Password))
            {
                return null;
            }

            return new Account
            {
                AccountId = tempAcc.AccountId,
                UserName = tempAcc.UserName,
                AccountType = tempAcc.AccountType,
                CreatedDate = tempAcc.CreatedDate
            };
        }
    }
}