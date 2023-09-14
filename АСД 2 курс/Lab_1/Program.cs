Console.Write("Write down the number of elements-->");
int N = int.Parse(Console.ReadLine());
Queue queue= new Queue();
for (int i = 0; i < N; i++)
{
    char value = Convert.ToChar(Console.ReadLine());
    queue.enqueue(value);
}
queue.print();

char firstElem = queue.peek();
Console.WriteLine($"\nThe first element of the queue is {firstElem}.");


Console.Write("Write down the number of elements y0u want to pick--> ");
int number = int.Parse(Console.ReadLine());
for (int k = 0; k < number; k++)
{
    char pickedElem = queue.dequeue();
    Console.WriteLine($"Your picked element is {pickedElem}.");
}

queue.print();
firstElem = queue.peek();
Console.WriteLine($"The first element of the queue is {firstElem}.");

int numberOfElements = queue.count();
Console.WriteLine($"The number of elements is {numberOfElements}");

char minimum = queue.min();
Console.WriteLine($"Minimun of the queue is {minimum}");




public class Element
{
    public char value;
    public Element Next;
}

public class Queue
{
    Element head;
    Element tail;
    
    public void enqueue(char value)
    {
        Element element = new Element();
        element.value = value;
        element.Next = tail;

        if(head==null)
        {
            head= element; 
        }
        tail = element;
    }
    public char dequeue()
    {
        char pickedElementValue = head.value;
        if(head==tail)
        {
            head = null;
            tail = null;
        }
        else 
        {
            Element element = tail;
            while (element.Next != head)
            {
                element = element.Next;
            }
            head = element;
            head.Next = null;
        }
        return pickedElementValue;
    }
    public char peek()
    {
        return head.value;
    }
    public void print()
    {
        Console.WriteLine();
        if (head != null)
        {
            Element currentEl = tail;
            do
            {
                Console.Write($"{currentEl.value}\t");
                currentEl = currentEl.Next;
            } while (currentEl!= null);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("There are no elements in the queue!");
        }
    }
    public int count()
    {
        Element currentEl = tail;
        int i = 0;
        while (currentEl != null)
        {
            i++;
            currentEl = currentEl.Next;
            
        }
        return i;
    }
    public char min()
    {
        Element currentEl=tail;
        char min = char.MaxValue;
        while (currentEl != null)
        {
            if (min > currentEl.value)
                min = currentEl.value;
            currentEl = currentEl.Next;
        }
        return min;
    }


}


