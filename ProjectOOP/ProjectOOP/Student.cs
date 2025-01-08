 using ConsoleApp1;
 using ProjectOOP;

 public class Student : Utilizator
 {

        public Student(string numarMatricol, string numePrenume, string email, string parola)
            : base(numarMatricol, numePrenume, email, parola)
        {
            
        }

        public void InscriereLaSesiune(List<Sesiune> LSesiune,string cod, Profesor profesor,Proiect proiect)
        {
            foreach (var s in LSesiune)
            {
                if (s.codSesiune == cod && s.isOpen)
                {
                    Console.WriteLine($"Studentul {numePrenume} s-a înscris la sesiunea '{s.numeSesiune}'.");
                }
                else
                {
                    Console.WriteLine("Sesiunea nu este disponibila.");
                }
            }
        }

        public void PredareProiect(List<Sesiune> LSesiune, List<Proiect> LProiecte, string cod, Proiect proiect)
        {
            foreach (var sesiune in LSesiune)
            {
                if (sesiune.codSesiune == cod && sesiune.isOpen)
                {
                    LProiecte.Add(proiect);
                    Console.WriteLine($"Proiectul a fost predat pentru sesiunea '{sesiune.numeSesiune}'.");
                    
                }
                else
                {
                    Console.WriteLine("Proiectul nu poate fi predat.");
                }
            }

           
        }

        public void VizualizareNota(Proiect proiect)
        {
            Console.WriteLine($"Nota proiectului este: {proiect.nota}");
        }

        public void IstoricNote(List<Proiect> LProiecte,string Nume)
        {
            foreach (var proiect in LProiecte)
            {
                if (proiect.Student == Nume)
                {
                    Console.WriteLine($"Proiectul studentului: {proiect.Student} are nota: {proiect.nota}");
                }
            }
        }

        public void Reclamatie(List<Proiect> Lreclamatii, Proiect pr)
        {
            foreach (var sr in Lreclamatii)
            {
                if (sr.Student == pr.Student && sr.numeProiect == pr.numeProiect)
                {
                    Console.WriteLine("Reclamatie: ");
                    pr.reclamatie = Console.ReadLine();
                    Lreclamatii.Add(pr);
                }
                else
                {
                    Console.WriteLine("Nu exista numele proiectului sau studentul.");
                }
            }
        }
        
    }
