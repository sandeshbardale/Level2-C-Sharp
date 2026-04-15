using System;

class SpanDemo
{
    static void Main()
    {
        // 1. Using Span<T> (mutable view)
        int[] numbers = { 1, 2, 3, 4, 5 };
        Span<int> spanNumbers = numbers; // Create a Span over the array

        Console.WriteLine("Original array: " + string.Join(", ", numbers));

        // Modify using Span
        spanNumbers[0] = 10;
        spanNumbers[4] = 50;

        Console.WriteLine("Array after modifying Span: " + string.Join(", ", numbers));

        // 2. Using ReadOnlySpan<T> (immutable view)
        ReadOnlySpan<int> readOnlySpan = numbers;

        Console.WriteLine("ReadOnlySpan elements:");
        foreach (int num in readOnlySpan)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // readOnlySpan[0] = 100; // ❌ This will give a compile-time error
    }
}