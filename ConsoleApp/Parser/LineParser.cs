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
    internal class LineParser
    {
        private bool firstParse = true;
        public MapLineData MapLineData { get; set; } = default!;
        public List<MontainLineData> MontainLines { get; set; } = [];
        public List<TreasureLineData> TreasureLines { get; set; } = [];
        public List<PlayerLineData> PlayerLines { get; set; } = [];

        private bool IsIgnorable(string line) => 
            line == string.Empty 
            || line[0] == '#';        

        internal void Parse(string line)
        {
            if (IsIgnorable(line))
                return;

            char firstChar = line[0];

            if (firstParse && firstChar != 'C')
                throw new ArgumentException(
                    "la première ligne du fichier doit $etre la ligne de paramètrage de la carte\n C - <largeur(int)> - <hauteur(int)>"
                    );
            else
            {
                new ParsingMapStrategy(this).Execute(line);
                firstParse = false;
            }

            IParsingLineStrategy lineStrategy =
                firstChar switch
                {
                    'M' => new ParsingMontainStrategy(this),
                    'T' => new ParsingTreasureStrategy(this),
                    'P' => new ParsingPlayerStrategy(this),
                    _ => throw new ArgumentException(string.Format("Ligne Innatendue dans le fichier :\n{0}", line))
                };
            
            lineStrategy.Execute(line);
        }
    }
}
