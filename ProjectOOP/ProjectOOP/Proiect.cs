public class Proiect
{
    public string Student { get; set; }
    public string numeProiect { get; set; }
    public string nota { get; set; }
    public string reclamatie { get; set; }
    
    public Proiect(string student, string numeProiect, string nota, string reclamatie)
    {
        this.Student = student;
        this.numeProiect = numeProiect;
        this.nota = nota;
        this.reclamatie = reclamatie;
    }
    
    
   
}