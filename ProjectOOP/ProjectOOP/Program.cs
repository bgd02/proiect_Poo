using System.Collections.Specialized;
using System.Security.AccessControl;
using ConsoleApp1;

namespace ProjectOOP;

class Program
{
    static void Main(string[] args)
    {
        List<Sesiune> Sesiuni = new List<Sesiune>();
        List<Proiect> Proiecte = new List<Proiect>();

        List<(string, string)> Note = new List<(string, string)>();

        List<Utilizator> utilizatori = new List<Utilizator>();

        var profesor = new Profesor("12312", "John Doe", "JohnDoe@gmail.com", "A1!aaaaa");
        var student = new Student("12313", "Lazar Andrei", "LazarAndrei@gmail.com", "B1@bbbbb");

        utilizatori.Add(profesor);
        utilizatori.Add(student);

        bool open = true;

        while (open)
        {
            string optiune;

            Console.WriteLine("1. Login\n0. Exit");
            optiune = Console.ReadLine();

            switch (optiune)
            {
                case "0":
                    open = false;
                    break;
                case "1":
                {
                    Console.WriteLine("Scrieti email-ul contului: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Scrieti parola contului: ");
                    string parola = Console.ReadLine();
                    var utilizator = utilizatori.Find(u => u.email == email && u.parola == parola);
                    if (utilizator == null)
                    {
                        Console.WriteLine("Invalid.");
                    }
                    else
                    {
                        switch (utilizator)
                        {
                            case Profesor profesor1:
                            {
                                MeniuProfesor(profesor, Sesiuni, Proiecte);
                                break;
                            }

                            case Student student1:
                            {
                                MeniuStudent(student, Sesiuni, Proiecte, Note);
                                break;
                            }

                        }
                    }

                    break;
                }
            }

            static void MeniuProfesor(Profesor profesor, List<Sesiune> Sesiuni, List<Proiect> Proiecte)
            {

                Sesiune sesiune = null;
                bool John = true;


                while (John)
                {
                    Console.WriteLine("1.Deschide sesiune proiect.");
                    Console.WriteLine("2.Inchide sesiune proiect.");
                    Console.WriteLine("3.Vizualizare lista Sesiuni.");
                    Console.WriteLine("4.Notare proiect.");
                    Console.WriteLine("5.Raspuns reclamatie.");
                    Console.WriteLine("6.Modificare nota proiect.");
                    Console.WriteLine("7.Vizualizare lista proiecte.");
                    Console.WriteLine("8.Delogare");
                    Console.WriteLine("0.Exit");

                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                        {
                            profesor.DeschideSesiunea(Sesiuni);
                            break;
                        }
                        case "2":
                        {
                            profesor.InchideSesiunea(Sesiuni);
                            break;
                        }
                        case "3":
                        {
                            profesor.VizualizareLista(Sesiuni);
                            break;
                        }
                        case "4":
                        {
                            foreach (var n in Proiecte)
                            {
                                profesor.NotareProiect(n);
                            }

                            break;
                        }
                        case "5":
                        {
                            profesor.RaspunsReclamatii(Proiecte);
                            break;
                        }
                        case "6":
                        {
                            profesor.ModificareNotaProiect(Proiecte);
                            break;
                        }
                        case "7":
                        {
                            profesor.VizualizareProiect(Proiecte);
                            break;
                        }

                        case "8":
                        {
                            John = false;
                            break;
                        }
                    }
                }
            }
        }

        void MeniuStudent(Student student, List<Sesiune> Sesiuni, List<Proiect> Proiecte, List<(string, string)> Note)
        {

            Sesiune sesiune = null;
            Proiect proiect = null;
            bool Mircea = true;

            while (Mircea)
            {
                Console.WriteLine("1.Inscriere la sesiune proiect");
                Console.WriteLine("2.Predare proiect");
                Console.WriteLine("3.Vizualizare nota proiect");
                Console.WriteLine("4.Istoric note la proiecte");
                Console.WriteLine("5.Reclamatie nota proiect");
                Console.WriteLine("6.Delogare");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                    {
                        student.InscriereLaSesiune(Sesiuni);
                        break;
                    }

                    case "2":
                    {
                        student.PredareProiect(Sesiuni, Proiecte, student);
                        break;
                    }
                    case "3":
                    {
                        student.VizualizareNota(Proiecte);
                        break;
                    }
                    case "4":
                    {
                        student.IstoricNote(Note, Proiecte);
                        break;
                    }

                    case "5":
                    {
                        student.Reclamatie(Proiecte);
                        break;
                    }
                    case "6":
                    {
                        Console.WriteLine("V-ati deconectat cu succes");
                        Mircea = false;
                        break;



                    }
                }
            }
        }
    }
}
    


