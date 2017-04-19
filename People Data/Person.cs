using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace People_Data
{
    public class Rootobject
    {
        public Person[] People { get; set; }
    }

    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "birth_date")]
        public DateTime BirthDate { get; set; }
        [JsonProperty(PropertyName = "street_number")]
        public int StreetNumber { get; set; }
        [JsonProperty(PropertyName = "street_name")]
        public string StreetName { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "zip")]
        public int Zip { get; set; }
        [JsonProperty(PropertyName = "primary_phone")]
        public string PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "primary_email")]
        public string Email { get; set; }
    }
}
