SortUser user1 = new SortUser{Id = 42, Username = "Kristian"};
SortUser user2 = new SortUser{Id = 22, Username = "Mads"};
SortUser user3 = new SortUser{Id = 42, Username = "Kristian"};
SortUser user4 = user1;

Console.WriteLine(user1.GetHashCode());
Console.WriteLine(user2.GetHashCode());
Console.WriteLine(user3.GetHashCode());

Console.WriteLine(user1.Equals(user3));
Console.WriteLine(user1 == user3);

public class SortUser {
    public int Id { get; set; }
    public string Username { get; set; }

    public override bool Equals(object obj)
    {
        SortUser input = (SortUser) obj;
        return input.Id == this.Id;
    }

    public override int GetHashCode()
    {
        return Id + Username.GetHashCode();
    }
}