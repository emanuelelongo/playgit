using System;
using System.Text;

namespace PlayGit
{
    public class Tone
    {
        public string Note {get;set;}
        public float Lenght {get;set;}
        public int Scale {get;set;}

        public Tone()
        {
            Reset();
        }
        public void Reset()
        {
            Note = null;
            Lenght = 0;
            Scale = 4;
        }

        public Tone Clone()
        {
            return new Tone 
            {
                Note = this.Note,
                Lenght = this.Lenght,
                Scale = this.Scale
            };
        }
    }

    public class GraphParser
    {
        private Action<Tone> emitter;
        private Tone currentTone = null;

        public GraphParser(Action<Tone> emitter)
        {
            this.emitter = emitter;
            currentTone = new Tone();
        }

        private (string, int) NoteFromLine(string line)
        {
            var starPosition = line.IndexOf("*");
            if(starPosition >= 0)
            {
                int scale = 4+(int)Math.Floor((starPosition/2)/12F);
                return (Music.Notes[((int)starPosition/2)%12], scale);
            }
            return (null, 0);
        }

        public void ProcessLine(string line)
        {
            var (note, scale) = NoteFromLine(line);

            // ToDo: not a note. Change something in current tone.
            if(note == null)
            {   
                return;
            }

            // found a different note from current.
            // the current one can be emitted
            if(currentTone.Note != note)
            {
                emitter(currentTone.Clone());
                currentTone.Reset();
            }

            currentTone.Note = note;
            currentTone.Scale = scale;
            if(currentTone.Lenght < 1)
            {
                currentTone.Lenght+=0.1F;
            }
             
        }
    }
}
