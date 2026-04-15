using System;

class MemoryDemo
{
    class Person
    {
        public string Name;
        public Person(string name)
        {
            Name = name;
            Console.WriteLine(Name + " object created.");
        }

        ~Person() // Destructor / Finalizer
        {
            Console.WriteLine(Name + " object destroyed by GC.");
        }
    }

    static void Main()
    {
        // ===== Stack Example (Value Type) =====
        int x = 10;          // Stored in stack
        int y = x;           // Copy of value
        y = 20;
        Console.WriteLine("x = " + x); // 10
        Console.WriteLine("y = " + y); // 20

        // ===== Heap Example (Reference Type) =====
        Person p1 = new Person("Alice");  // Object stored in heap
        Person p2 = p1;                   // Reference copy
        p2.Name = "Bob";

        Console.WriteLine("p1.Name = " + p1.Name); // Bob
        Console.WriteLine("p2.Name = " + p2.Name); // Bob

        // ===== Garbage Collection =====
        p1 = null;   // Object no longer referenced
        p2 = null;

        Console.WriteLine("Forcing Garbage Collection...");
        GC.Collect();    // Force GC (not recommended in production)
        GC.WaitForPendingFinalizers();

        Console.WriteLine("End of Main.");
    }
}