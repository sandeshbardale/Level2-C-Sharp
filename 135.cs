using System;

class MulticastDelegateExample
{
    // Step 1: Declare a delegate
    delegate void Notify(string message);

    // Step 2: Methods matching delegate signature
    static void EmailNotification(string message)
    {
        Console.WriteLine("Email: " + message);
    }

    static void SMSNotification(string message)
    {
        Console.WriteLine("SMS: " + message);
    }

    static void PushNotification(string message)
    {
        Console.WriteLine("Push: " + message);
    }

    static void Main(string[] args)
    {
        // Step 3: Create delegate instances
        Notify notifyDelegate = EmailNotification;
        notifyDelegate += SMSNotification;       // Add method to delegate
        notifyDelegate += PushNotification;      // Add another method

        // Step 4: Invoke multicast delegate
        notifyDelegate("You have a new message!");

        // Step 5: Remove a method from delegate
        notifyDelegate -= SMSNotification;

        Console.WriteLine("\nAfter removing SMS notification:");
        notifyDelegate("Check your notifications!");
    }
}