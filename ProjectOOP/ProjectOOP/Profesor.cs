using System.Threading.Channels;

namespace ProjectOOP;
public class Profesor:Utilizator
{
    public Profesor(string numarMatricol, string numePrenume, string email, string parola) :
        base(numarMatricol,numePrenume,email,parola)
    {
        
    }
    
    
    public override string showMenu()
    {

        string opt;
        bool meniu=true;
        do
        {
            Console.WriteLine("Alegeti o optiune: ");
            opt = Console.ReadLine();
            switch (opt)
            {
                case "0": Console.WriteLine("0.Iesire");
                    return "Ati iesit din meniu"; 
                case "1": Console.WriteLine("1.Deschidere sesiune"); break;
                case "2": Console.WriteLine("2.Inchidere sesiune"); break;
                case "3": Console.WriteLine("3.Notare studenti"); break;
                case "4": Console.WriteLine("4.Raspuns reclamatii"); break;
                case "5": Console.WriteLine("5.Modificare nota"); break;
            }
            
            
        } while (meniu);

        return "Meniul sa terminat ";
    }
}