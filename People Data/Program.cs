using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace People_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "People.json");
            var people = DeserializePeople(fileName);
            foreach (var person in people)
            {
                Console.WriteLine("Name: " + person.FirstName + " " + person.LastName);
                Console.WriteLine("Birthday: " + person.BirthDate.Date.ToString("d"));
                Console.WriteLine("Address: " + person.StreetNumber + " " + person.StreetName);
                Console.WriteLine("         " + person.City + ", " + person.State + " " + person.Zip);
                Console.WriteLine("Phone: " + person.PhoneNumber + "  Email: " + person.Email);
                Console.WriteLine();
            }
            Console.ReadLine();

        }

        public static List<Person> DeserializePeople (string fileName)
        {
            var people = new List<Person>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                people = serializer.Deserialize< List<Person> > (jsonReader);
            }
                return people; 
        }
    }
}
