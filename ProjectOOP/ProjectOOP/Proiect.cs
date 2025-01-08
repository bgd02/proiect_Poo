public class Proiect
{
    public string Student { get; set; }
    public string numeProiect { get; set; }
    public int nota { get; set; }
    public string reclamatie { get; set; }
    public List<Proiect> Lreclamatii { get; set; } = new List<Proiect>();
    public Proiect(string student, string numeProiect, int nota, string reclamatie)
    {
        this.Student = student;
        this.numeProiect = numeProiect;
        this.nota = nota;
        this.reclamatie = reclamatie;
    }
    
    
   
}