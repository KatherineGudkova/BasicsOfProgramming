using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2
{
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
    class Window1
    {
        public Window1()
        {
            InitDB();
            CreateData();
            
        }

        Window wn = new Window();
        Grid LayoutRoot = new Grid();

        TextBlock Data = new TextBlock(), Stud;
        Button DeleteStudent, AddStudent;
        int StudentsNum = 0;

        public void InitDB()
        {
            wn = IntCreate.WNCreate(800, 450, "Window1");
            LayoutRoot = IntCreate.GridCreate(800, 450);

            Stud = IntCreate.CreateTBlock(280, 70, 260, 20, 24, FontWeights.Bold, "ДАНІ ПРО СТУДЕНТІВ", LayoutRoot);
            Stud.TextAlignment = TextAlignment.Center;

            AddStudent = IntCreate.ButtonCreate(45, 355, 300, 40, 18, "ДОДАТИ ІНФОРМАЦІЮ", Brushes.PaleGreen, LayoutRoot);
            DeleteStudent = IntCreate.ButtonCreate(45, 355, 300, 405, 18,  "ВИДАЛИТИ ІНФОРМАЦІЮ",Brushes.LightPink, LayoutRoot);

            Button ToMainWindow = IntCreate.ButtonCreate(45, 720, 360, 40, 20,  "ГОЛОВНА СТОРІНКА",Brushes.White, LayoutRoot);

            ToMainWindow.Click += ToMainWindow_Click;
            DeleteStudent.Click += DeleteStudent_Click;
            AddStudent.Click += AddStudent_Click;


            wn.Content = LayoutRoot;
            wn.Show();
        }
        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            wn.Hide();
            MainWindow MW = new MainWindow();
            MW.Show();
        }
        static List<Student> DataBase = new List<Student>();
        public void CreateData()
        {
            Data = IntCreate.CreateTBlock(720, 210, 0, 65, 14, FontWeights.Normal, "", LayoutRoot);
            Data.HorizontalAlignment = HorizontalAlignment.Center;
            Data.Background = Brushes.White;
            StreamReader DataBaseRead;

            DataBaseRead = new StreamReader(@"D:\КПІ\Lab2\DataBase.txt");

            while (!DataBaseRead.EndOfStream)
            {
                string[] Line = DataBaseRead.ReadLine().Split(' ');
                DataBase.Add(new Student(long.Parse(Line[0]), Line[1], Line[2], Line[3]));
            }

            StudentsNum = DataBase.Count;
            DataBaseRead.Close();

            if (DataBase.Count == 0)
                Data.Text = "NoElements";
            else
            {
                foreach (var s in DataBase)
                    Data.Text += s.PrintStudent() + "\n";
                DataBase.Clear();
            }
            Data.Height = 220;
        }
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            wn.Close();
            AddStudent add = new AddStudent();
        }
        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            wn.Close();
            DeleteStudent del = new DeleteStudent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            wn.Close();
        }
    
}
}
