using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int limit = Convert.ToInt32(textBox1.Text);
            string text = richTextBox1.Text;

            // Split the text into lines
            string[] lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Process each line
            foreach (string line in lines)
            {
                // Split the line by spaces
                string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            }
            string lastLine = "";
            string temp = "";
            if (limit < lines[0].Length)
            {

                if (limit > 2)
                {
                    //////////////////////////////////////////////FIRST
                    string first = Convert.ToString(lines[0][0]);
                    for (int i = 1; i < limit - 2; i++)
                    {
                        first += Convert.ToString(lines[0][i]);
                    }
                    first += "..." + lines[0][lines[0].Length - 1];
                    listBox1.Items.Add(first);
                    lastLine = first;
                    //////////////////////////////////////////////FIRST
                }
                if (limit == 2)
                {
                    string first = Convert.ToString(lines[0][0]);
                    first += "...";
                    listBox1.Items.Add(first);
                    lastLine = first;
                }

            }
            else
            {
                MessageBox.Show("Limit must be lesser than the length of the word", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            void Shorten(int imp)
            {
                if (limit < lines[imp].Length)
                {
                    if (limit > 3)
                    {
                        int unqNum = 0;
                        string temp1 = Convert.ToString(lines[imp][0]);
                        for (int i = 1; i < lines[imp].Length - 1; i++)
                        {
                            if (lines[imp][i] != lines[imp - 1][i])
                            {
                                if (i > 1)
                                {
                                    temp1 = temp1 + "...";
                                }
                                temp1 += Convert.ToString(lines[imp][i]);

                                unqNum = i;
                                break;
                            }
                        }
                        if (unqNum != 0)
                        {
                            if (unqNum + (limit - 4) < lines[imp].Length - 1)
                            {
                                if (unqNum > 1)
                                {
                                    for (int i = unqNum; i < unqNum + (limit - 5); i++)
                                    {
                                        temp1 += lines[imp][i + 1];
                                    }
                                }
                                else
                                {
                                    for (int i = unqNum; i < unqNum + (limit - 4); i++)
                                    {
                                        temp1 += lines[imp][i + 1];
                                    }
                                }
                            }
                            if (unqNum + (limit - 4) > lines[imp].Length - 1)
                            {
                                if (unqNum > 1)
                                {
                                    for (int i = unqNum; i > unqNum - (limit - 5); i--)
                                    {
                                        temp1 += lines[imp][i - 1];
                                    }
                                    string original = temp1;
                                    int startIndex = 4;
                                    int endIndex = temp1.Length - 1;

                                    // Extract the part to be inverted
                                    string partToInvert = original.Substring(startIndex, endIndex - startIndex + 1);

                                    // Invert the extracted part
                                    char[] charArray = partToInvert.ToCharArray();
                                    Array.Reverse(charArray);
                                    string invertedPart = new string(charArray);

                                    // Reconstruct the final string
                                    string result = original.Substring(0, startIndex) + invertedPart + original.Substring(endIndex + 1);
                                    temp1 = result;
                                }


                            }

                            temp1 += "...";
                            temp1 += Convert.ToString(lines[imp][lines[imp].Length - 1]);
                            listBox1.Items.Add(temp1);
                            lastLine = temp1;
                        }
                        if (unqNum == 0)
                        {
                            listBox1.Items.Add(lastLine + " #1");
                        }
                    }
                    if (limit == 3)
                    {
                        int unqNum = 0;
                        string temp1 = Convert.ToString(lines[imp][0]);
                        for (int i = 1; i < lines[imp].Length; i++)
                        {
                            if (lines[imp][i] != lines[imp - 1][i])
                            {
                                unqNum = i;
                                temp1 += Convert.ToString(lines[imp][i]);
                                temp1 += "...";
                                listBox1.Items.Add(temp1);
                                lastLine = temp1;
                                break;
                            }

                        }
                        if (unqNum == 0)
                        {
                            listBox1.Items.Add(lastLine + " #1");
                        }
                    }
                    if (limit == 2)
                    {
                        int unqNum = 0;
                        string temp1;
                        for (int i = 1; i < lines[imp].Length; i++)
                        {
                            if (lines[imp][i] != lines[imp - 1][i])
                            {
                                temp1 = Convert.ToString(lines[imp][i]);
                                unqNum = i;
                                temp1 += "...";
                                listBox1.Items.Add(temp1);
                                lastLine = temp1;
                                break;
                            }

                        }
                        if (unqNum == 0)
                        {
                            listBox1.Items.Add(lastLine + " #1");
                        }


                    }

                }


            }
            for (int i = 1; i < lines.Length; i++)
            {
                Shorten(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            listBox1.Items.Clear();
        }
    }
}
    

