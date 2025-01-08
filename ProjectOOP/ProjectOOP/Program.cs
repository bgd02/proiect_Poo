namespace ProjectOOP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Profesor profesor = new Profesor("12312", "John Doe", "JohnDoe@gmail.com", "A1!aaaaa");
        profesor.AfiseazaInformatii();
    }
}