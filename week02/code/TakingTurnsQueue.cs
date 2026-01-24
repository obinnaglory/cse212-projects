/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue<T>
{
    private Queue<(T person, int turns)> queue = new Queue<(T, int)>();

    public int Count
    {
        get
        {
            return queue.Count; // Adjust based on your internal data structure
        }
    }

    public void AddPerson(T person, int turns)
    {
        queue.Enqueue((person, turns));
    }

    public T GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var (person, turns) = queue.Dequeue();

        if (turns <= 0) // infinite turns
        {
            queue.Enqueue((person, turns));
        }
        else if (turns > 1) // still has turns left
        {
            queue.Enqueue((person, turns - 1));
        }

        return person;
    }
}

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
  
    /// <summary>
    /// Test that Dequeue removes highest priority item.
    /// </summary>
    public class PriorityQueue<T>
{
    private List<(T Value, int Priority)> items = new List<(T, int)>();

    public void Enqueue(T value, int priority)
    {
        items.Add((value, priority));
    }

    public T Dequeue()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int maxPriority = items.Max(i => i.Priority);
        int index = items.FindIndex(i => i.Priority == maxPriority);

        var item = items[index];
        items.RemoveAt(index);
        return item.Value;
    }
}

