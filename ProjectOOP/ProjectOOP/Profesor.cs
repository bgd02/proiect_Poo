using System.Threading.Channels;
using ConsoleApp1;

public class Profesor : Utilizator
{
    

    public Profesor( string numePrenume, string email, string parola)
        : base( numePrenume, email, parola)
    {
    }

    
    public void RaspunsReclamatii(List<Proiect>LProiecte)
    {
        foreach (var RE in LProiecte)
        {
            if (RE.reclamatie.Length < 5)
            {
                Console.WriteLine("Nu exista reclamatii");
            }
            else
            {
                Console.WriteLine($"Reclamatia este: {RE.reclamatie}");
                Console.WriteLine("Introduceti raspunsul reclamatiei: ");
                string reclamatie = Console.ReadLine();

                Console.WriteLine($"{reclamatie}");

            }

        }

    }
    public void ModificareNotaProiect(List<Proiect> proiecte)
    {
        Console.WriteLine("Introduceti Numele studentului caruia doriti sa-i schimbati nota");
        string numeStudent=Console.ReadLine();

        foreach (var m in proiecte)
        {
            if (m.Student == numeStudent)
            {
                Console.WriteLine("Profesorul reexamineaza nota...");
                m.nota = Console.ReadLine();
                Console.WriteLine($"Nota a fost modificata : {m.nota}");
                break;
            }

            Console.WriteLine("Studentul nu a fost gasit;");
        }
    }
    public void DeschideSesiunea(List<Sesiune> sesiuni)
    {
        string codSesiune;
        Console.WriteLine("Codul Sesiunii: ");
        codSesiune = Console.ReadLine();

        string numeSesiune;
        Console.WriteLine("Numele sesiunii: ");
        numeSesiune = Console.ReadLine();

        Sesiune sesiune = new Sesiune(codSesiune, numeSesiune, true);
        if (sesiuni.Exists(s => s.codSesiune == codSesiune))
        {
            sesiune.isOpen=true;
            Console.WriteLine("Sesiunea deja exista si a fost deschisa."); 
        }
        else
        {
            sesiuni.Add(sesiune);
            Console.WriteLine("Sesiunea a fost deschisa.");
        }
        
    }
    
    public void InchideSesiunea(List<Sesiune> sesiune)
    {
        Console.WriteLine("Introduceti codul sesiunii pe care doriti sa o stergeti: ");
        string codSesiune = Console.ReadLine();
        bool sesiuneGasita = false;

        for (var i = 0; i < sesiune.Count; i++)
        {
            if (sesiune[i].codSesiune == codSesiune)
            {
                sesiuneGasita = true;

                Console.WriteLine("Sesiunea dumneavoastra a fost inchisa\nDoriti sa stergeti sesiunea?\nApasati tasta:\n0.Stergere\n1.Pastrare");
                string opt = Console.ReadLine();

                if (opt == "0")
                {
                    Console.WriteLine($"Sesiunea cu codul {codSesiune} a fost stearsa.");
                    sesiune.RemoveAt(i); 
                    
                }
                else if (opt == "1")
                {
                    sesiune[i].isOpen = false; 
                    Console.WriteLine("Sesiunea a ramas inchisa.");
                    
                }
            }
        }

        if (!sesiuneGasita)
        {
            Console.WriteLine("Nu exista codul introdus.");
        }
    }

    public void VizualizareProiect(List<Proiect>LProiecte)
    {
        foreach (var proiect in LProiecte)
        {
            Console.WriteLine($"Numele studentului: {proiect.Student}, Numele proiectului: {proiect.numeProiect}, Nota: {proiect.nota}, Reclamatie: {proiect.reclamatie}");
        }
    }

    public void VizualizareLista(List<Sesiune> LSesiune)
    {
        foreach (var s in LSesiune)
        {
            Console.WriteLine($"{s.codSesiune} -> {s.numeSesiune}");
        }
        
    }
    public void NotareProiect(List<Proiect> LProiecte)
    {
        Console.WriteLine("Introdusceti numele studentului pe care dortiti sa-l notati");
        string nume=Console.ReadLine();
        string gasit = "0";
        foreach (var Pr in LProiecte)
        {
            if (Pr.Student ==nume  && Pr.nota=="---")
            {
                Console.WriteLine($"Introduceti nota pentru studentul {Pr.Student} care are proiectul:\n{Pr.numeProiect} ");
                string notastd = Console.ReadLine();
                Pr.nota = notastd;
                Console.WriteLine($"Nota studentului {Pr.Student} este {Pr.nota}");
                gasit = "1";
            }
        }

        if (gasit == "0")
        {
            Console.WriteLine("Studentul a fost deja notat");
        }
    }
}
    
    
