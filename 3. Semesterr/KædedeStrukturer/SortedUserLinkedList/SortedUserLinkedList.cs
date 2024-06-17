namespace SortLinkedList
{
    class Node
    {
        public Node(SortUser data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public SortUser Data;
        public Node Next;
    }

    public class SortedUserLinkedList
    {
        private Node first = null!;

        public void Add(SortUser newUser)
        {
            Node newNode = new Node(newUser, null); // Opretter en ny node med det nye User-objekt.

            // Hvis listen er tom, eller det nye elements id er mindre end det første elements id. 
            if (first == null || first.Data.Id > newUser.Id)
            {
                newNode.Next = first; // Det nye elements 'Next' bliver det tidligere første element. (null! hvis ingen elemter)
                first = newNode; // Det nye element bliver nu det første element i listen.
            }
            else
            {
                // Sætter current til første node
                Node current = first;

                // Kører indtil slutningen af listen, eller indtil at vores input (newUser.Id) er mindre end 
                // referancepunktet for current.Next (current.Next.Data.Id) 
                while (current.Next != null && current.Next.Data.Id < newUser.Id)
                {
                    current = current.Next;
                }

                // Indsætter det nye element i listen.
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }


        public SortUser RemoveFirst()
        {
            if (first == null) // Hvis listen er tom
            {
                return null;
            }

            else
            {
                Node node = first;  // Gemmer første node i en variabel
                first = first.Next; // Første node bliver nu den næste node i listen
                return node.Data;   // Returnere data fra den første node (Den slettede node) 
            }
            return null;
        }


        public void RemoveUser(SortUser user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        public SortUser GetFirst()
        {
            return first.Data;
        }

        public SortUser GetLast()
        {
            if (first == null)
            {
                return null;
            }

            Node node = first;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Data;
        }

        public int CountUsers()
        {
            int count = 0; // Variabel til at holde antal

            for (Node node = first; node != null; node = node.Next)
            {
                count += 1;
            }

            return count;
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }
        public bool Contains(SortUser user)
        {
            Node current = first;

            while (current != null)
            {
                if (current.Data.Name == user.Name)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }