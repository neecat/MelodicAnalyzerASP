using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using melodicanalyzer;
namespace Melodic_Analyzer_ASP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        piano steinway = new piano();
        Melody sequence = new Melody();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            steinway.initialize(); //init the steinway
            steinway.keydown("C,4,eigth"); //press a keydown
            sequence.addNote(steinway.sound, steinway.resonance); //record the data reported by the keydown
            steinway.keydown("B,3,eigth"); //...
            sequence.addNote(steinway.sound, steinway.resonance);
            steinway.keydown("D,4,eigth"); //press a keydown
            sequence.addNote(steinway.sound, steinway.resonance); //record the data reported by the keydown
            steinway.keydown("E,4,eigth"); //...
            sequence.addNote(steinway.sound, steinway.resonance);
            steinway.keydown("D,4,eigth"); //press a keydown
            sequence.addNote(steinway.sound, steinway.resonance); //record the data reported by the keydown
            steinway.keydown("C,4,eigth"); //...
            sequence.addNote(steinway.sound, steinway.resonance);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             for(int x=0;x<sequence.numberofnotes;x++)
             {
                 MAView.Series["Series1"].Points.AddY(Convert.ToDouble(sequence.pitches[x]));
                 TextBox1.Text = steinway.debugouput();
             }
        }
    }
}