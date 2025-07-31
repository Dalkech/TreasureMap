// See https://aka.ms/new-console-template for more information
using Application;
using ConsoleApp.LineValidation;
using System.IO;

const string path = "/TreasureMap.Input.txt";

static IEnumerable<string> ReadTreasureMapInputFile()
{
    using (var reader = new StreamReader(path))
    {
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}

Console.WriteLine("La Carte au trésor");
Console.WriteLine("... Lecture du Fichier /TreasureMap.Input.txt");

LineParser parser = new LineParser();
foreach(string line in ReadTreasureMapInputFile())
    parser.Parse(line);

Console.WriteLine("... Fin de lecture, lancement du jeu");

PlayGameFromFileRequest request = new (
    parser.MapLineData,
    parser.TreasureLines,
    parser.MontainLines,
    parser.PlayerLines
    );

PlayGameFromFile playGameFromFile = new();
PlayGameFromFileResponse response = playGameFromFile.Handle(request);

