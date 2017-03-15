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

namespace JiaYuanHomework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsZipCode(string s)
        {
            if (s.Length == 5)
            {
                int number;
                bool result = int.TryParse(s, out number);
                return result;
            }
            else if (s.Length == 10)
            {
                if(s[5]!='-')
                {
                    return false;
                }
                else
                {
                    string leftCode=s.Substring(5);
                    string rightCode=s.Substring(6,4);                                      
                    int leftNumber;
                    int rightNumber;
                    bool leftResult = int.TryParse(leftCode, out leftNumber);
                    bool rightResult = int.TryParse(rightCode, out rightNumber);
                    if (leftResult && rightResult)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            else return false;
        }

        private bool IsPostalCode(string r)
        {
            if (r.Length == 6)
            {
                if ((char.IsLetter(r[0])) && (char.IsDigit(r[1])) && (char.IsLetter(r[2])) 
                    && (char.IsDigit(r[3])) && (char.IsLetter(r[4])) && (char.IsDigit(r[5])))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private void uxCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsZipCode(uxCode.Text) == true || IsPostalCode(uxCode.Text) == true)
            {
                uxSubmit.IsEnabled = true;
            }
            else uxSubmit.IsEnabled = false;
        }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You successfully submit a zip code or postal code!");
        }       
    }
}
