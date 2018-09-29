namespace Authentication
{
    public class user_frontend
    {
        public bool autorized;
        public string name;
        public string surname;
        public string email;
        public int ID;

        public user_frontend(bool autorized, string name, string surname, string email, int ID)
        {
            this.autorized = autorized;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.ID = ID;
        }
    }
}