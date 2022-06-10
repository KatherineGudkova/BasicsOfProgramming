using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Math;

namespace Lab2
{
    class Window3
    {
        public Window3()
        {
            InitCalc();
        }
        Window wn = new Window();
        Grid LayoutRoot = new Grid();
        TextBlock NumField;

        private void InitCalc()
        {
            wn = IntCreate.WNCreate(500, 600, "Window3");
            LayoutRoot = IntCreate.GridCreate(500, 600);
            LayoutRoot.Background = new SolidColorBrush(Color.FromRgb(228, 228, 228));

            NumField = IntCreate.CreateTBlock(450, 80, 25, 15, 72, FontWeights.Normal, "0", LayoutRoot);
            NumField.TextAlignment = TextAlignment.Right;

            int height = 70, width = 110, counter = 1;
            Button[,] KeyControls = new Button[5, 4];

            KeyControls[0, 0] = IntCreate.ButtonCreate(height, width, NumField.Height + 35, 20,36, "", "", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[0, 1] = IntCreate.ButtonCreate(height, width, NumField.Height + 35, 20 + width + 5, 36,"Result", "=", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[0, 2] = IntCreate.ButtonCreate(height, width, NumField.Height + 35, 20 + width * 2 + 10, 36, "Erase", "C", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[0, 3] = IntCreate.ButtonCreate(height, width, NumField.Height + 35, 20 + width * 3 + 15, 36, "Delete", "⌫", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);

            KeyControls[0, 0].IsEnabled = false;

            KeyControls[0, 1].Click += Result_Click;
            KeyControls[0, 2].Click += Erase_Click;
            KeyControls[0, 3].Click += Delete_Click;

            Button ToMW = IntCreate.ButtonCreate(65, 500, 500, 0, 20, "ГОЛОВНА СТОРІНКА", Brushes.White, LayoutRoot);


            for (int i = 1; i < 4; i++)
                for (int j = 0; j < 3; j++)
                {
                    KeyControls[i, j] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + i * (height + 5), 20 + j * (width + 5), 36, "Num" + counter.ToString(), counter.ToString(), new SolidColorBrush(Color.FromRgb(250, 250, 250)), LayoutRoot);
                    KeyControls[i, j].Click += Number_Click;
                    counter++;
                }

            KeyControls[1, 3] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + 1 * (height + 5), 20 + 3 * (width + 5), 36, "Divide", "/", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[2, 3] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + 2 * (height + 5), 20 + 3 * (width + 5), 36, "Multiple", "*", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[3, 3] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + 3 * (height + 5), 20 + 3 * (width + 5), 36, "Add", "+", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[4, 3] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + 4 * (height + 5), 20 + 3 * (width + 5),36, "Minus", "-", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[4, 0] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + 4 * (height + 5), 20,  36, "Reverse", "(+-)", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);
            KeyControls[4, 1] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + 4 * (height + 5), 20 + width + 5, 36, "Num0", "0", new SolidColorBrush(Color.FromRgb(255, 255, 255)), LayoutRoot);
            KeyControls[4, 2] = IntCreate.ButtonCreate(height, width, NumField.Height + 35 + 4 * (height + 5), 20 + 2 * (width + 5), 36, "Dot", ",", new SolidColorBrush(Color.FromRgb(232, 245, 244)), LayoutRoot);

            for (int i = 1; i < 5; i++)
                KeyControls[i, 3].Click += Operation_Click;

            KeyControls[4, 0].Click += Reverse_Click;
            KeyControls[4, 1].Click += Number_Click;
            KeyControls[4, 2].Click += Number_Click;
            ToMW.Click += ToMainWindow_Click;

            wn.Content = LayoutRoot;
            wn.Show();
        }
        List<string> Operations = new List<string>();
        const string opers = "+-*/";

        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            wn.Hide();
            MainWindow MW = new MainWindow();
            MW.Show();
        }

