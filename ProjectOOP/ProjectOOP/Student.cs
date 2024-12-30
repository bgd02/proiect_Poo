 using ConsoleApp1;

 public class Student : Utilizator
 {
     public List<(Proiect proiect, int Nota)> Note;

        public Student(string numarMatricol, string numePrenume, string email, string parola)
            : base(numarMatricol, numePrenume, email, parola)
        {
            Note = new List<(Proiect proiect, int Nota)>();
        }

        public void InscriereLaSesiune(List<Sesiune> LSesiune,string cod, Profesor profesor,Proiect proiect)
        {
            foreach (var s in LSesiune)
            {
                if (s.codSesiune== cod && s.isOpen)
                {
                    Console.WriteLine($"Studentul {numePrenume} s-a înscris la sesiunea '{s.numeSesiune}'.");
                    return;
                }
            }
            Console.WriteLine("Sesiunea nu este disponibila.");
        }
        
        public void PredareProiect(List<Sesiune> LSesiune,List<Proiect> LProiecte,string cod, Proiect proiect)
        {
            foreach (var sesiune in LSesiune)
            {
                if (sesiune.codSesiune == cod && sesiune.isOpen)
                {
                    LProiecte.Add(proiect);
                    Console.WriteLine($"Proiectul a fost predat pentru sesiunea '{sesiune.numeSesiune}'.");
                    return;
                }
            }
            Console.WriteLine("Nu s-a putut preda proiectul.");
        }

        public void ViewGrade(Proiect proiect)
        {
            Console.WriteLine($"Nota proiectului este: {proiect.nota}");
        }

        public void ViewGradeHistory(List<(Proiect,int)> LProiecte,string Nume)
        {
            foreach (var proiect in LProiecte)
            {
                if (proiect.Item1.Student == Nume)
                {
                    Console.WriteLine($"Proiectul studentului: {proiect.Item1.nota} are nota: {proiect.Item2}");
                }
            }
        }
      
        
    }
