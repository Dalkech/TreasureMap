// See https://aka.ms/new-console-template for more information
using Application;
using ConsoleApp.LineValidation;
using ConsoleApp.Serializer;
using System.IO;

const string path = "../../../../ConsoleApp/TreasureMap.Input.txt";
const string outputPath = "../../../../ConsoleApp/TreasureMap.Output.txt";

static IEnumerable<string> ReadTreasureMapInputFile()
{
    using (var reader = new StreamReader(path))
    {
        string? line;
        while ((line = reader.ReadLine()) != null)
            yield return line;
    }
}

static void WriteOutput(PlayGameFromFileResponse response) {
    using (var writer = new StreamWriter(outputPath, append: false))
    {
        foreach (var line in TreasureMapTxtSerializer.SerilizeResponse(response))
        {
            writer.WriteLine(line);
        }
    }
}

Console.WriteLine("La Carte au trésor");
Console.WriteLine("... Lecture du Fichier TreasureMap.Input.txt");

LineParser parser = new LineParser();
foreach(string line in ReadTreasureMapInputFile())
    parser.Parse(line);

if (!parser.HasData())
    throw new ArgumentException("Le fichier en entrée est vide");

Console.WriteLine("... Fin de lecture, lancement du jeu");

PlayGameFromFileRequest request = new (
    parser.MapLineData,
    parser.TreasureLines,
    parser.MontainLines,
    parser.PlayerLines
);

PlayGameFromFile playGameFromFile = new();
PlayGameFromFileResponse response = playGameFromFile.Handle(request);
WriteOutput(response);
