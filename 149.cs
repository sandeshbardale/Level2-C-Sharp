using System;

// Step 1: Create a custom attribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
class AuthorAttribute : Attribute
{
    public string Name { get; }
    public string Version { get; }

    public AuthorAttribute(string name, string version)
    {
        Name = name;
        Version = version;
    }
}

// Step 2: Apply attribute to class and method
[Author("Alice", "1.0")]
class SampleClass
{
    [Author("Bob", "1.1")]
    public void SampleMethod()
    {
        Console.WriteLine("Executing SampleMethod...");
    }
}

// Step 3: Access attributes using reflection
class AttributeExample
{
    static void Main(string[] args)
    {
        Type type = typeof(SampleClass);

        // Get class attribute
        AuthorAttribute classAttr = (AuthorAttribute)Attribute.GetCustomAttribute(type, typeof(AuthorAttribute));
        if (classAttr != null)
        {
            Console.WriteLine($"Class Author: {classAttr.Name}, Version: {classAttr.Version}");
        }

        // Get method attribute
        var method = type.GetMethod("SampleMethod");
        AuthorAttribute methodAttr = (AuthorAttribute)Attribute.GetCustomAttribute(method, typeof(AuthorAttribute));
        if (methodAttr != null)
        {
            Console.WriteLine($"Method Author: {methodAttr.Name}, Version: {methodAttr.Version}");
        }

        // Invoke method
        SampleClass obj = new SampleClass();
        method.Invoke(obj, null);
    }
}