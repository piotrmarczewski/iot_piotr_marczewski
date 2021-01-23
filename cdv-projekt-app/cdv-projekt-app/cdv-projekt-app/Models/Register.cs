namespace cdv_projekt_app.Models
{
    internal class Register
    {
        public Register()
        {
        }

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
    }
}