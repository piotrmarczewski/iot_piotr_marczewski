using System;

namespace cdv_projekt_app.Models
{
    internal class AddWeight
    {
        public AddWeight()
        {
        }

        public decimal weight { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
    }
}