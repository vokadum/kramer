using static System.Console;

namespace ConsoleApp41
{
    internal class Program
    {
        static double[,] kf = new double[3, 3];
        static double[] otv = new double[3];

        static void Main(string[] args)
        {
            kf[0, 0] = 1.7;
            kf[0, 1] = -2.2;
            kf[0, 2] = 3.0;
            kf[1, 0] = 2.1;
            kf[1, 1] = 1.9;
            kf[1, 2] = -2.3;
            kf[2, 0] = 4.2;
            kf[2, 1] = 1.9;
            kf[2, 2] = -3.1;
            otv[0] = 1.8;
            otv[1] = 2.8;
            otv[2] = 5.1;

            WriteLine("Система линейных уравнений:");
            for (int i = 0; i < 3; i++)
            {
                WriteLine($"{kf[i, 0],4}*X + {kf[i, 1],4}*Y + {kf[i, 2],4:0.0}*Z = {otv[i]}");
            }
            WriteLine($"\nОпределитель = {Determinant(kf)}");
            WriteLine($"X = {Determinant(Copy(kf, otv, 0)) / Determinant(kf)}");
            WriteLine($"Y = {Determinant(Copy(kf, otv, 1)) / Determinant(kf)}");
            WriteLine($"Z = {Determinant(Copy(kf, otv, 2)) / Determinant(kf)}");
            ReadLine();
        }

        static double Determinant(double[,] k)
        {
            return k[0, 0] * (k[1, 1] * k[2, 2] - k[1, 2] * k[2, 1])
                 - k[1, 0] * (k[0, 1] * k[2, 2] - k[0, 2] * k[2, 1])
                 + k[2, 0] * (k[0, 1] * k[1, 2] - k[0, 2] * k[1, 1]);
        }

        static double[,] Copy(double[,] k, double[] t, int idx)
        {
            double[,] p = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    p[i, j] = k[i, j];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                p[i, idx] = t[i];
            }
            return p;
        }
    }
}