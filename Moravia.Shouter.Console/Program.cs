using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using MongoDB.Driver;
using MongoDB.Bson;
using Moravia.Shouter.Core.Services;


namespace Moravia.Shouter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterNewUser();
        }

        private static void RegisterNewUser()
        {
            string email="";
            string password;
            System.Console.WriteLine("New User");
            while(IsValid(email)!=true)
            {
                System.Console.WriteLine("Enter e-mail address:");
                email = System.Console.ReadLine();
            }
            System.Console.WriteLine("Enter a password:");
            password = System.Console.ReadLine();
            
            AccountServices.CreateUser(email,password);
        }

        private static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
