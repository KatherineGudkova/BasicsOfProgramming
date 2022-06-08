using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для DeleteStudent.xaml
    /// </summary>
    public partial class DeleteStudent : Window
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void Delele_Click(object sender, RoutedEventArgs e)
        {
            StreamReader DataBaseRead = new StreamReader(@"D:\КПІ\Lab1\Lab1\DataBase.txt");

            List<Student> DataBase = new List<Student>();
            while (!DataBaseRead.EndOfStream)
            {
                string[] Line = DataBaseRead.ReadLine().Split(' ');
                DataBase.Add(new Student(long.Parse(Line[0]), Line[1], Line[2], Line[3]));
            }
            DataBaseRead.Close();
            if (DataBase.FindAll(a => a.getID().ToString() == id.Text).Count != 0)
            {
                FileStream file = new FileStream(@"D:\КПІ\Lab1\Lab1\DataBase.txt", FileMode.Create, FileAccess.Write);
                file.SetLength(0);
                file.Close();

                StreamWriter DataBaseWrite = new StreamWriter(@"D:\КПІ\Lab1\Lab1\DataBase.txt");
                DataBase.Remove(DataBase.Find(a => a.getID() == long.Parse(id.Text)));
                foreach (var s in DataBase)
                    DataBaseWrite.WriteLine(s.PrintStudent());
                DataBaseWrite.Close();
            }
            else
            {
                MessageBox.Show("Студента немає в базі!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1;
            w1 = new Window1();
            Hide();
            w1.Show();
        }
    }
}
