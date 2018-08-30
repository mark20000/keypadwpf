using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace keypadwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> keypairs = new Dictionary<string, string>();
        private const string aplphabet = "SPACEabcdefghijklmnopqrstuvwxyz*#";
        public MainWindow()
        {
            load();
            
            InitializeComponent();
           calculateTimeInput();
        }

       private void load()
        {
            string[] buttonText = new string[12];
            int Position = 5;
            for (int i = 0; i< 12; i++)
            {
                if (i< 1)
                {                    
                    buttonText[i] = aplphabet.Substring(0, 5);
                    keypairs.Add(i.ToString(), buttonText[i]);
                }
                else if (i == 1)
                {                 
                    buttonText[i] = i.ToString();
                    keypairs.Add(i.ToString(), buttonText[i]);
                }
                else if (i == 7 || i == 9)
                {
                    Position = Position + buttonText[i - 1].Length;
                  
                    
                    buttonText[i] = aplphabet.Substring(Position, 4);
                    keypairs.Add(i.ToString(), buttonText[i]);
                }
                else if (i == 2)
                {
                    buttonText[i] = aplphabet.Substring(i + 3, 3);
                    keypairs.Add(i.ToString(), buttonText[i]);
                }
                else if (i == 10)
                {
                    buttonText[i] = aplphabet.Substring(aplphabet.Length - 2, 1);
                    keypairs.Add(i.ToString(), buttonText[i]);
                }
                else if (i == 11)
                {
                    buttonText[i] = aplphabet.Substring(aplphabet.Length - 1, 1);
                    keypairs.Add(i.ToString(), buttonText[i]);
                }
                else if (i< 12)
                {
                    Position = Position + buttonText[i - 1].Length;
                 
                    buttonText[i] = aplphabet.Substring(Position, 3);
                    keypairs.Add(i.ToString(), buttonText[i]);
                } 
            }
        }
        private void calculateTimeInput()
        {
            double result = 0;
            string input = null;
            input = "global aerospace";
            string temp = null;
            int length = 0;
            List<string> letters = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var val in keypairs.Values)
                {
                    if (input[i].ToString() == " ")
                    {
                        temp = " ";
                       length=1;
                    }
                    else
                    {
                        length = val.Length;
                    }
                    for (int j = 0; j < length; j++)
                    {
                            if (input[i] == val[j] || temp ==input[i].ToString())
                        {
                            if (j == 0)
                            {
                                
                                result = result + (double)j + 0.1;
                                letters.Add("Input " + input[i] + " took " + string.Format("{0:0.0}",(double)j + 0.1)+" seconds");
                            } 
                            else
                            {
                                result = result + ((double)j * 0.5)+0.1;
                                letters.Add("Input " + input[i] + " took " + string.Format("{0:0.0}", ((double)j * 0.5) + 0.1)+" seconds ("+ string.Format("{0:0.0}", ((double)j * 0.5))+" + 0.1)");
                            }

                        }
                       
                    }
                    if (temp == input[i].ToString())
                    {
                        break;
                    }
                }
               
            }
           
            lblResult.Content= " it took a minimum of " + result.ToString() +" seconds to write: "+ input;
            lstLog.ItemsSource = letters;



        }
    }
}
