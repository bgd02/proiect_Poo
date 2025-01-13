using System.Threading.Channels;
using ConsoleApp1;

public class Profesor : Utilizator
{
    

    public Profesor(string numarMatricol, string numePrenume, string email, string parola)
        : base(numarMatricol, numePrenume, email, parola)
    {
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
            Console.WriteLine("Sesiunea deja exista."); 
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
                    break; 
                }
                else if (opt == "1")
                {
                    sesiune[i].isOpen = false; 
                    Console.WriteLine("Sesiunea a ramas inchisa.");
                    break; 
                }
            }
        }

        if (!sesiuneGasita)
        {
            Console.WriteLine("Nu exista codul introdus.");
        }
    }

  

    public void VizualizareLista(List<Sesiune> LSesiune)
    {
        foreach (var s in LSesiune)
        {
            Console.WriteLine($"{s.codSesiune} -> {s.numeSesiune}");
        }
        
    }
    public void NotareProiect(Proiect n)
    {
        Console.WriteLine($"Introduceti nota pentru studentul {n.Student}");
        string notastd = Console.ReadLine();
        
        n.nota = notastd;
        
        Console.WriteLine($"Nota studentului {n.Student} este {n.nota}");
    }
    
  

   
  

    public void AfiseazaInformatii()
    {
        Console.WriteLine($"Nume: {NumePrenume} -> Numar Matricol: {numarMatricol} -> Email: {email}");
    }
}
    
    
