using MongoDB.Driver;
using Moravia.Shouter.Core.DataAccess;
using System;


namespace Moravia.Shouter.Core.Services
{
    public class AccountServices
    {
        #region Login
        public static bool Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) == true || string.IsNullOrWhiteSpace(password) == true)
                return false;

            var user = AccountDataAccess.GetUserByEmail(email);
            

            if ( user != null && user.password == password )
                return true;
            else
                return false;
        }
        #endregion

        #region CreateUser
        public static void CreateUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ApplicationException("You should enter email and password to create a new User.");

            AccountDataAccess.InsertUser(email, password);

        }
        #endregion
    }
}
