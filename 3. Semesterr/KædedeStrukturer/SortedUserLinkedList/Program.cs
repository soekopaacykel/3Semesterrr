using System;
using SortLinkedList;

class SortProgram
{
    static void Main()
    {
        SortUser kristian = new SortUser("Kristian", 1);
        SortUser mads = new SortUser("Mads", 2);
        SortUser torill = new SortUser("Torill", 3);
        SortUser kell = new SortUser("Kell", 4);
        SortUser henrik = new SortUser("Henrik", 5);
        SortUser klaus = new SortUser("Klaus", 6);

        SortedUserLinkedList list = new SortedUserLinkedList();
        list.Add(kristian);
        list.Add(mads);
        list.Add(torill);
        list.Add(henrik);
        list.Add(klaus);

        Console.WriteLine("Number of Users: " + list.CountUsers());
        Console.WriteLine("Sorted List: " + list);

        list.RemoveUser(mads);
        list.RemoveFirst();

        Console.WriteLine("Number of Users after removal: " + list.CountUsers());
        Console.WriteLine("Sorted List after removal: " + list);
    }
}

