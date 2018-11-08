using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace PlayGit
{
    class Program
    {
        static string PlayNote(Tone tone)
        {
            if(tone == null) {
                return null;
            }
            var result = $"play -n synth {tone.Lenght} triangle {tone.Note}{tone.Scale} fade 0 0 {tone.Lenght/3} >/dev/null 2>&1";
            return result;
        }

        public static string GetNote(string line)
        {
            int n = line.IndexOf("*");
            if(n < 0)
            {
                 return "-";
            }
            return Music.Notes[n % Music.Notes.Length];
        }

        static void Main(string[] args)
        {
            var graphParser = new GraphParser((tone) => PlayNote(tone).Bash());

            string line;
            while ((line = Console.ReadLine()) != null && line != "") {
                Console.WriteLine(line);
                graphParser.ProcessLine(line);
            }
        }
    }
}