        public double Calculate()
        {

            try
            {
                double num1 = double.Parse(Operations[0]);
                double num2 = double.Parse(Operations[2]);
                string op = Operations[1];

                Operations.Clear();

                if (op == "+")
                    return num1 + num2;
                else if (op == "-")
                    return num1 - num2;
                else if (op == "*")
                    return num1 * num2;
                else if (op == "/")
                    return num1 / num2;
                else
                    return 0;

            }
            catch
            {
                MessageBox.Show("ПОМИЛКА!"); return 0;
            }
        }
        public void AddNumber(string num)
        {
            if (num != "," && (Operations.Count == 0 ||
                opers.Contains(Operations[Operations.Count - 1])))
            {
                Operations.Add(num);
                if (NumField.Text.Length > 0)
                    if (NumField.Text[NumField.Text.Length - 1] == '0')
                        NumField.Text = NumField.Text.Remove(NumField.Text.Length - 1);
            }
            else
                Operations[Operations.Count - 1] = Operations[Operations.Count - 1] + num;
            NumField.Text += num;
        }
        public void AddOperation(string oper)
        {
            if ((Operations.Count == 3 && Operations[0] != "-") || Operations.Count == 4)
            {
                double result = Round(Calculate(), 4);
                NumField.Text = result.ToString();
                Operations.Add(result.ToString());
            }
            if (Operations.Count > 0)
                if (opers.Contains(Operations[Operations.Count - 1]))
                {
                    Operations[Operations.Count - 1] = oper;
                    NumField.Text = NumField.Text.Remove(NumField.Text.Length - 1) + oper;
                }
                else
                {
                    Operations.Add(oper);
                    NumField.Text += oper;
                }
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            AddNumber(butt.Content.ToString());
        }
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            AddOperation(butt.Content.ToString());
        }
        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            if (Operations.Count > 1)
            {
                if (NumField.Text[NumField.Text.Length - 1] == '+')
                {
                    NumField.Text = NumField.Text.Remove(NumField.Text.Length - 1);
                    NumField.Text += "-";
                    Operations[NumField.Text.Length - 1] = "-";
                }
                else if (NumField.Text[NumField.Text.Length - 1] == '-')
                {
                    NumField.Text = NumField.Text.Remove(NumField.Text.Length - 1);
                    NumField.Text += "+";
                    Operations[NumField.Text.Length - 1] = "-";
                }
                else if (Operations[Operations.Count - 2] == "-")
                {
                    NumField.Text = NumField.Text.Remove(NumField.Text.Length - 1 - Operations[Operations.Count - 1].Length);
                    NumField.Text += "+" + Operations[Operations.Count - 1];
                    Operations[Operations.Count - 2] = "+";
                }
                else if (Operations[Operations.Count - 2] == "+")
                {
                    NumField.Text = NumField.Text.Remove(NumField.Text.Length - 1 - Operations[Operations.Count - 1].Length);
                    NumField.Text += "-" + Operations[Operations.Count - 1];
                    Operations[Operations.Count - 2] = "-";
                }
                else if (!opers.Contains(Operations[Operations.Count - 1]))
                {
                    if (double.Parse(Operations[Operations.Count - 1]) > 0)
                    {
                        NumField.Text = "";
                        Operations[Operations.Count - 1] = "-" + Operations[Operations.Count - 1];
                        for (int i = 0; i < Operations.Count - 1; i++)
                            NumField.Text += Operations[i];
                        NumField.Text += "(" + Operations[Operations.Count - 1] + ")";
                    }
                    else if (double.Parse(Operations[Operations.Count - 1]) < 0)
                    {
                        NumField.Text = "";
                        Operations[Operations.Count - 1] = (double.Parse(Operations[Operations.Count - 1]) * (-1)).ToString();
                        for (int i = 0; i < Operations.Count; i++)
                            NumField.Text += Operations[i];
                    }
                }
            }
            else if (Operations.Count == 1)
            {
                NumField.Text = "";
                Operations[0] = (double.Parse(Operations[Operations.Count - 1]) * (-1)).ToString();
                NumField.Text += Operations[0];
            }
        }
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            double result = Round(Calculate(), 4);
            NumField.Text = result.ToString();
            Operations.Add(result.ToString());
        }
        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            Operations.Clear();
            NumField.Text = "0";
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Operations.Count > 0)
            {
                if (Operations[Operations.Count - 1].Length > 1)
                    Operations[Operations.Count - 1] = Operations[Operations.Count - 1].Remove(Operations[Operations.Count - 1].Length - 1);
                else
                    Operations.RemoveAt(Operations.Count - 1);
                if (NumField.Text.Length > 0)
                    NumField.Text = NumField.Text.Remove(NumField.Text.Length - 1);
            }
        }
    }
}
