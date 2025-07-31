using Application.LineData;
using ConsoleApp.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.LineValidation
{
    public class LineParser
    {
        private bool firstParse = true;
        public MapLineData MapLineData { get; set; } = default!;
        public List<MontainLineData> MontainLines { get; set; } = [];
        public List<TreasureLineData> TreasureLines { get; set; } = [];
        public List<PlayerLineData> PlayerLines { get; set; } = [];

        private bool IsIgnorable(string line) =>
            string.IsNullOrEmpty(line)
            || line[0] == '#'
            || line[0] == ' ';

        public void Parse(string line)
        {
            if (IsIgnorable(line))
                return;

            char firstChar = line[0];
            
            if (firstParse)
            {
                if (firstChar != 'C')
                    throw new ArgumentException(
                        "la première ligne du fichier doit être la ligne de paramètrage de la carte\n C - <largeur(int)> - <hauteur(int)>"
                        );
                else { 
                    new ParsingMapStrategy(this).Execute(line);
                    firstParse = false;
                    return;
                }
            }

            IParsingLineStrategy lineStrategy =
                firstChar switch
                {
                    'M' => new ParsingMontainStrategy(this),
                    'T' => new ParsingTreasureStrategy(this),
                    'A' => new ParsingPlayerStrategy(this),
                    _ => throw new ArgumentException(string.Format("Ligne Innatendue dans le fichier :\n{0}", line))
                };
            
            lineStrategy.Execute(line);
        }

        internal bool HasData()
        {
            return this.MapLineData != null;
        }
    }
}
