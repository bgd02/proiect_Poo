namespace ProjectOOP;

public class Sesiune
{
    public string codSesiune { get; private set; }
    public string numeSesiune { get; private set; }
    public bool isOpen { get; private set; }
    public List<Proiect> proiecte = new List<Proiect>();
    
    public Sesiune(string codSesiune, string numeSesiune, bool isOpen)
    {
        this.codSesiune = codSesiune;
        this.numeSesiune = numeSesiune;
        this.isOpen = true;
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

    public void AdaugaProiect(string numeSesiune, string codSesiune)
    {
        
    }
    
    
}
