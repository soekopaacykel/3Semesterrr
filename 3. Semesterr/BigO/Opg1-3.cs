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

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Arrayet er fortsat sorteret efter at det nye tal er indsat.
        /// </summary>
        /// <param name="sortedArray">Det sorteret array, hvor tallet skal indsættes.</param>
        /// <param name="tal">Tallet der skal indsættes.</param>
        /// <returns>En kopi af det sorterede array med det nye tal indsat.</returns>
        public static int[] InsertSorted(int[] sortedArray, int tal)
        {
            int[] newArray = new int[sortedArray.Length];

            // Copy elements to newArray
            Array.Copy(sortedArray, newArray, sortedArray.Length);

            int i;
            for (i = sortedArray.Length - 1; i >= 0 && (newArray[i] > tal || newArray[i] == -1); i--)
            {
                newArray[i + 1] = newArray[i];
            }

            newArray[i + 1] = tal;

            return newArray;
        }
    }
}
