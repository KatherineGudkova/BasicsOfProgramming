using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2
{
    class AddStudent
    {
        public AddStudent()
        {
            InitStudent();
        }

        Window WN;
        Grid LayoutRoot;
        TextBox id, firstname, secondname, group;
        TextBlock ID, FirstName, SecondName, Group;

        private void InitStudent()
        {
            WN = IntCreate.WNCreate(800, 450, "AddStudent");
            LayoutRoot = IntCreate.GridCreate(800, 450);

            Button Add = IntCreate.ButtonCreate(40, 330, 360, 50, 20, "ДОДАТИ", new SolidColorBrush(Color.FromRgb(201, 241, 193)), LayoutRoot);
            Button Back = IntCreate.ButtonCreate(40, 330, 360, 420, 20, "ПОВЕРНУТИСЯ", new SolidColorBrush(Color.FromRgb(232, 179, 179)), LayoutRoot);

            TextBlock AddStudent = IntCreate.CreateTBlock(WN.Width, 80, 0, 20, 30, FontWeights.Bold, "ДОДАТИ ІНФОРМАЦІЮ", LayoutRoot);
            AddStudent.TextAlignment = TextAlignment.Center;

            ID = IntCreate.CreateTBlock(700, 75, 50, 80, 28, FontWeights.Bold, "ID", LayoutRoot);
            FirstName = IntCreate.CreateTBlock(700, 75, 50, 155, 28, FontWeights.Bold, "Прізвище", LayoutRoot);
            SecondName = IntCreate.CreateTBlock(700, 75, 50, 220, 28, FontWeights.Bold, "Ім'я", LayoutRoot);
            Group = IntCreate.CreateTBlock(700, 75, 50, 290, 28, FontWeights.Bold, "Група №", LayoutRoot);

            id = IntCreate.CreateTBox(500, 50, 250, 75, 24, LayoutRoot);
            secondname = IntCreate.CreateTBox(500, 50, 250, 145, 24, LayoutRoot);
            firstname = IntCreate.CreateTBox(500, 50, 250, 220, 24, LayoutRoot);
            group = IntCreate.CreateTBox(500, 50, 250, 285, 24, LayoutRoot);

            Add.Click += Add_Click;
            Back.Click += Back_Click;

            WN.Content = LayoutRoot;
            WN.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool SameStudent = false;
                StreamReader DataBaseRead;
                DataBaseRead = new StreamReader(@"D:\КПІ\Lab2\DataBase.txt");
                List<string> lines = new List<string>();
                string[] line = new string[4];
                while (!DataBaseRead.EndOfStream)
                {
                    lines.Add(DataBaseRead.ReadLine());
                    line = lines[lines.Count - 1].Split(' ');
                    if (line[0] == id.Text)
                    {
                        MessageBox.Show("Студент з таким ID вже є в базі!");
                        SameStudent = true;
                        break;
                    }
                }
                DataBaseRead.Close();
                if (!SameStudent)
                {
                    Student St = new Student(long.Parse(id.Text), firstname.Text, secondname.Text, group.Text);

                    StreamWriter DataBaseWrite = new StreamWriter(@"D:\КПІ\Lab2\DataBase.txt");

                    foreach (var a in lines)
                        DataBaseWrite.WriteLine(a);

                    DataBaseWrite.WriteLine(St.PrintStudent());
                    DataBaseWrite.Close();
                    MessageBox.Show("Дані успішно додані!");

                    foreach (var t in LayoutRoot.Children)
                        if (t is TextBox)
                            ((TextBox)t).Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Помилка введення даних!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WN.Hide();
            Window1 W1 = new Window1();
        }
    }
}
