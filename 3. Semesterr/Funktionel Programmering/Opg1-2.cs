using System;
using System.Linq;

namespace _3._Semesterr.FunktionelProgrammering
{
    class Program
    {
        static void Main()
        {
            Person[] people = new Person[]
            {
                new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
                new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
                new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
                new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
                new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
                new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
            };

            // Opgave 1.1
            Console.WriteLine("Opgave 1: ");
            Console.WriteLine("-----------");
            Opg_01_1 opgave1_1 = new Opg_01_1();
            opgave1_1.Opgave1_1(people);
            Console.WriteLine("-----------\n");

            // Opgave 1.2
            Console.WriteLine("Opgave 2: ");
            Console.WriteLine("-----------");
            Opg_01_2 opgave1_2 = new Opg_01_2();
            opgave1_2.Opgave1_2(people);
            Console.WriteLine("-----------\n");

            // Opgave 1.3
            Console.WriteLine("Opgave 3: ");
            Console.WriteLine("-----------");
            Opg_01_3 opgave1_3 = new Opg_01_3();
            opgave1_3.Opgave1_3(people);
            Console.WriteLine("-----------\n");

            // Opgave 2.1
            Console.WriteLine("Opgave 2.1: ");
            Console.WriteLine("-----------");
            Opg_02_1 opgave2_1 = new Opg_02_1();
            opgave2_1.Opgave2_1(people);
            Console.WriteLine("-----------\n");

            // Opgave 2.2
            Console.WriteLine("Opgave 2.2: ");
            Console.WriteLine("-----------");
            Opg_02_2 opgave2_2 = new Opg_02_2();
            opgave2_2.Opgave2_2(people);
            Console.WriteLine("-----------\n");

            // Opgave 2.3
            Console.WriteLine("Opgave 2.3: ");
            Console.WriteLine("-----------");
            Opg_02_3 opgave2_3 = new Opg_02_3();
            opgave2_3.Opgave3(people);
            Console.WriteLine("-----------\n");

            // Opgave 2.3.2: MEGET nemmere måde, at fjerne '+45'
            Console.WriteLine("Opgave 2.3 (på en sejere måde): ");
            Console.WriteLine("-----------");
            Opg_02_3_2 opgave2_3_2 = new Opg_02_3_2();
            opgave2_3_2.Opgave2_3_2(people);
            Console.WriteLine("-----------\n");

            // Opgave 2.4
            Console.WriteLine("Opgave 2.4: ");
            Console.WriteLine("-----------");
            Opg_02_4 opgave2_4 = new Opg_02_4();
            opgave2_4.Opgave2_4(people);
            Console.WriteLine("-----------\n");


        }
    }

    class Opg_01_1
    {
        public void Opgave1_1(Person[] people)
        {
            int totalAge = people.Sum(p => p.Age);
            Console.WriteLine("Den samlede alder for alle personer er: " + totalAge);
        }
    }

    class Opg_01_2
    {
        public void Opgave1_2(Person[] people)
        {
            int countNielsen = people.Count(p => p.Name.Contains("Nielsen"));
            Console.WriteLine("Antallet af personer, der hedder 'Nielsen': " + countNielsen);
        }
    }

    class Opg_01_3
    {
        public void Opgave1_3(Person[] people)
        {
            int oldestAge = people.Max(p => p.Age); // Finder den højeste alder
            var oldestPeople = people.Where(p => p.Age == oldestAge); // Finder alle personer med denne alder

            foreach (var person in oldestPeople)
            {
                // For hver person, udskriv navn og alder
                Console.WriteLine($"Den ældste person er {person.Name} med en alder af: {person.Age}");
            }
        }
    }

    class Opg_02_1
    {
        public void Opgave2_1(Person[] people)
        {
            var findNr = people.Where(p => p.Phone == "+4543215687");

            foreach (var person in findNr)
            {
                Console.WriteLine($"Personen med tlfnr'et: {person.Phone}, er: {person.Name}");
            }
        }
    }

    class Opg_02_2
    {
        public void Opgave2_2(Person[] people)
        {
            var oldafPeople = people.Where(p => p.Age > 30);

            foreach (var person in oldafPeople)
            {
                Console.WriteLine($"{person.Name} er {person.Age} år gammel");
            }
        }
    }

    class Opg_02_3
    {
        public void Opgave3(Person[] people)
        {
            var updatedPeople = people.Select(p => new Person
            {
                Name = p.Name,
                Age = p.Age,
                Phone = p.Phone.StartsWith("+45") ? p.Phone.Substring(3) : p.Phone
            }).ToArray();

            foreach (var person in updatedPeople)
            {
                Console.WriteLine($"{person.Name}, {person.Age} år, Tlf: {person.Phone}");
            }
        }
    }

    class Opg_02_3_2
    {
        public void Opgave2_3_2(Person[] people)
        {
            var updatedPeople = people.Select(p => new Person
            {
                Name = p.Name,
                Age = p.Age,
                Phone = p.Phone.Replace("+45", "")
            });

            foreach (var person in updatedPeople)
            {
                Console.WriteLine($"{person.Name}, {person.Age} år, Tlf: {person.Phone}");
            }
        }
    }

    class Opg_02_4
    {
        public void Opgave2_4(Person[] people)
        {
            var youngPeopleInfo = people
                .Where(person => person.Age < 30)
                .Select(person => $"{person.Name} ({person.Phone})")
                .Aggregate((current, next) => current + ", " + next);

            Console.WriteLine("Personer under 30 (i én streng): \n" + youngPeopleInfo);
        }
    }

    
    

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
