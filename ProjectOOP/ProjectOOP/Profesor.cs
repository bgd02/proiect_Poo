using ConsoleApp1;

public class Profesor : Utilizator
{
    

    public Profesor(string numarMatricol, string numePrenume, string email, string parola)
        : base(numarMatricol, numePrenume, email, parola)
    {
    }

    public void DeschideSesiunea(List<Sesiune> sesiune,List<Proiect> proiecte, string codSesiune, Sesiune Sesiune, Proiect proiect)
    {
        if (sesiune.Exists(s => s.codSesiune == codSesiune))
        {
            Console.WriteLine("Sesiunea deja exista.");
        }
        else
        {
            sesiune.Add(Sesiune);
            proiecte.Add(proiect);
            Console.WriteLine("Sesiunea a fost deschisa.");
        }
    }
    
    public void InchideSesiunea(List<Sesiune> sesiune, List<Proiect> proiecte, Sesiune Sesiune, Proiect proiect)
    {
            sesiune.Remove(Sesiune);
            proiecte.Remove(proiect);
            Console.WriteLine("Sesiunea a fost inchisa!");
    }
    public void VizualizareProiect(List<Proiect>LProiecte)
    {
        foreach (var proiect in LProiecte)
        {
            Console.WriteLine($"Numele studentului: {proiect.Student}, Numele proiectului: {proiect.numeProiect}, Nota: {proiect.nota}, Reclamatie: {proiect.Lreclamatii}");
        }
    }

    public void NotareProiect(List<Proiect> Nota,Proiect proiect, int nota)
    {
        proiect.nota = nota;
        Nota.Add(proiect);
    }
    
    /*public void AddSesiune(Sesiune sesiune)
    {
        Sesiuni.Add(sesiune);
    }*/

    public void AdaugaReclamatii(List<Proiect> Lreclamatii, Proiect p)
    {
        Lreclamatii.Add(p);
    }

    public void RaspunsReclamatii(List<Proiect> proiecte)
    {
        foreach (var r in proiecte)
        {
            if (r.Lreclamatii != null)
            {
                Console.WriteLine($"Reclamatie: {r.reclamatie}");
                string raspunsReclamatii = Console.ReadLine();
                Console.WriteLine($"Raspunsul reclamatiei: {raspunsReclamatii}");
            }
            else
            {
                Console.WriteLine("Nu exista reclamatii.");
            }
        }
    }
            
    public void ModificareNotaProiect(List<Proiect> proiecte, string numeStudent)
    {
        foreach (var m in proiecte)
        {
            if (m.Student == numeStudent)
            {
                Console.WriteLine("Profesorul reexamineaza nota...");
                m.nota = int.Parse(Console.ReadLine());
                Console.WriteLine($"Nota a fost modificata : {m.nota}");
            }
        }
    }

    public void AfiseazaInformatii()
    {
        Console.WriteLine($"Nume: {NumePrenume} -> Numar Matricol: {numarMatricol} -> Email: {email}");
    }
}
    
    
