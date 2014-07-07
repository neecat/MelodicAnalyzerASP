using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * assembly: melodicanalyzer.piano
 * file: piano.cs
 * build: melodicanalyzer.dll
 * Written By: Nathanial Karahalis
 * version: 1.011
 * Updated: 7/7/2014
 * Changes: Tweaked octave algorithm slightly to improve accuracy.
*/

namespace melodicanalyzer
{
    public class piano
    {
       //Property Variables for octaves and number of notes, which may be depreciated
       private int octave = 12; //number to + or - based on octave modifier
       private int currentoctave= 4; //the starting octave modifer, it places the keyboard in a useful range to start
       private int modifier = 0; //initialize modifier variable
       public int resonance = 0; //resonation of sound
       public int sound = 0; //sound resonating
       string debugger_output; //debCon stuff
       public Boolean debConEnabled = false;

       private void debCon(string debug)
       {
           if (debConEnabled)
           {
               debugger_output = debugger_output + debug; //add more output to the debugger
           } 
       }
        public string debugouput()
       {
           if (debConEnabled)
           {
               return debugger_output;
           }
           else
           {
               return "debCon not enabled!";
           }
       }
        private void modupdate()
        {
            initialize();
        }
        //Initialize the class piano with a starting octave modifier
        public void initialize()
        {
            if (currentoctave > 0)
            {
                int mod = currentoctave - 1;
                modifier = mod * octave; //subtract 1 from current octave and multiply by octave
                debCon("melodicanalyzer.piano.initialize(): (private int currentoctave - 1) * private int octave\n modifier = " + Convert.ToString(modifier) +
                "= (" + Convert.ToString(currentoctave) + "-1)*" + Convert.ToString(octave) + "\n");
            }
            else
            {
                modifier = currentoctave * octave;
                debCon("melodicanalyzer.piano.initialize(): private int currentoctave * private int octave\n modifier = "+Convert.ToString(modifier)+
                "= "+Convert.ToString(currentoctave)+"*"+Convert.ToString(octave)+"\n");
            }
        }

        //Overload for Initialize that allows starting octave modifier
        public void initialize(int StartingOctave)
        {
            debCon("melodicanalyzer.piano.initialize(int32 StartingOctave) OVERLOADED 1\n");
            changeOctave(StartingOctave); // set the octave to the user defined starting octave
            debCon("melodicanalyzer.piano.changeOctave(int32 StartingOctave);\n");
            initialize(); //set the octave modifier
        }

        //Method to change the octave modifer
        //When the interface moves to a new octave on the keyboard it will call this method
        private void changeOctave(int octavetochangeto)
        {
            debCon("melodicanalyzer.piano.changeOctave(int32 ocatavetochangeto) called.\n");
            currentoctave = octavetochangeto; //change the value of the current selected octave
            modupdate();
            debCon("modupdate();\n");
        }

        //Methods to execute when a key on the piano is pressed down
        public void keydown(string pitch)
        {
            debCon("melodicanalyzer.piano.keydown(string pitch)\n");
            debCon("melodicanalyzer.piano.parseNote(pitch) into string[] notedata\n");
            string[] notedata = parseNote(pitch); //parse the pitch data
            debCon("parsed pitch to "+notedata[0]+" :: "+notedata[1]+" :: "+notedata[2]+"\n");
            int pitchnumber= getPitch(notedata[0]); //make a number from the pitch name
            debCon("getPitch = " + Convert.ToString(pitchnumber) + "; \n");
            changeOctave(Convert.ToInt32(notedata[1])); //change the octave to the one denoted
            resonance = getNeume(notedata[2]);
            debCon("melodicanalyzer.piano.(int) resonance set to " + Convert.ToString(resonance) + "\n");
            sound = pitchnumber + modifier; //set the pitch number to the real pitch value
            debCon("melodicanalyzer.piano.(int) sound set to " + Convert.ToString(sound)+"\n");

        }

        //parse the pitch name
        private string[] parseNote(string pitch)
        {
            //split that pitch string data into 2
            string[] parsedPitchData = pitch.Split(',');
            //Convertthe individual elements into the integer array
            return parsedPitchData;
        }
       
        //translate the pitch human name to an unsigned integer
        private int getPitch(string pitch)
        {
            int pitchInt = 0;
            // create 2 arrays one of human pitch names and an array of numbers with the same ammount of elements
            string[] pitches = { "C", "C#", "Db", "D", "D#", "Eb", "E", "Fb", "F", "F#",
                                   "Gb", "G", "G#", "Ab", "A", "A#", "Bb", "B", "Cb" }; 
            int[] pitchnumbers = { 1, 2, 2, 3, 4, 4, 5, 5, 6, 7, 7,
                                     8, 9, 9, 10, 11, 11, 12, 12 };
            //Loop till you find the element of human name pitches and match it with the pitch
            for (int x = 0; x < 18; x++)
            {
                if (pitches[x] == pitch)
                {
                    pitchInt = pitchnumbers[x]; //set pitchInt to the number associated with the pitch
                    debCon("getPitch("+pitch+") = "+Convert.ToString(pitchInt) + ";\n");
                    debCon("pitches[" + Convert.ToString(x)+"] = "+pitches[x]+" && pitch ="+pitch+";\n");
                    break;
                }
            }
            
            return pitchInt; //return the pitch number
        }
        private int getNeume(string notetype) //get the notehead type
        {
            int neume=0; //define an int variable for notehead length
            string[] noteheads = { "breve", "whole", "half", "quarter", "eigth", "sixteenth",
                                     "thirtysecond", "sixtyfourth", "dottedbreve", "dottedwhole", 
                                     "dottedhalf", "dottedquarter", "dottedeigth", "dottedsixteenth",
                                     "dottedthirtysecond", "dottedsixtyfourth" }; //human readable names for note lengths
            int[] notelengths = { 128, 64, 32, 16, 8, 4, 2, 1, 192,
                                    96, 48, 24, 12, 6, 3, 2 }; //notelengths have to be adjusted a little bit because they need to be integers so 64th note is off alittle bit
            for (int x = 0; x < 16; x++) //search through all 16 notehead elements for the one given
            {
                if (noteheads[x] == notetype) //test eq of string
                {
                    neume = notelengths[x]; //set neume to the note length matched
                    break;
                }
            }
            return neume; //return the neume length as an integer
        }

    }
}
