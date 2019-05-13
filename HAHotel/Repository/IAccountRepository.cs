using HAHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HAHotel.Repository
{
    public interface IAccountRepository
    {
        Account Validate(Account account);

        bool CreateAccount(Account account);
    }
}