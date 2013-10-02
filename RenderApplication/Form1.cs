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
        //List<int> pi = new List<int> { 0, 0, 0, 1, 2, 3 };
        String input = "ABXYABXZ";

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
            
            PrefixArray(input);
            render(prefixList(input), input);   
        }

        private List<int> prefixList(string w)
        { 
            List<int> p = new List<int>();
            p.Add(0);
            int j = 0;
            for (int i = 1; i < w.Length; i++) {
                while (j > 0 && w[j] != w[i])
                    j = p[j-1];
                
                if (w[j] == w[i])
                    j++;
                p.Add(j);
            }
            p.ForEach(n => Console.Write("{0}\t", n));
            return p;
        }

        private List<int> PrefixArray(string w)
        {
            //List<char> subStringList = w.ToList();

            int[] t = new int[w.Length];
            int i = 2;
            int j = 0;
            t[0] = -1;
            t[1] = 0;

            while (i < w.Length)
            {
                if (w[i - 1] == w[j])
                {
                    t[i] = j + 1;
                    j++;
                    i++;
                }
                else if (j > 0)
                {
                    j = t[j];
                }
                else
                {
                    t[i] = 0;
                    i++;
                    j = 0;
                }
            }
            //Console.Write("Hello");
            //Console.Write(string.Join(",", t));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            List<int> lst = t.OfType<int>().ToList();
            //lst.ForEach(n => Console.Write("{0}\t", n));
            
            return lst;
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
            string subString = "";
            /* Loop through length of input pattern */
            for (int i = 0; i < subStringList.Count; i++)
            {
                Label iLabel = new Label();         // Label for iteration counter  e.g. 3
                Label sLabel = new Label();         // Label for substring display  e.g. abc   
                Label piLabel = new Label();        // Label for prefix value       e.g. 1

                iLabel.Text = Convert.ToString(i + 1);               // Convert to String and add 1 (counter from 0)
                subString += Convert.ToString(subStringList[i]);  // Concatenate result to increase substring for each row.
                sLabel.Text = subString;
                
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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();               //Clears textbox
            result_table.Controls.Clear();  //Clears the result table 
            result_table.RowCount--;        //Decreases the number of rows in table 

            Label label1 = new Label();     
            Label label2 = new Label();
            Label label3 = new Label();

            label1.Text = "i";
            label2.Text = "S[i]";
            label3.Text = "pi[i]";

            label1.Font = new Font(label1.Font.Name, 8, FontStyle.Bold);
            label2.Font = new Font(label2.Font.Name, 8, FontStyle.Bold);
            label3.Font = new Font(label3.Font.Name, 8, FontStyle.Bold);

            result_table.Controls.Add(label1, 0, result_table.RowCount);
            result_table.Controls.Add(label2, 1, result_table.RowCount);
            result_table.Controls.Add(label3, 2, result_table.RowCount);
        }
    }
}
