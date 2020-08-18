using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Hadi_Alkhashman_Ex01
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

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool valid = isValid();
                if (valid)
                {
                    // getting student ID, Name, Address
                    int ID = int.Parse(textBoxID.Text);
                    string name = textBoxName.Text;
                    string address = textBoxAddress.Text;

                    // getting the program name
                    string program = comboBoxPrograms.Text;

                    // getting chosen courses
                    string allCourses = "";
                    if ((bool)checkBoxJava.IsChecked)
                        //studentDetails.Add(checkBoxJava.Content);
                        allCourses += "Java Programming  ";
                    if ((bool)checkBoxWeb.IsChecked)
                        //studentDetails.Add(checkBoxWeb.Content);
                        allCourses += "Web Programming  ";
                    if ((bool)checkBoxDatabase.IsChecked)
                        //studentDetails.Add(checkBoxDatabase.Content);
                        allCourses += "Database Programming  ";
                    if ((bool)checkBoxEngineering.IsChecked)
                        //studentDetails.Add(checkBoxEngineering.Content);
                        allCourses += "Software Engineering  ";

                    listBox.Items.Clear();
                    listBox.Items.Add("Student Name                Program Name            Courses\n");
                    listBox.Items.Add($"{name}               {program}               {allCourses}\n");
                    /*textBoxID.Text = "";
                    textBoxName.Text = "";
                    textBoxAddress.Text = "";*/

                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool isValid()
        {
            clear(); // to clear any error messages before validating
            Regex regex;
            bool result = true;

            // validing program
            ComboBoxItem item = (ComboBoxItem)comboBoxPrograms.SelectedItem;
            if (item.Content.ToString().Equals("Choose Program"))
            {
                result = false;
                labelErrorProgram.Content = "Error: choose a program!";
            }

            // validing courses 
            if (!(bool)checkBoxJava.IsChecked && !(bool)checkBoxWeb.IsChecked && !(bool)checkBoxEngineering.IsChecked
                && !(bool)checkBoxDatabase.IsChecked)
            {
                result = false;
                labelErrorCourse.Content = "Error: choose one course at least!";
            }

            // validing ID, name & address
            regex = new Regex(@"^[a-zA-Z ]*$"); // enter only words with spaces between them
            //if (textBoxName.Text.Equals("".Trim()))
            if (!regex.IsMatch(textBoxName.Text) || textBoxName.Text.Equals("".Trim()))
            {
                result = false;
                labelErrorName.Content = "Error: enter a valid name!";
            }
            regex = new Regex(@"^[a-zA-Z0-9 ]*$"); // enter letters, numbers, with spaces only no special character
            if (!regex.IsMatch(textBoxAddress.Text) || textBoxAddress.Text.Equals(""))
            {
                result = false;
                labelErrorAddress.Content = "Error: enter a valid address!";
            }
            // regex for only numbers;
            regex = new Regex(@"^[0-9]+$");
            if (!regex.IsMatch(textBoxID.Text))
            {
                result = false;
                labelErrorID.Content = "Error: enter a valid ID!";
            }
            return result;
        }

        public void clear()
        {
            labelErrorName.Content = "";
            labelErrorAddress.Content = "";
            labelErrorID.Content = "";
            labelErrorProgram.Content = "";
            labelErrorCourse.Content = "";
            listBox.Items.Clear();
        }


        private void radioButtonFulltime_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonParttime_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonEvening_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonParttime_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
