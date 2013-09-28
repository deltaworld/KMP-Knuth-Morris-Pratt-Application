using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenderApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        List<int> pi = new List<int> { 0, 0, 0, 1, 2, 3 };
        String input = "abxyab";

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            label1.Text = "i";
            label2.Text = "S[i]";
            label3.Text = "pi[i]";

            result_table.RowCount = 1;
            result_table.Controls.Add(label1, 0, result_table.RowCount);
            result_table.Controls.Add(label2, 1, result_table.RowCount);
            result_table.Controls.Add(label3, 2, result_table.RowCount);
            render(pi, input);
            
        }
        private void render(List<int> pi, string input) // tareq output function.
        {

            /* Debug */
            //pi.ForEach(i => Console.Write("{0}\t", i));       // output all list items to console.

            List<char> subStringList = input.ToList();          // converts input string to List

            /* Debug */
            // subStringList.ForEach(i => Console.Write("{0}\t", i));  // output all list items to console.
            // Console.Write(subStringList.Count); // size of list
            // Console.Write(subStringList.Count);
            // Console.Write(result_table.RowCount);

            /* Pauses the render of the table until all data is dynamically populated in memory
               If suspend and resume is removed causes a delay. */
            result_table.SuspendLayout();
            result_table.RowCount++;

            /* Loop through length of input pattern */
            for (int i = 0; i < subStringList.Count; i++)
            {
                Label iLabel = new Label();         // Label for iteration counter  e.g. 3
                Label sLabel = new Label();         // Label for substring display  e.g. abc   
                Label piLabel = new Label();        // Label for prefix value       e.g. 1

                iLabel.Text = Convert.ToString(i + 1);               // Convert to String and add 1 (counter from 0)
                sLabel.Text += Convert.ToString(subStringList[i]);  // Concatenate result to increase substring for each row.
                piLabel.Text = Convert.ToString(pi[i]);             // prefix of index position of substring.

                /* Adds Labels to the TableLayoutPanel */
                result_table.Controls.Add(iLabel, 0 /*col*/, result_table.RowCount /*row*/);
                result_table.Controls.Add(sLabel, 1 /*col*/, result_table.RowCount /*row*/);
                result_table.Controls.Add(piLabel, 2 /*col*/, result_table.RowCount /*row*/);
                result_table.RowCount++;                            // Next Row, Next char in substring

                /* Debug */
                Console.Write(result_table.RowCount);
            }
            result_table.ResumeLayout(); // Renders the layout to screen.
        }

    }
}
