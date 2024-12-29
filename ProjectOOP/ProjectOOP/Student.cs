 using ConsoleApp1;

 public class Student : Utilizator
    {
        public List<(string Proiect, int Nota)> Note { get; set; }

        public Student(string numarMatricol, string numePrenume, string email, string parola)
            : base(numarMatricol, numePrenume, email, parola)
        {
            Note = new List<(string Proiect, int Nota)>();
        }

        public void InscriereLaSesiune(string cod, Profesor profesor)
        {
            foreach (var sesiune in profesor.Sesiuni)
            {
                if (sesiune.Cod_Sesiune == cod && sesiune.IsOpen)
                {
                    sesiune.AddProiect(new Proiect { Student = numePrenume, Continut = "", Nota = 0 });
                    Console.WriteLine($"Studentul {numePrenume} s-a înscris la sesiunea '{sesiune.Nume_Sesiune}'.");
                    return;
                }
            }
            Console.WriteLine("Sesiunea nu este disponibila.");
        }

        public void PredareProiect(string cod, Profesor profesor, string proiect)
        {
            foreach (var sesiune in profesor.Sesiuni)
            {
                if (sesiune.Cod_Sesiune == cod && sesiune.IsOpen)
                {
                    sesiune.PredareProiect(numePrenume, proiect);
                    Console.WriteLine($"Proiectul a fost predat pentru sesiunea '{sesiune.Nume_Sesiune}'.");
                    return;
                }
            }
            Console.WriteLine("Nu s-a putut preda proiectul.");
        }

        public override string showMenu()
        {
            string opt;
            bool meniu = true;
            do
            {
                Console.WriteLine("Alegeti o optiune: ");
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "0":
                        Console.WriteLine("0. Iesire");
                        return "Ati iesit din meniu";
                    case "1": Console.WriteLine("1. Inscriere sesiune"); break;
                    case "2": Console.WriteLine("2. Predare proiect"); break;
                    case "3": Console.WriteLine("3. Vizualizare nota"); break;
                    case "4": Console.WriteLine("4. Istoric note"); break;
                    case "5": Console.WriteLine("5. Reclamatii nota proiect"); break;
                }
            } while (meniu);

            return "Meniul s-a terminat";
        }
    }
