using System;

namespace matrica
{
    public class Matrica
    {
        private int[,] mass;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public Matrica(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            mass = new int[rows, cols];
        }
        public Matrica(int[,] array)
        {
            Rows = array.GetLength(0);
            Cols = array.GetLength(1);
            mass = array;
        }
        public void Input()
        {
            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"Индекс [{i},{j}]: ");
                    mass[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public void Output()
        {
            Console.WriteLine("Матрица:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public int Max()
        {
            int max = mass[0, 0];
            foreach (int value in mass)
            {
                if (value > max) max = value;
            }
            return max;
        }
        public int Min()
        {
            int min = mass[0, 0];
            foreach (int value in mass)
            {
                if (value < min) min = value;
            }
            return min;
        }
        public static Matrica operator +(Matrica a, Matrica b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Матрицы должны быть одного размера");

            Matrica result = new Matrica(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result.mass[i, j] = a.mass[i, j] + b.mass[i, j];
                }
            }
            return result;
        }
        public static Matrica operator -(Matrica a, Matrica b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Матрицы должны быть одного размера");

            Matrica result = new Matrica(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result.mass[i, j] = a.mass[i, j] - b.mass[i, j];
                }
            }
            return result;
        }
        public static Matrica operator *(Matrica a, Matrica b)
        {
            if (a.Cols != b.Rows)
                throw new ArgumentException("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы");

            Matrica result = new Matrica(a.Rows, b.Cols);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    result.mass[i, j] = 0;
                    for (int k = 0; k < a.Cols; k++)
                    {
                        result.mass[i, j] += a.mass[i, k] * b.mass[k, j];
                    }
                }
            }
            return result;
        }
        public static Matrica operator *(Matrica a, int num)
        {
            Matrica result = new Matrica(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result.mass[i, j] = a.mass[i, j] * num;
                }
            }
            return result;
        }
        public static bool operator ==(Matrica a, Matrica b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                return false;

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    if (a.mass[i, j] != b.mass[i, j])
                        return false;
                }
            }
            return true;
        }
        public static bool operator !=(Matrica a, Matrica b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj is Matrica matrica)
            {
                return this == matrica;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return mass.GetHashCode();
        }
        public int this[int row, int col]
        {
            get { return mass[row, col]; }
            set { mass[row, col] = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrica m1 = new Matrica(2, 2);
            m1.Input();
            m1.Output();
            Matrica m2 = new Matrica(2, 2);
            m2.Input();
            m2.Output();
            Matrica sum = m1 + m2;
            Console.WriteLine("Сумма:");
            sum.Output();
            Matrica difference = m1 - m2;
            Console.WriteLine("Отнимание:");
            difference.Output();
            Matrica matricaOnmatrica = m1 * m2;
            Console.WriteLine("Умножение:");
            matricaOnmatrica.Output();
            Console.WriteLine("Максимальное значение в матрице: " + m1.Max());
            Console.WriteLine("Минимальное значение в матрице: " + m2.Min());         
            Matrica matricaONnumber = m1 * 5;
            Console.WriteLine("Умножение матрицы на число:");
            matricaONnumber.Output();
            Console.WriteLine("Матрицы равны: " + (m1 == m2));      
        }
    }
}

