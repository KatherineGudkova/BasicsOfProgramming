using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Prj_Soft_Protection
{
    class Coefficient
    {
        static private Dictionary<double, double> GetCoeff(string source, double n)
        {
            Dictionary<double, double> Coef = new Dictionary<double, double>();
            StreamReader File = new StreamReader
                          (source);
            bool counter = false;
            while (!File.EndOfStream)
            {
                try
                {
                    string[] Line = File.ReadLine().Split(' ');
                    if (counter && (n + 1).ToString() != Line[0])
                    {
                        if (Line[0] != "\n")
                            Coef.Add(Double.Parse(Line[0]), Double.Parse(Line[1]));
                    }
                    else if ((n + 1).ToString() == Line[0])
                    {
                        return Coef;
                    }
                    else
                    {
                        if (n.ToString() == Line[0])
                        {
                            counter = true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Can't open file!");
                };
            }
            return Coef;
        }


        public const string IdentifPhrase = "длагнитор";
        /* public double[] StudentCoeff = 
             { 1.3968, 1.8596, 2.3060, 2.8965, 3.3554, 3.832, 4.5008, 5.0413 }
         ;*/
        static public Dictionary<double, double> Student6 = GetCoeff(@"D:\КПІ\Pr1\StudentsCoefficient.txt", 6);
        static public Dictionary<double, double> Student7 = GetCoeff(@"D:\КПІ\Pr1\StudentsCoefficient.txt", 7);

        static public Dictionary<double, double> Fisher7 = GetCoeff(@"D:\КПІ\Pr1\FisherCoefficient.txt", 7);
    }
}
