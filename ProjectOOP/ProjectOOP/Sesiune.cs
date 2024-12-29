public class Sesiune
{
    public string Cod_Sesiune { get; set; }
    public string Nume_Sesiune { get; set; }
    public bool IsOpen { get; set; }
    public List<Proiect> Proiecte { get; set; } = new List<Proiect>();

    public void AddProiect(Proiect proiect)
    {
        Proiecte.Add(proiect);
    }

    public void PredareProiect(string student, string continut)
    {
        Proiecte.Add(new Proiect { Student = student, Continut = continut, Nota = 0 });
    }
}