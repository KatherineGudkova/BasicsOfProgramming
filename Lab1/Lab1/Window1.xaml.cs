using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>

    struct Student
    {
        private long ID;
        private string FirstName;
        private string SecondName;
        private string Group;

        public Student(long ID, string FirstName, string SecondName, string Group)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Group = Group;
        }

        public long getID() => ID;

        public string PrintStudent()
        {
            return $"{ID} {SecondName} {FirstName} {Group}";
        }

    }

    public partial class Window1 : Window
    {
        static List<Student> DataBase = new List<Student>();
        public Window1()
        {
            InitializeComponent();
            CreateData();
        }

        public void CreateData()
        {
            Data.Text = "";
            StreamReader DataBaseRead;

            DataBaseRead = new StreamReader(@"D:\КПІ\Lab1\Lab1\DataBase.txt");
            while (!DataBaseRead.EndOfStream)
            {
                string[] Line = DataBaseRead.ReadLine().Split(' ');
                DataBase.Add(new Student(long.Parse(Line[0]), Line[1], Line[2], Line[3]));
            }
            DataBaseRead.Close();
            if (DataBase.Count == 0)
                Data.Text = "NoElements";
            else
            {
                foreach (var s in DataBase)
                {
                    Data.Text += s.PrintStudent() + "\n";
                }
                DataBase.Clear();
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent add;
            add = new AddStudent();
            Hide();
            add.Show();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudent del;
            del = new DeleteStudent();
            Hide();
            del.Show();
        }

        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
