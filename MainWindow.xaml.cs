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
using Microsoft.EntityFrameworkCore;

namespace MertKaymaz_HW4
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.Id = int.Parse(txtStudentId.Text);
            student.Name = txtStudentName.Text;
            student.Surname = txtStudentSurname.Text;
            student.BirthDate = dtpBirthDate.SelectedDate.Value;

            DatabaseDB db = new DatabaseDB();
            db.Database.OpenConnection();
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Students ON");
            db.Students.Add(student);
            db.SaveChanges();

            MessageBox.Show("Öğrenci Kaydedildi.");

           
            txtStudentId.Text = "";
            txtStudentName.Text = "";
            txtStudentSurname.Text = "";
            dtpBirthDate.SelectedDate = DateTime.Now;
            LoadStudents();
            txtStudentId.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            DatabaseDB db = new DatabaseDB();
            List<Student> students = db.Students.ToList();
            dgStudents.ItemsSource = students;
        }

        private void dgStudents_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void dgStudents_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Student student = dgStudents.SelectedItem as Student;
            if (student != null)
            {

                
                txtStudentId.Text = student.Id.ToString();
                txtStudentName.Text = student.Name;
                txtStudentSurname.Text = student.Surname;
                dtpBirthDate.SelectedDate = student.BirthDate;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Student student = dgStudents.SelectedItem as Student;
            if (student != null)
            {
                DatabaseDB db = new DatabaseDB();
                db.Students.Remove(student);
                db.SaveChanges();
                MessageBox.Show("Öğrenci Silindi!");
                LoadStudents();

            }
            else
            {
                MessageBox.Show("Silmek için öğrenci seçmelisin!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Student student = dgStudents.SelectedItem as Student;
            if (student != null)
            {
                DatabaseDB db = new DatabaseDB();
                var studentnew = db.Students.Find(student.Id);
                studentnew.Id = int.Parse(txtStudentId.Text);
                studentnew.Name = txtStudentName.Text;
                studentnew.Surname = txtStudentSurname.Text;
                studentnew.BirthDate = dtpBirthDate.SelectedDate.Value;
                
                db.SaveChanges();
                LoadStudents();
                MessageBox.Show("Güncellendi.");
            }
            else
            {
                MessageBox.Show("güncellemek için öğrenci seçmelisin!");
            }
        }

        private void btnOpenCourses_Click(object sender, RoutedEventArgs e)
        {
                Courses course = new Courses();
                course.Show();
  
        }

        private void txtStudentId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
