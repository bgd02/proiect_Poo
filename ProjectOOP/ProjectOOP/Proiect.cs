public class Proiect
{
    public string Student { get; set; }
    public string Continut { get; set; }
    public int nota { get; set; }
    public string reclamatie { get; set; }

    public Proiect(string student, string continu, int nota, string reclamatie)
    {
        this.Student = student;
        this.Continut = continu;
        this.nota = nota;
        this.reclamatie = reclamatie;
    }
    
    
    
}