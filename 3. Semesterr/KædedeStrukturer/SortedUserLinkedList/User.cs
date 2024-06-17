namespace SortLinkedList
{
    public class SortUser
    {
        public SortUser(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
