using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2
{
    class DeleteStudent
    {
        public DeleteStudent()
        {
            InitStudent();
        }

        Window WN;
        Grid LayoutRoot;
        TextBox id;

        private void InitStudent()
        {
            WN = IntCreate.WNCreate(800, 450, "DeleteStudent");
            LayoutRoot = IntCreate.GridCreate(WN.Width, WN.Height);
            id = IntCreate.CreateTBox(485, 50, 265, 180, 24, LayoutRoot);

            TextBlock IDLabel = IntCreate.CreateTBlock(180, 70, 50, 185, 28, FontWeights.Bold, "ID СТУДЕНТА", LayoutRoot);
            TextBlock DeleteStudent = IntCreate.CreateTBlock(WN.Width, 80, 0, 40, 30, FontWeights.Bold, "ВИДАЛИТИ ІНФОРМАЦІЮ", LayoutRoot);
            DeleteStudent.TextAlignment = TextAlignment.Center;
            

            Button Delete = IntCreate.ButtonCreate(40, 330, 355, 50, 20, "ВИДАЛИТИ", new SolidColorBrush(Color.FromRgb(201, 241, 193)), LayoutRoot);
            Button Back = IntCreate.ButtonCreate(40, 330, 355, 420, 20, "ПОВЕРНУТИСЯ", new SolidColorBrush(Color.FromRgb(232, 179, 179)), LayoutRoot);

            Delete.Click += Delete_Click;
            Back.Click += Back_Click;

            WN.Content = LayoutRoot;
            WN.Show();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            StreamReader DataBaseRead = new StreamReader(@"D:\КПІ\Lab2\DataBase.txt");

            List<Student> DataBase = new List<Student>();
            while (!DataBaseRead.EndOfStream)
            {
                string[] Line = DataBaseRead.ReadLine().Split(' ');
                DataBase.Add(new Student(long.Parse(Line[0]), Line[1], Line[2], Line[3]));
            }
            DataBaseRead.Close();
            if (DataBase.FindAll(a => a.getID().ToString() == id.Text).Count != 0)
            {
                FileStream file = new FileStream(@"D:\КПІ\Lab2\DataBase.txt", FileMode.Create, FileAccess.Write);
                file.SetLength(0);
                file.Close();

                StreamWriter DataBaseWrite = new StreamWriter(@"D:\КПІ\Lab2\DataBase.txt");
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
            WN.Hide();
            Window1 W1 = new Window1();
        }
    }
}