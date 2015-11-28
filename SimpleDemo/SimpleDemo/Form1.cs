using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;

namespace SimpleDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The handler to change the Text in the comboBox
        void ser_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            comboBox1.Text = e.Result.Text;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a Speech Recognition Engine instance
            // Notice: Need to add reference "System.Speech" in your project. Right click on the Reference on your Solution Explorer and add.
            // Notice: Include namespace System.Speech.Recognition
            SpeechRecognizer recognizer = new SpeechRecognizer();
            // Create a grammar with several words. We need 
            Choices colors = new Choices();
            colors.Add(new String[] { "right wing", "left wing", "vertical stabilizer", "elevator", "winglet", "horizontal stabilizer", "engine", "slats", "transmission" });
            // Create a GrammarBuilder object and append the Choices object
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);
            // Create a new Grammar and load it into speech recognition engine
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);
            // Register a handler for the SpeechRecognized event, which defined in ser_SpeechRecognized
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(ser_SpeechRecognized);
        }
    }
}
