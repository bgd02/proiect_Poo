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
                                MeniuStudent(student, Sesiuni, Proiecte);
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
                Proiect proiect = new Proiect("---", "---", "---", "---");
                bool John = true;


                while (John)
                {
                    Console.WriteLine("1.Deschide sesiune proiect.");
                    Console.WriteLine("2.Inchide sesiune proiect.");
                    Console.WriteLine("3.Vizualizare lista proiecte.");
                    Console.WriteLine("4.Notare proiect.");
                    Console.WriteLine("5.Raspuns reclamatie.");
                    Console.WriteLine("6.Modificare nota proiect.");
                    Console.WriteLine("7.Delogare");
                    Console.WriteLine("0.Exit");

                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                        {

                            string codSesiune;
                            Console.WriteLine("Codul Sesiunii: ");
                            codSesiune = Console.ReadLine();

                            string numeSesiune;
                            Console.WriteLine("Numele sesiunii: ");
                            numeSesiune = Console.ReadLine();

                            sesiune = new Sesiune(codSesiune, numeSesiune, true);
                            profesor.DeschideSesiunea(Sesiuni, Proiecte, codSesiune, sesiune, proiect);
                            sesiune.AdaugaProiect(proiect);
                            break;
                        }
                        case "2":
                        {
                            Console.WriteLine("Introduceti codul sesiunii pe care doriti sa o stergeti: ");
                            string codSesiune = Console.ReadLine();
                            for (var i = 0; i < Sesiuni.Count; i++)
                            {
                                if (Sesiuni[i].codSesiune == codSesiune)
                                {
                                    profesor.InchideSesiunea(Sesiuni, Proiecte, sesiune, proiect);
                                }
                                else
                                {
                                    Console.WriteLine("Nu exista codul introdus.");
                                }
                            }

                            break;
                        }
                        case "3":
                        {

                            foreach (var s in Sesiuni)
                            {
                                Console.WriteLine($"{s.codSesiune} -> {s.numeSesiune}");
                            }

                            foreach (var p in Proiecte)
                            {
                                Console.WriteLine($"{p.Student} -> {p.numeProiect} -> {p.nota}");
                            }

                            break;
                        }
                        case "4":
                        {

                           foreach(var n in Proiecte)
                            {
                                Console.WriteLine($"Introduceti nota pentru studentul {n.Student}");
                                string notastd = Console.ReadLine();
                                n.nota = notastd;
                                Console.WriteLine($"Nota studentului {n.Student} este {n.nota}");
                            }
                            profesor.NotareProiect(Proiecte, proiect);
                            break;
                        }
                        
                    

                    case "5":
                    {


                        break;
                    }
                    case "7":
                    {
                        John = false;
                        break;
                    }
                }
            }
        }
    }

    static void MeniuStudent(Student student, List<Sesiune> Sesiuni, List<Proiect> Proiecte)
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

                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                        {

                            foreach (var s in Sesiuni)
                            {
                                Console.WriteLine("Introduceti codul sesiunii la care doriti sa va inscrieti : ");
                                string cod = Console.ReadLine();
                                student.InscriereLaSesiune(Sesiuni, cod, proiect);
                                Console.WriteLine("Te ai inscris cu succes!");

                            }
                            
                            break;
                        }

                        case "2":
                        {
                            // Exemplu
                            Console.WriteLine("Introduceti codul sesiunii la care doriti sa va predati proiectul : ");
                            string cod = Console.ReadLine();
                            foreach (var s in Sesiuni)
                            {
                                if (cod == s.codSesiune && s.isOpen)
                                {
                                    Console.WriteLine("Introduceti numele proiectului pe care doriti sa il incarcati : ");
                                    string numeProiect = Console.ReadLine();
                                    var proiect2 = new Proiect(student.numePrenume, numeProiect, "---", "---");
                                    Console.WriteLine($"{proiect2.Student} -> {proiect2.numeProiect} -> {proiect2.nota}");
                                    student.PredareProiect(Sesiuni, Proiecte, cod, proiect2);
                                    Proiecte.Add(proiect2);
                                }
                        }
                            break;
                    }
                        case "6":
                        {
                            Mircea = false;
                            break;
                        }
                    }
                }
            }
        }
    }



