using System;

class ValueVsReferenceDemo
{
    struct PointStruct // Value type
    {
        public int X;
        public int Y;
    }

    class PointClass // Reference type
    {
        public int X;
        public int Y;
    }

    static void Main()
    {
        // ===== Value Type Example =====
        PointStruct p1 = new PointStruct { X = 10, Y = 20 };
        PointStruct p2 = p1; // Copy of p1
        p2.X = 100;          // Modify p2

        Console.WriteLine("Value Type (Struct):");
        Console.WriteLine("p1.X = " + p1.X); // 10
        Console.WriteLine("p2.X = " + p2.X); // 100

        // ===== Reference Type Example =====
        PointClass c1 = new PointClass { X = 10, Y = 20 };
        PointClass c2 = c1; // Reference to same object
        c2.X = 100;         // Modify c2

        Console.WriteLine("\nReference Type (Class):");
        Console.WriteLine("c1.X = " + c1.X); // 100
        Console.WriteLine("c2.X = " + c2.X); // 100
    }
}