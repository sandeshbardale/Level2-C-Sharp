using System;

class Student
{
    private string[] subjects = new string[5];

    // Indexer declaration
    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < subjects.Length)
                return subjects[index];
            else
                return "Index out of range";
        }
        set
        {
            if (index >= 0 && index < subjects.Length)
                subjects[index] = value;
            else
                Console.WriteLine("Index out of range");
        }
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student();

        // Storing subjects using indexer
        student[0] = "Mathematics";
        student[1] = "Physics";
        student[2] = "Chemistry";
        student[3] = "Biology";
        student[4] = "English";

        // Accessing subjects using indexer
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Subject " + (i + 1) + ": " + student[i]);
        }

        // Testing invalid index
        Console.WriteLine(student[5]); // Index out of range
    }
}