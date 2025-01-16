using ConsoleApp1;

namespace ProjectOOP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Fisier
{
    private const string FilePath = "data.json";

    public static void Salvare(List<Sesiune> sesiuni, List<Proiect> proiecte,List<Utilizator> utilizator)
    {
        try
        {
            var data = new
            {
                Sesiuni = sesiuni,
                Proiecte = proiecte,
                Utilizator=utilizator
            };

            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, jsonString);
            Console.WriteLine("Starea a fost salvată cu succes.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Eroare: Nu aveți permisiunea de a scrie în fișier.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Eroare de I/O");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"");
        }
    }

    public static (List<Sesiune>, List<Proiect>,List<Utilizator>) Incarcare()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Fișierul nu există.");
                return (new List<Sesiune>(), new List<Proiect>(),new List<Utilizator>());
            }

            string jsonString = File.ReadAllText(FilePath);
            var data = JsonSerializer.Deserialize<dynamic>(jsonString);

            var sesiuni = JsonSerializer.Deserialize<List<Sesiune>>(data["Sesiuni"].ToString());
            var proiecte = JsonSerializer.Deserialize<List<Proiect>>(data["Proiecte"].ToString());
            var utilizator = JsonSerializer.Deserialize<List<Utilizator>>(data["Utilizator"].ToString());
            
            Console.WriteLine("Starea a fost încărcată cu succes.");
            return (sesiuni, proiecte, utilizator);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Eroare: Nu aveți permisiunea de a citi din fișier.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Eroare: Fișierul nu a fost găsit.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Eroare la procesarea JSON:");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"");
        }

        return (new List<Sesiune>(), new List<Proiect>(),new List<Utilizator>());
    }
    
}