Console.Write("Write down the number of elements-->");
int N = int.Parse(Console.ReadLine());
Queue queue= new Queue();
for (int i = 0; i < N; i++)
{
    char value = Convert.ToChar(Console.ReadLine());
    queue.add(value);
}
queue.toString();

Console.Write("Write down the number of elements y0u want to pick--> ");
int number = int.Parse(Console.ReadLine());
//for (int k = 0; k < number; k++)
//{
    queue.pick();
queue.toString();
queue.peek();

queue.kilkst();
char minimum=queue.min();
Console.WriteLine($"Minimun of the queue is {minimum}");




public class Element
{
    public char currentEl;
    public Element Next;
}

public class Queue
{
    //public Element Elem;
    Element tail;
    Element prevEl;
    Element currentEl;
    public void add(char value)
    {
        Element currentEl = new Element();
        currentEl.Next=currentEl;
        
        tail = currentEl;
        

    }
    public void pick()
    {
        while(currentEl.Next!=null)
        { 
            currentEl = currentEl.Next;
        }
        Element pickedElement = currentEl;
        currentEl = null;
    }
    public void peek()
    {
        do
        {
            currentEl = currentEl.Next;
        } while (currentEl != null);
        Console.WriteLine($"The value of the first element is {currentEl}.");

    }
    public void toString()
    {
        if (currentEl != null)
        {
            do
            {
                Console.Write($"{currentEl}\t");
                currentEl = currentEl.Next;
            } while (currentEl.Next != null);
        }
        else ifEmpty();
    }
    public void kilkst()
    {
        int i = 0;
        while (currentEl != null)
        {
            currentEl = currentEl.Next;
            i++;
        }
        Console.WriteLine($"The number of elements is {i}");
    }
    public char min()
    {
        char min = char.MinValue;
        while (currentEl != null)
        {
            if(min>Convert.ToChar(currentEl))
                min = Convert.ToChar(currentEl);
            currentEl = currentEl.Next;  
        }
        return min;
    }
    public void ifEmpty()
    {
        if (currentEl == null)
        {
            Console.WriteLine("There are no elements in the queue!");
        }
    }

}


