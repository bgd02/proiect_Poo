 using ConsoleApp1;
 using ProjectOOP;

 public class Student : Utilizator
 {

        public Student(string numarMatricol, string numePrenume, string email, string parola)
            : base(numarMatricol, numePrenume, email, parola)
        {
            
        }

        public void InscriereLaSesiune(List<Sesiune> LSesiune)
        {
            Console.WriteLine("Introduceti codul sesiunii la care doriti sa va inscrieti : ");
            string cod = Console.ReadLine();
            
            foreach (var s in LSesiune)
            {
                if (s.codSesiune == cod && s.isOpen)
                {
                    Console.WriteLine($"Studentul {numePrenume} s-a înscris la sesiunea '{s.numeSesiune}'.");
                    break;
                }
                else
                {
                    Console.WriteLine("Sesiunea nu este disponibila.");
                }
            }
        }

        
        public void PredareProiect(List<Sesiune> LSesiune, List<Proiect> LProiecte,Student student)
        {
            Console.WriteLine("Introduceti codul sesiunii la care doriti sa va predati proiectul : ");
            string cod = Console.ReadLine();
            
            foreach (var sesiune in LSesiune)
            {
                if (sesiune.codSesiune == cod && sesiune.isOpen)
                {
                    
                Console.WriteLine("Introduceti numele proiectului pe care doriti sa il incarcati : ");
                string numeProiect = Console.ReadLine();
                
                var proiect2 = new Proiect(student.numePrenume, numeProiect, "---", "---");
                
                Console.WriteLine($"{proiect2.Student} -> {proiect2.numeProiect} -> {proiect2.nota}");
                    
                LProiecte.Add(proiect2);
                    
                Console.WriteLine($"Proiectul a fost predat pentru sesiunea '{sesiune.numeSesiune}'.");
                    
                }
                
                else
                {
                    Console.WriteLine("Proiectul nu poate fi predat.");
                }
            }

           
        }

        public void VizualizareNota(List<Proiect> LProiecte)
        {
            foreach (var P in LProiecte )
            {
                Console.WriteLine($"Nota studentului {P.Student} este: {P.nota} ");
            }
            
        }

        public void IstoricNote(List<(string,string)> LNote,List<Proiect> LProiecte)
        {
            foreach (var PR in LProiecte)
            {
                LNote.Add((PR.Student,PR.nota));
            }

            foreach (var PR in LNote)
            {
                Console.WriteLine($"Studentul:{PR.Item1}\nNota:{PR.Item2}");
            }
            
        }

        public void Reclamatie(List<Proiect> LProiecte)
        {
            Console.WriteLine("Studentul care lasa reclamatia :");
            string nume=Console.ReadLine();
            foreach (var sr in LProiecte)
            {
                if (sr.Student == nume && int.TryParse(sr.nota, out int nota) && nota >= 1 && nota <= 10)
                {
                    
                    Console.WriteLine("Introduceti reclamatia: ");
                    sr.reclamatie = Console.ReadLine();
                    if (sr.reclamatie.Length<5)
                    {
                        sr.reclamatie = "---";
                    }
                    
                }
                else
                {
                    Console.WriteLine("Nu exista numele proiectului sau studentului.");
                }
            }
        }
        
    }
