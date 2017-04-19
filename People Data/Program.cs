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
            var peopleFromTN = GetPeopleFromState(people, "TN");
            foreach (var person in peopleFromTN)
            {
                Console.WriteLine("Name: " + person.FirstName + " " + person.LastName);
                Console.WriteLine("Birthday: " + person.BirthDate.Date.ToString("d"));
                Console.WriteLine("Address: " + person.StreetNumber + " " + person.StreetName);
                Console.WriteLine("         " + person.City + ", " + person.State + " " + person.Zip);
                Console.WriteLine("Phone: " + person.PhoneNumber + "  Email: " + person.Email);
                Console.WriteLine();
            }
            Console.ReadLine();
            fileName = Path.Combine(directory.FullName, "TN.json");
            SerializePeopleToFile(peopleFromTN, fileName);
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

        public static List<Person> GetPeopleFromState(List<Person> people, string state)
        {
            var peopleFromQueriedState = new List<Person>();
            foreach (var person in people)
            {
                if (person.State == state)
                {
                    peopleFromQueriedState.Add(person);

                }
            }
            return peopleFromQueriedState;
        }

        public static void SerializePeopleToFile(List<Person> people, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, people);
            }
        }
    }
}
