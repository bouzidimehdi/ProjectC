using Model;
using System;
using System.Linq;
using Security;

namespace Authentication
{
    public class expres_methods_login
    {
        // Conectie met de webshopcontext.
        private readonly WebshopContext _context;
        SHA SHA;
        public expres_methods_login(WebshopContext webshopContext)
        {
            _context = webshopContext;
            SHA = new SHA();
        }

        // Controlleren van de username overeenkomt met het wachtwoord van de gebruiker.
        public user_frontend Login(Login_credentials login)
        {
            var query = from u in _context.Users
                where u.E_mail == login.email
                select new { u.ID, u.Password, u.E_mail, u.Name, u.Surname, u.Salt };

            string uitkomst = "";

            int count = query.Count();

            if (count == 1)
            {
                foreach (var item in query)
                {
                    if (SHA.Checkpassword(login.password, item.Salt, item.Password))
                    {
                        return new user_frontend(true, item.Name, item.Surname, item.E_mail, item.ID);
                    }
                }
            }

            return new user_frontend(false, "", "", "", -1);
        }

        // Register user
        public user_frontend register(user_register user)
        {
            var query = from u in _context.Users
                where u.E_mail == user.E_mail
                select (u.ID);

            int counter = 0;
            user_frontend userFrontend = new user_frontend(false, user.Name, user.Surname, user.E_mail, -1);
            foreach (var item in query)
            {
                counter = counter + 1; 
            }

            if (counter > 0)
            {
                userFrontend.autorized = false;
                return userFrontend;
            }
            else
            {

                string randomString = randomstring.RandomString();

                Users newUsers = new Users
                {
                    E_mail = user.E_mail,
                    Password = SHA.GenerateSHA512String(randomString + user.Password),
                    Salt = randomString,
                    Name = user.Name,
                    Surname = user.Surname,
                    City = user.City,
                    Zip_code = user.Zip_code,
                    Country = user.Country,
                    Date_of_birth = user.Date_of_birth,
                    Street = user.Street,
                    Building_nummer = user.Building_nummer
                };

                _context.Users.Add(newUsers);
                _context.SaveChanges();

                var query2 = from u in _context.Users
                    where u.E_mail == user.E_mail
                    select (u.ID);

                foreach (int item in query2)
                {
                    userFrontend.ID = item;
                }
            

                userFrontend.autorized = true;
                return userFrontend;
            }
        }
    }
}