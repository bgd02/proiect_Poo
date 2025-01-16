public class Sesiune
{
    public string codSesiune { get; private set; }
    public string numeSesiune { get; private set; }
    public bool isOpen { get;  set; }
   
    public Sesiune(string codSesiune, string numeSesiune, bool isOpen)
    {
        this.codSesiune = codSesiune;
        this.numeSesiune = numeSesiune;
        this.isOpen = isOpen;
    }
    
  
    
}
