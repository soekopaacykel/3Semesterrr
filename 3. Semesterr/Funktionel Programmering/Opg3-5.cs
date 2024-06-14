﻿using System;
namespace _3._Semesterr.FunktionelProgrammering
{
	public class Opg3_5
	{
		

class Program
    {
        static void Main()
        {
            // Opgave 3.1
            // Eksempel på brug af CreateWordFilterFn
            var filterWords = new string[] { "shit", "fucking", "fuck" };
            var FilterWords = CreateWordFilterFn(filterWords);

            Console.WriteLine("-----------");
            Console.WriteLine("Opgave 3.1: ");
            Console.WriteLine("-----------");
            Console.WriteLine(FilterWords("fuck noget fucking shit makker."));
            Console.WriteLine("-----------\n");

            // Opgave 3.2
            // Eksempel på brug af CreateWordReplacerFn
            var badWords = new string[] { "shit", "fuck", "idiot" };
            var ReplaceBadWords = CreateWordReplacerFn(badWords, "kage");
            Console.WriteLine("Opgave 3.2: ");
            Console.WriteLine("-----------");
            Console.WriteLine(ReplaceBadWords("Sikke en gang shit, fuck det, sikke en idiot."));
            Console.WriteLine("-----------\n");

            // Opgave 4.2, 4.3, 4.4 og 5.1
            Person[] people = new Person[]
            {
            new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
            new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
            new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
            new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
            new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
            new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
            };

            // Opgave 4.2: Sammenligner to personer efter alder
            Func<Person, Person, int> compareAges = (person1, person2) =>
            {
                if (person1.Age < person2.Age)
                {
                    return -1;
                }
                else if (person1.Age == person2.Age)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            };

            // Sorterer personer efter alder
            BubbleSort.Sort(people, compareAges);

            // Opgave 4.2: Udskriver personer sorteret efter alder
            Console.WriteLine("Opgave 4.2:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Phone}");
            }

            // ----------------------------------------------------------------------------------------------------------------------------------------

            // Opgave 4.3: Sorterer personer efter navn
            Func<Person, Person, int> compareNames = (person1, person2) =>
            {
                return person1.Name.CompareTo(person2.Name);
            };
            // Sorterer personer efter navn
            BubbleSort.Sort(people, compareNames);

            // Opgave 4.3: Udskriver personer sorteret efter navn
            Console.WriteLine("\nOpgave 4.3:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Phone}");
            }

            // ----------------------------------------------------------------------------------------------------------------------------------------

            // Opgave 4.4: Sorterer personer efter telefonnummer
            Func<Person, Person, int> comparePhones = (person1, person2) =>
            {
                return person1.Phone.CompareTo(person2.Phone);
            };
            // Sorterer personer efter telefonnummer
            BubbleSort.Sort(people, comparePhones);

            // Opgave 4.4: Udskriver personer sorteret efter telefonnummer
            Console.WriteLine("\nOpgave 4.4:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Phone}");
            }

            // ----------------------------------------------------------------------------------------------------------------------------------------

            // Opgave 5.1: Højere Ordens Funktion
            // Der laves en ny sorterings-funktion hvor der sammenlignes på alder
            var PeopleSortAge = BubbleSort.CreateSorter((person1, person2) => person1.Age - person2.Age);
            // Den nye funktion bruges til at sortere et array
            var sortedPeople = PeopleSortAge(people);
            // Det sorterede array udskrives med LINQ så vi kan se at det virker
            Console.WriteLine("\nOpgave 5.1:");
            sortedPeople.ToList().ForEach(p => Console.WriteLine(p.Age + " " + p.Name));
        }

        // Opgave 3.1: Fjerner 'Bad Words'
        static Func<string, string> CreateWordFilterFn(string[] words)
        {
            return (text) =>
            {
                var wordsList = text.Split(' ').ToList();
                var filteredWords = wordsList.Where(word => !words.Contains(word)).ToList();
                return String.Join(" ", filteredWords);
            };
        }

        // Opgave 3.2: Erstatter 'Bad Words' med 'Kage'
        static Func<string, string> CreateWordReplacerFn(string[] words, string replacementWord)
        {
            return (text) =>
            {
                var wordsList = text.Split(' ').ToList();
                var replacedWords = wordsList.Select(word => words.Contains(word) ? replacementWord : word).ToList();
                return String.Join(" ", replacedWords);
            };
        }
    }

    public class BubbleSort
    {
        // Bytter om på to elementer i et array
        private static void Swap(Person[] array, int i, int j)
        {
            Person temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        // Laver sortering på array med Bubble Sort. 
        // compareFn bruges til at sammeligne to personer med.
        public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    // Laver en ombytning, hvis to personer står forkert sorteret
                    if (compareFn(array[j], array[j + 1]) > 0)
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        // Opgave 5.1: Højere Ordens Funktion
        public static Func<Person[], Person[]> CreateSorter(Func<Person, Person, int> compareFn)
        {
            return (array) =>
            {
                Person[] newArray = (Person[])array.Clone();
                BubbleSort.Sort(newArray, compareFn);
                return newArray;
            };
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }

}
}

