using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2
{
    class IntCreate
    {
        static public Window WNCreate(double width, double height, string title)
        {
            Window WN = new Window
            {
                Width = width,
                Height = height,
                ResizeMode = ResizeMode.NoResize,
                Title = title,
            };
            return WN;
        }

        static public Grid GridCreate(double width, double height)
        {
            Grid LayoutRoot = new Grid
            {
                Width = width,
                Height = height,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                ShowGridLines = true,
                Background = new SolidColorBrush(Color.FromRgb(232, 245, 244)),
            };
            return LayoutRoot;
        }
        static public Button ButtonCreate(double h, double w, double top,
           double left, double size, string content, SolidColorBrush b, Grid LayoutRoot)
        {
            Button butt = new Button
            {
                Content = content,
                Width = w,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(left, top, 0, 0),
                Height = h,
                FontSize = size,
                FontWeight = FontWeights.Normal,
                FontFamily = new FontFamily("Segoe UI"),
                Background = b,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            LayoutRoot.Children.Add(butt);
            return butt;
        }
        static public Button ButtonCreate(double h, double w, double top,
           double left, double size, string name, string content, SolidColorBrush b,
           Grid LayoutRoot)
        {
            Button butt = new Button
            {
                Content = content,
                Width = w,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(left, top, 0, 0),
                Height = h,
                FontSize = size,
                FontWeight = FontWeights.Normal,
                FontFamily = new FontFamily("Segoe UI"),
                Background = b,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            LayoutRoot.Children.Add(butt);
            return butt;
        }

        static public TextBox CreateTBox(double width, double height, double left, double top, double size, Grid LayoutRoot)
        {
            TextBox tb = new TextBox
            {
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(left, top, 0, 0),
                Text = "",
                TextWrapping = TextWrapping.Wrap,
                Width = width,
                Height = height,
                Background = Brushes.Beige,
                FontSize = size,
                FontFamily = new FontFamily("Segoe UI")
            };
            LayoutRoot.Children.Add(tb);
            return tb;
        }
        static public TextBlock CreateTBlock(double width, double height, double left, double top, double size, FontWeight f, string content, Grid LayoutRoot)
        {
            TextBlock tb = new TextBlock
            {
                TextAlignment = TextAlignment.Left,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(left, top, 0, 0),
                Text = content,
                TextWrapping = TextWrapping.Wrap,
                Width = width,
                Height = height,
                FontSize = size,
                FontFamily = new FontFamily("Segoe UI"),
                FontWeight = f,
            };
            LayoutRoot.Children.Add(tb);
            return tb;
        }
        static public ComboBox CreateBox(double left, double top,Grid LayoutRoot)
        {

            ComboBox cb = new ComboBox()
            {
                Margin = new Thickness(left, top, 0, 0),
                Background = new SolidColorBrush(Color.FromRgb(229, 229, 229)),
                Width = 95,
                Height = 95,
                FontSize = 48,
                FontFamily = new FontFamily("Segoe UI"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                ContextMenu = new ContextMenu(),
            };

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                    cb.Items.Add ("X");
                else
                    cb.Items.Add("O");
            }
            LayoutRoot.Children.Add(cb);
            return cb;

        }


    }
}
