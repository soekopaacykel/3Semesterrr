using System;
namespace Rekursion;

class Program
{
    static void Main()
    {
        // Opgave 2
        int bredde = 5; // Du kan ændre denne værdi for at teste med forskellige bredde værdier
        int arealResultat = Areal(bredde);
        Console.WriteLine($"Arealet af figuren med bredde {bredde} er: {arealResultat}");

        // Opgave 4.1
        int a = 30;
        int b = 12;
        int sfdResultat1 = opg_4.Sfd(a, b);
        int sfdResultat2 = opg_4.Sfd2(a, b);
        Console.WriteLine("\nOpgave 4.1: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"Den største fælles divisor af {a} og {b} er: {sfdResultat1}");
        Console.WriteLine($"Den største fælles divisor af {a} og {b} er: {sfdResultat2}");
        Console.WriteLine("-----------\n");

        // Opgave 4.2
        int grundtal = 5;
        int eksponent = 4;
        int potensResultat = opg_4.OpløftTilPotens(grundtal, eksponent);
        Console.WriteLine("Opgave 4.2: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"{grundtal} opløftet til {eksponent}'te potens er: {potensResultat}");
        Console.WriteLine("-----------\n");

        // Opgave 4.3
        int a1 = 4;
        int b1 = 2;
        int gangeResultat = opg_4.GangeUdenAtGangeLol(a1, b1);
        Console.WriteLine("Opgave 4.3: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"{a1} * {b1} er = {gangeResultat}");
        Console.WriteLine("-----------\n");

        // Opgave 4.4
        string tekst = "EGAKNANAB";
        string reverseTekst = opg_4.Reverse(tekst);
        Console.WriteLine("Opgave 4.4: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"Teksten: {tekst}, er = {reverseTekst} baglæns");
        Console.WriteLine("-----------\n");

        // Opgave 3
        int facultyInput = 5;
        int facultyResult = opg_3.Faculty(facultyInput);
        Console.WriteLine($"Fakultet af {facultyInput} er: {facultyResult}");
    }

    public static int Areal(int bredde)
    {
        if (bredde == 1)
        {
            return 1;
        }
        return bredde + Areal(bredde - 1);
    }
}

class opg_3
{
    public static int Faculty(int n)
    {
        // Termineringsregel
        if (n == 0)
        {
            return 1;
        }

        // Rekurrensregel
        return n * Faculty(n - 1);
    }
}

class opg_4
{
    // Opgave 4.1
    public static int Sfd(int a, int b)
    {
        // Termineringsregel
        if (b == 0)
            return a;

        // Rekurrensregel
        return Sfd(b, a % b);
    }

    // Opgave 4.1 (På en anden måde)
    public static int Sfd2(int a, int b)
    {
        // Termineringsregel: Returner b, hvis b går op i a
        if (a % b == 0)
            return b;

        // Rekurrensregel
        if (a < b)
            return Sfd2(b, a);
        else
            return Sfd2(b, a % b);
    }

    // Opgave 4.2
    public static int OpløftTilPotens(int grundtal, int eksponent)
    {
        // Termineringsregel
        if (eksponent == 0)
            return 1;

        // Rekurrensregel
        return grundtal * OpløftTilPotens(grundtal, eksponent - 1);
    }

    // Opgave 4.3
    public static int GangeUdenAtGangeLol(int a1, int b1)
    {
        // Termineringsregel
        if (a1 == 0)
            return 0;

        if (a1 == 1)
            return b1;

        // Rekurrensregel
        return GangeUdenAtGangeLol(a1 - 1, b1) + b1;
    }

    // Opgave 4.4
    public static string Reverse(string tekst)
    {
        // Termineringsregel: Hvis strengen er tom eller har én karakter
        if (string.IsNullOrEmpty(tekst) || tekst.Length == 1)
        {
            return tekst;
        }

        // Rekursions tilfælde: Vend resten af strengen og tilføj den første karakter på enden
        return Reverse(tekst.Substring(1)) + tekst[0];
    }


// Modul 1; Opgave 5 - (Ekstra opgave)

class opg_5

{

    public static void Main()
    {
        // Opgave 5.1 - Tæller antallet af mapper
        Console.WriteLine("--------------------\nOpgave 5.1:\n-------------------- ");
        string path = "/Users/rosell/IT-A/3. Sem";
        Console.WriteLine($"Antal mapper: {ScanDirCount(path)}");
        Console.WriteLine("-------------------- ");

        // Opgave 5.2 - Udskriver mappestrukturen med indrykning
        Console.WriteLine("Opgave 5.2:\n-------------------- ");
        Console.WriteLine("\nMappe struktur:");
        ScanDirIndented(path);
        Console.WriteLine("-------------------- ");
    }

    // Opgave 5.1: Tæller antallet af mapper rekursivt
    public static int ScanDirCount(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        int folderCount = 1; // Tæller den nuværende mappe

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            folderCount += ScanDirCount(subdir.FullName); // Rekursivt kald til undermapper
        }

        return folderCount;
    }

    // Opgave 5.2: Udskriver mappestrukturen med indrykning
    public static void ScanDirIndented(string path, int level = 0)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        string indentation = new string(' ', level * 2); // 2 mellemrum pr. niveau

        Console.WriteLine($"{indentation}{new DirectoryInfo(path).Name}");
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            Console.WriteLine($"{indentation}  {file.Name}"); // Filnavne indrykket med 2 ekstra mellemrum
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            ScanDirIndented(subdir.FullName, level + 1); // Rekursivt kald med øget niveau
        }
    }
}

}
