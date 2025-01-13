public class Sesiune
{
    public string codSesiune { get; private set; }
    public string numeSesiune { get; private set; }
    public bool isOpen { get;  set; }
    public List<Proiect> LProiecte = new List<Proiect>();
   
    public Sesiune(string codSesiune, string numeSesiune, bool isOpen)
    {
        this.codSesiune = codSesiune;
        this.numeSesiune = numeSesiune;
        this.isOpen = isOpen;
    }
    
    public void isOpenSesion()
    {
        isOpen = true;
    }

    public void isClosed()
    {
        isOpen = false;
    }

    public override string ToString()
    {
        return $"Sesiune: {numeSesiune} (Cod: {codSesiune}, : {isOpen})";
    }

    public void AdaugaProiect(Proiect proiect)
    {
        LProiecte.Add(proiect);
        Console.WriteLine("Ati adaugat proiectul cu succes");
    }
    
    
}
