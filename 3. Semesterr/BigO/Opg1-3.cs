using System;

namespace _3._Semesterr.BigO
{
    public class Opg1_3
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns>Index for det fundne tal, eller -1 hvis ikke fundet.</returns>
        public static int FindNumberLinear(int[] array, int tal)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == tal)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns>Index for det fundne tal, eller -1 hvis ikke fundet.</returns>
        public static int FindNumberBinary(int[] array, int tal)
        {
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (tal == array[mid])
                {
                    return mid;
                }
                else if (tal < array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        /*
         * Skriv kode der indsætter et positivt tal i et sorteret array. 
         * Array skal fortsat være sorteret efter indsættelse.

        Da et array ikke kan udvides i C#, skal der være plads nok i arrayet
        til indsættelse af et nyt tal. Ubrugte pladser i arrayet skal sættes til -1.
        Du får brug for en variabel der holder styr på næste ledige index.
        Hvis der ikke længere er plads i arrayet, skal metoden blot returnerer
        en kopi af arrayet uden ændringer.

        Herunder er et eksempel på et array, hvor de første seks pladser er fyldte,
        og resten er tomt.

        var next = 6;
        var sortedArray = new int[] { 2, 4, 8, 10, 15, 17, -1, -1, -1, -1 };
        I skabelonen skrives koden i metoden InsertSorted.
         */


        public static int[] InsertSorted(int[] sortedArray, ref int next, int tal)
        {
            // Tjek om der er plads i arrayet
            if (next >= sortedArray.Length)
            {
                // Ingen plads til at indsætte tallet, returnér en kopi af det oprindelige array
                return (int[])sortedArray.Clone();
            }

            // Find den korrekte position til at indsætte tallet
            int i;
            for (i = next - 1; i >= 0 && sortedArray[i] > tal; i--)
            {
                // Flyt elementerne til højre for at gøre plads til det nye tal
                sortedArray[i + 1] = sortedArray[i];
            }

            // Indsæt det nye tal på den fundne position
            sortedArray[i + 1] = tal;

            // Opdater next-indekset for at afspejle, at et nyt element er blevet tilføjet
            next++;

            return sortedArray;
        }

        public static void Main()
        {
            int next = 6;
            var sortedArray = new int[] { 2, 4, 8, 10, 15, 17, -1, -1, -1, -1 };

            // Indsæt et nyt tal
            int numberToInsert = 12;
            sortedArray = InsertSorted(sortedArray, ref next, numberToInsert);

            // Udskriv det opdaterede array
            Console.WriteLine(string.Join(", ", sortedArray));
        }
    }

}

