using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * assembly: melodicanalyzer.melody
 * file: melodyanalyzer.cs
 * build: melodicanalyzer.dll
 * Written By: Nathanial Karahalis
 * version: 1.01
 * Updated: 7/5/2014
*/
namespace melodicanalyzer
{
    /* Melody is a basic object only containing data for constructing the melody given
     * and enough functionality to add notes to those variables.
     */
    public class Melody
    {
        public int[] pitches= new int[256]; //an array for integer pitch values
        public int numberofnotes = 0;
        public void addNote(int note,int length)
        {
            for (int x = 0; x < length; x++)
            {
                pitches[numberofnotes] = note;
                numberofnotes++;
            }
        }
        
    }
}