using System.Collections.Concurrent;
using System.Runtime.Intrinsics.Arm;
using Microsoft.VisualBasic.FileIO;

namespace ProjectOOP;

public  class Profesor : Utilizator
{
    public Profesor(string numarMatricol, string numePrenume, string email, string parola) : base(numarMatricol,
        numePrenume, email, parola)
    {

    }

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

    public void VizualizareaListei(List<Sesiune> sesiune, string codSesiune, string numeSesiune, bool isOpen)
    {
        foreach (var ses in sesiune)
        {
            Console.WriteLine($"Nume sesiune: {ses.numeSesiune} -> Cod sesiune: {ses.codSesiune} -> Activ: {ses.isOpen}");
        }
    }

    public void NotareProiectSesiune(List<Proiect> proiecte)
    {
        int notaProiect;
        foreach (var n in proiecte)
        {
            Console.WriteLine($"Nume{n.Student} continut {n.Continut}");
            notaProiect = int.Parse(Console.ReadLine());
            n.nota = notaProiect;
            Console.WriteLine($"Nota {n.nota} a fost acordata studentului {n.Student}");
        }
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
    
    
