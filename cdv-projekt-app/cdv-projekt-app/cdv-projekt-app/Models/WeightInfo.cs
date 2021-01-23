using System;

namespace cdv_projekt_app.Models
{
    public class WeightInfo
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public decimal weight { get; set; }
        public DateTime date { get; set; }
        public DateTime Date { get; internal set; }
        public string description { get; set; }
    }
}