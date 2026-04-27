using System;

// Step 1: Publisher class
class Publisher
{
    // Declare an event using EventHandler delegate
    public event EventHandler OnChange;

    // Method to trigger event
    public void RaiseEvent()
    {
        Console.WriteLine("Event is about to be raised...");
        OnChange?.Invoke(this, EventArgs.Empty);  // Invoke event
    }
}

// Step 2: Subscriber class
class Subscriber
{
    public void Subscribe(Publisher pub)
    {
        pub.OnChange += HandleEvent;  // Subscribe to event
    }

    // Event handler method
    private void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event received! Handling event in Subscriber.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();

        // Subscriber subscribes to event
        subscriber.Subscribe(publisher);

        // Raise the event
        publisher.RaiseEvent();
    }
}