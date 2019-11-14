using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MertKaymaz_HW4
{
    /// <summary>
    /// Courses.xaml etkileşim mantığı
    /// </summary>
    public partial class Courses : Window
    {
        public Courses()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Course course = new Course();
            course.Code = txtCourseCode.Text;
            course.Credit = int.Parse(txtCourseCredit.Text);
            course.Quota = int.Parse(txtCourseQuota.Text);
            

            DatabaseDB db = new DatabaseDB(); 
            db.Courses.Add(course);
            db.SaveChanges();

            MessageBox.Show("Ders Kaydedildi.");

            
            txtCourseCode.Text = "";
            txtCourseCredit.Text = "";
            txtCourseQuota.Text = "";
            
            LoadCourses();
        }

        private void dgCourses_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {

                       
                txtCourseCode.Text = course.Code.ToString();
                txtCourseCredit.Text = course.Credit.ToString();
                txtCourseQuota.Text = course.Quota.ToString();
                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            DatabaseDB db = new DatabaseDB();
            List<Course> courses = db.Courses.ToList();
            dgCourses.ItemsSource = courses;
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                DatabaseDB db = new DatabaseDB();
                var coursenew = db.Courses.Find(course.Id);
                coursenew.Code = txtCourseCode.Text;
                coursenew.Credit = int.Parse(txtCourseCredit.Text);
                coursenew.Quota = int.Parse(txtCourseQuota.Text);
                

                db.SaveChanges();
                LoadCourses();
                MessageBox.Show("Güncellendi.");
            }
            else
            {
                MessageBox.Show("güncellemek için ders seçmelisin!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                DatabaseDB db = new DatabaseDB();
                db.Courses.Remove(course);
                db.SaveChanges();
                MessageBox.Show("Ders Silindi!");
                LoadCourses();

            }
            else
            {
                MessageBox.Show("Silmek için öğrenci seçmelisin!");
            }
        }

        private void btnOpenStudents_Click(object sender, RoutedEventArgs e)
        {
            MainWindow student = new MainWindow();
            student.Show();
        }
    }
}
