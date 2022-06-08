using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
            foreach (var t in LayoutRoot.Children)
                if (t is TextBox)
                    ((TextBox)t).TextAlignment = TextAlignment.Center;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool SameStudent = false;
                StreamReader DataBaseRead;
                DataBaseRead = new StreamReader(@"D:\КПІ\Lab1\Lab1\DataBase.txt");
                List<string> lines = new List<string>();
                string[] line = new string[4];
                while (!DataBaseRead.EndOfStream)
                {
                    lines.Add(DataBaseRead.ReadLine());
                    line = lines[lines.Count-1].Split(' ');
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

                    StreamWriter DataBaseWrite = new StreamWriter(@"D:\КПІ\Lab1\Lab1\DataBase.txt");

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
            Window1 w1;
            w1 = new Window1();
            Hide();
            w1.Show();
        }
    }
}
