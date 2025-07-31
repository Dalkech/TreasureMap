using ConsoleApp.LineValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.Parser
{
    internal abstract class BaseParsingLineStrategy(LineParser parser)
    {
        protected LineParser _parser = parser;
        protected static Match ParseLine(string line, string pattern)
        {
            Match match = Regex.Match(line, pattern);

            if (match.Success)
                return match;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Erreur(s) pour la ligne '{0}'", line);

            for (int i = 0; i < match.Groups.Count; i++)
            {
                Group group = match.Groups[i];

                if (group.Success)
                    continue;

                sb.AppendFormat(",pour \"{0}\" valeur {1}", group.Name, group.Value);
            }
            throw new ArgumentException(sb.ToString());
        }
    }
}
