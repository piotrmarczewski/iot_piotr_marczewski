namespace cdv_projekt_app.Models
{
    public class LoginToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
    }
}