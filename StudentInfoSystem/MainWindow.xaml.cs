using StudentRepository;
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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        private string userFn;

        public MainForm(string userFn)
        {
            InitializeComponent();

            this.userFn = userFn;
            LoadUser();
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoadUser()
        {
            Student student = StudentData.TestStudents.Where(u => u.FacultyNumber == userFn).FirstOrDefault();
            txtFirstName.Text = student.Firstname;
            txtSecondName.Text = student.Middlename;
            txtLastName.Text = student.Lastname;
            txtGroup.Text = student.Group;
            txtFaculty.Text = student.Faculty;
            txtFacultyNumber.Text = student.FacultyNumber;
            txtSpeciality.Text = student.Specialty;
            txtStream.Text = student.Stream;
            txtOks.Text = student.EducationLevel;
            txtStatus.Text = student.Status;
            txtCourse.Text = student.Course;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in StudentInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }

            foreach (Control ctl in PersonalInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }
        }

        private void BtnLoadStudent_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentData.TestStudents.First();
            txtFirstName.Text = student.Firstname;
            txtSecondName.Text = student.Middlename;
            txtLastName.Text = student.Lastname;
            txtGroup.Text = student.Group;
            txtFaculty.Text = student.Faculty;
            txtFacultyNumber.Text = student.FacultyNumber;
            txtSpeciality.Text = student.Specialty;
            txtStream.Text = student.Stream;
            txtOks.Text = student.EducationLevel;
            txtStatus.Text = student.Status;
            txtCourse.Text = student.Course;
        }

        private void BtnBanForm_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in PersonalInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).IsEnabled = false;
            }

            foreach (Control ctl in StudentInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).IsEnabled = false;
            }
        }

        private void BtnUnbanForm_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in StudentGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).IsEnabled = true;
            }
        }
    }
}
