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
        
        List<(string,string)> Note=new List<(string,string)>();
        
        List<Utilizator> utilizatori = new List<Utilizator>();

        (Sesiuni, Proiecte, utilizatori) = Fisier.Incarcare();

        bool inscris = false;
        
        var profesor = new Profesor("John Doe", "JohnDoe@gmail.com", "A1!aaaaa");
        var student = new Student("12313", "Lazar Andrei", "LazarAndrei@gmail.com", "B1@bbbbb");
        var student2=new Student("1234","Sami","Samuel@gmail.com","S1#sssss");

        utilizatori.Add(profesor);
        utilizatori.Add(student);
        utilizatori.Add(student2);

        bool open = true;

        while (open)
        {
            string optiune;
            Console.WriteLine("0.Exit\n1.Login\n2.Afisare utilizatori\n3.Creare cont student");
            optiune = Console.ReadLine();

            switch (optiune)
            {
                case "0":
                    Fisier.Salvare(Sesiuni, Proiecte,utilizatori);
                    open = false;
                    break;
                case "1":
                {
                    Logare(utilizatori,Sesiuni,Proiecte,Note,profesor,inscris);

                    break;
                }
                case "2":
                {
                    AfisareUtilizator(utilizatori);

                    break;
                }
                case "3":
                {
                    ContNou(utilizatori);
                    break;
                }
            }

            
    }

        
        }

    private static void AfisareUtilizator(List<Utilizator> utilizatori)
    {
        foreach (var U in utilizatori)
        {
            Console.WriteLine($"Numele: {U.NumePrenume}\n email: {U.email}");
        }
    }

    private static Student StudentAuxiliar(List<Utilizator> utilizatori, Student studentauxiliar,string email,string parola)
    {
        studentauxiliar = null;
        foreach (var uu in utilizatori)
        {
            if (email == uu.email && parola == uu.parola)
            {
                studentauxiliar = new Student(uu.numarMatricol, uu.NumePrenume, uu.email, uu.parola);
                return studentauxiliar;
            }
        }
        return studentauxiliar;
    }

    private static void ContNou(List<Utilizator> utilizatori)
    {
        Console.WriteLine("Scrieti numarul matricol");
        string nrmatricol = Console.ReadLine();
        Console.WriteLine("Scrieti numele studentului:");
        string nume = Console.ReadLine();
        Console.WriteLine("Scrieti email-ul contului: ");
        string email = Console.ReadLine();
        Console.WriteLine("Scrieti parola");
        string parola = Console.ReadLine();
                    
        Student StudentNou = new Student(nrmatricol, nume, email, parola);
        utilizatori.Add(StudentNou);
    }
    public static void Logare(List<Utilizator> utilizatori,List<Sesiune> Sesiuni,List<Proiect> Proiecte,List<(string,string)> Note,Profesor profesor,bool inscris)
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
                case Profesor:
                {
                    MeniuProfesor(profesor, Sesiuni, Proiecte);
                    break;
                }

                case Student std:
                {
                    Student studentauxiliar = StudentAuxiliar(utilizatori, std, email, parola);;
                    MeniuStudent(studentauxiliar, Sesiuni, Proiecte,Note,inscris);
                    break;
                }

            }
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
                            profesor.NotareProiect(Proiecte);
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
                        case "9":
                        {
                            John = false;
                            break;
                        }
                }
            }
        }
    static void MeniuStudent(Student student, List<Sesiune> Sesiuni, List<Proiect> Proiecte,List<(string,string)> Note,bool inscris)
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
                                student.InscriereLaSesiune(Sesiuni,inscris);
                                break;
                        }

                        case "2":
                        {
                                student.PredareProiect(Sesiuni, Proiecte, student,inscris);
                                break;
                        }
                        case "3":
                        {
                                student.VizualizareNota(Proiecte,student);
                                break;
                        }
                        case "4":
                        {     
                                student.IstoricNote(Note,Proiecte,student);
                                break;
                        }
                        case "5":
                        {
                                student.Reclamatie(Proiecte);
                                break;
                        }
                        case "6":
                        {
                                Console.WriteLine("V-ati deconectat cu succes" );
                                Mircea = false;
                                break;
                        }
                    }
                }
            }

   
}




