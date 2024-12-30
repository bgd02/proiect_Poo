using ConsoleApp1;

public class Profesor : Utilizator
{
    public List<Sesiune> Sesiuni { get; set; } = new List<Sesiune>();

    public Profesor(string numarMatricol, string numePrenume, string email, string parola)
        : base(numarMatricol, numePrenume, email, parola)
    { }

    public void DeschideSesiunea(List<Sesiune> sesiune, string codSesiune, Sesiune Sesiune)
    {
        if (sesiune.Exists(s => s.codSesiune == codSesiune))
        {
            Console.WriteLine("Sesiunea deja exista.");
        }
        sesiune.Add(Sesiune);
        Console.WriteLine("Sesiunea a fost deschisa.");
    }

    public void InchideSesiunea(List<Sesiune> sesiune, string codSesiune, Sesiune Sesiune)
    {
        if (Sesiune.codSesiune == codSesiune)
        {
            sesiune.Remove(Sesiune);
            Console.WriteLine("Sesiunea a fost inchisa!");
        }
    }
    public void Vizualizare_Proiect(List<Proiect>LProiecte)
    {
        foreach (var proiect in LProiecte)
        {
            Console.WriteLine($"Numele studentului: {proiect.Student}, Continutul proiectului: {proiect.Continut}, Nota: {proiect.nota}, Reclamatie: {proiect.reclamatie}");
        }
    }

    public void notare(List<(Proiect,int)> Nota,Proiect proiect, int nota)
    {
        proiect.nota = nota;
        Nota = new List<(Proiect proiect, int Nota)>();
    }
    
    public void AddSesiune(Sesiune sesiune)
    {
        Sesiuni.Add(sesiune);
    }

    public void RaspunsReclamatii(List<Proiect> proiecte)
    {
        foreach (var r in proiecte)
        {
            if (r.reclamatie != null)
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
                Console.WriteLine($"Nota a fost modificata, nota este {m.nota}");
            }
        }
    }
    
    
}
    
    
