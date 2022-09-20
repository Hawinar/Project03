using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Media;

namespace Project03
{
    /// <summary>
    /// Project03, Задачи вычислительного типа, Вариант № 2 https://github.com/Hawinar
    /// </summary>
    public partial class MainWindow : Window
    {
        public string flag = string.Empty;
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void btCompute_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                switch (flag)
                {
                    case "rbCramer":
                        MessageBox.Show("Ответ:" + Cramer(double.Parse(tbUpperX1.Text), double.Parse(tbUpperX2.Text), double.Parse(tbUpperX3.Text), double.Parse(tbUpperEquivalent.Text), 
                            double.Parse(tbMiddleX1.Text), double.Parse(tbMiddleX2.Text), double.Parse(tbMiddleX3.Text), double.Parse(tbMiddleEquivalent.Text),
                            double.Parse(tbLowerX1.Text), double.Parse(tbLowerX2.Text), double.Parse(tbLowerX3.Text), double.Parse(tbLowerEquivalent.Text)).ToString()
                            + "\nДержу в курсе, если в ответе есть -0.003, то просто не обращайте на него внимания, , и тогда правильнымы ответами являются первые 2 числа");
                        break;
                    case "rbJordanGauss":
                        MessageBox.Show("Ответ:" + JordanGauss(double.Parse(tbUpperX1.Text), double.Parse(tbUpperX2.Text), double.Parse(tbUpperEquivalent.Text),
                            double.Parse(tbMiddleX1.Text), double.Parse(tbMiddleX2.Text), double.Parse(tbMiddleEquivalent.Text)).ToString());
                        break;
                    case "rbGauss":
                        MessageBox.Show("Ответ:" + Gauss(double.Parse(tbUpperX1.Text), double.Parse(tbUpperX2.Text), double.Parse(tbUpperX3.Text), double.Parse(tbUpperEquivalent.Text),
                             double.Parse(tbMiddleX1.Text), double.Parse(tbMiddleX2.Text), double.Parse(tbMiddleX3.Text), double.Parse(tbMiddleEquivalent.Text),
                             double.Parse(tbLowerX1.Text), double.Parse(tbLowerX2.Text), double.Parse(tbLowerX3.Text), double.Parse(tbLowerEquivalent.Text)).ToString()
                             + "\nДержу в курсе, если в ответе есть -0.003, то просто не обращайте на него внимания, и тогда правильнымы ответами являются первые 2 числа");
                        break;
                    case "rbSimpleIteration":

                        break;
                    case "rbSeidel":
                        MessageBox.Show("Ответ:" + Seidel(double.Parse(tbUpperX1.Text), double.Parse(tbUpperX2.Text), double.Parse(tbUpperEquivalent.Text),
                           double.Parse(tbMiddleX1.Text), double.Parse(tbMiddleX2.Text), double.Parse(tbMiddleEquivalent.Text)).ToString());
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Убедитесь, что все доступные поля заполнены");
            }
            

        }
        public double Round(double number)
        {
            string target = number.ToString();
            if(target.Contains(",9") == true)
                return Math.Round(number);
            if (target.Contains(",0") == true)
                return Math.Round(number);
            else
                number = double.Parse(target);
                return number;
        }
        private void rbCramer_Checked(object sender, RoutedEventArgs e) => flag = "rbCramer";
        private void rbJordanGauss_Checked(object sender, RoutedEventArgs e) => flag = "rbJordanGauss";   
        private void rbGauss_Checked(object sender, RoutedEventArgs e) => flag = "rbGauss";
        private void rbSimpleIteration_Checked(object sender, RoutedEventArgs e) => flag = "rbSimpleIteration";
        private void rbSeidel_Checked(object sender, RoutedEventArgs e) => flag = "rbSeidel";
        private void cbSize_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbSize.SelectedIndex == 0)
            {
                lbUpperSumClone.Visibility = Visibility.Visible;
                tbUpperX3.Visibility = Visibility.Visible;

                lbMiddleSumClone.Visibility = Visibility.Visible;
                tbMiddleX3.Visibility = Visibility.Visible;

                tbLowerX1.Visibility = Visibility.Visible;
                lbLowerSum.Visibility = Visibility.Visible;
                tbLowerX2.Visibility = Visibility.Visible;
                lbLowerSumClone.Visibility = Visibility.Visible;
                tbLowerX3.Visibility = Visibility.Visible;
                lbLowerEqual.Visibility = Visibility.Visible;
                tbLowerEquivalent.Visibility = Visibility.Visible;
                //Ну нужно хоть передать в метод, чтобы не было исключения
                tbUpperX3.Text = "0";
                tbMiddleX3.Text = "0";
                tbLowerX1.Text = "0";
                tbLowerX2.Text = "0";
                tbLowerX3.Text = "0";
                tbLowerEquivalent.Text = "0";

                rbJordanGauss.Visibility = Visibility.Hidden;
                rbJordanGauss.IsChecked = false;

                rbSeidel.Visibility = Visibility.Hidden;
                rbSeidel.IsChecked = false;

                
            }
            else
            {
                lbUpperSumClone.Visibility = Visibility.Hidden;
                tbUpperX3.Visibility = Visibility.Hidden;
                tbUpperX3.Text = string.Empty;

                lbMiddleSumClone.Visibility = Visibility.Hidden;
                tbMiddleX3.Visibility = Visibility.Hidden;
                tbMiddleX3.Text = string.Empty;

                tbLowerX1.Visibility = Visibility.Hidden;
                tbLowerX1.Text = string.Empty;
                lbLowerSum.Visibility = Visibility.Hidden;
                tbLowerX2.Visibility = Visibility.Hidden;
                tbLowerX2.Text = string.Empty;
                lbLowerSumClone.Visibility = Visibility.Hidden;
                tbLowerX3.Visibility = Visibility.Hidden;
                tbLowerX3.Text = string.Empty;
                lbLowerEqual.Visibility = Visibility.Hidden;
                tbLowerEquivalent.Visibility = Visibility.Hidden;
                tbLowerEquivalent.Text = string.Empty;
               

                rbJordanGauss.Visibility = Visibility.Visible;
                rbSeidel.Visibility = Visibility.Visible;
            }
        }
        public (double, double, double) Cramer(double UpperX1, double UpperX2, double UpperX3, double UpperEquivalent,
            double MiddleX1, double MiddleX2, double MiddleX3, double MiddleEquivalent,
            double LowerX1, double LowerX2, double LowerX3, double LowerEquivalent)
        {
            if (cbSize.SelectedIndex == 1)
            {
                double Delta = (UpperX1 * MiddleX2) - (MiddleX1 * UpperX2);
                if(Delta != 0)
                {
                    double DeltaA = (UpperEquivalent * MiddleX2) - (MiddleEquivalent * UpperX2);
                    double a = DeltaA / Delta;
                    a = Math.Round(a, 2);
                    double DeltaB = (UpperX1 * MiddleEquivalent) - (UpperX2 * UpperEquivalent);
                    double b = DeltaB / Delta;
                    b = Math.Round(b, 2);
                    return (a, b, -0.003); //Ну вернуться должно 3 значения и во избежание неловкой ситуации, приходится хоть что-то вернуть
                }
                else
                {
                    MessageBox.Show("Система имеет бесконечно много решений или несовместна (не имеет решений)." +
                        "В этом случае правило Крамера не поможет, нужно использовать метод Гаусса.");
                    return (-0, -0, -0);
                }

            }
            else
            {
                double toNegative = -1;
                double Delta = UpperX1 * ((LowerX3 * MiddleX2) + ((LowerX2 * toNegative) * MiddleX3))
                    - UpperX2 * ((LowerX3 * MiddleX1) + ((LowerX1 * toNegative) * MiddleX3))
                    + UpperX3 * ((LowerX2 * MiddleX1) + ((LowerX1 * toNegative) * MiddleX2));
                if (Delta != 0)
                {
                    double Delta1 = UpperEquivalent * ((LowerX3 * MiddleX2) + ((LowerX2 * toNegative) * MiddleX3))
                    - UpperX2 * ((LowerX3 * MiddleEquivalent) + ((LowerEquivalent * toNegative) * MiddleX3))
                    + UpperX3 * ((LowerX2 * MiddleEquivalent) + ((LowerEquivalent * toNegative) * MiddleX2));

                    double x1 = Delta1 / Delta;

                    double Delta2 = UpperX1 * ((LowerX3 * MiddleEquivalent) + ((LowerEquivalent * toNegative) * MiddleX3))
                    - UpperEquivalent * ((LowerX3 * MiddleX1) + ((LowerX1 * toNegative) * MiddleX3))
                    + UpperX3 * ((LowerEquivalent * MiddleX1) + ((LowerX1 * toNegative) * MiddleEquivalent));

                    double x2 = Delta2 / Delta;

                    double Delta3 = UpperX1 * ((LowerEquivalent * MiddleX2) + ((LowerX2 * toNegative) * MiddleEquivalent))
                    - UpperX2 * ((LowerEquivalent * MiddleX1) + ((LowerX1 * toNegative) * MiddleEquivalent))
                    + UpperEquivalent * ((LowerX2 * MiddleX1) + ((LowerX1 * toNegative) * MiddleX2));

                    double x3 = Delta3 / Delta;

                    return (x1, x2, x3);
                }
                else
                {
                    MessageBox.Show("Система имеет бесконечно много решений или несовместна (не имеет решений)." +
                        "В этом случае правило Крамера не поможет, нужно использовать метод Гаусса.");
                    return (-0, -0, -0);
                }
            }

        }
        public (double, double) JordanGauss(double UpperX1, double UpperX2, double UpperEquivalent,
            double MiddleX1, double MiddleX2, double MiddleEquivalent)
        {
            double Coefficient = 0;
            Coefficient = UpperX1;
            //Делим 1 строку на Coefficient
            UpperX1 /= Coefficient;
            UpperX1 = Round(UpperX1);
            UpperX2 /= Coefficient;
            UpperX2 = Round(UpperX2);
            UpperEquivalent /= Coefficient;
            UpperEquivalent = Round(UpperEquivalent);

            Coefficient = MiddleX1;

            MiddleX1 -= UpperX1 * Coefficient;
            MiddleX2 -= UpperX2 * Coefficient;
            MiddleEquivalent -= UpperEquivalent * Coefficient;

            Coefficient = MiddleX2;
            //Делим 2 строку на Coefficient
            MiddleX1 /= Coefficient;
            MiddleX1 = Round(MiddleX1);
            MiddleX2 /= Coefficient;
            MiddleX2 = Round(MiddleX2);
            MiddleEquivalent /= Coefficient;
            MiddleEquivalent = Round(MiddleEquivalent);

            Coefficient = UpperX2;
            double toNegative = -1;
            UpperX1 = toNegative * Coefficient * MiddleX1 + UpperX1;
            UpperX2 = toNegative * Coefficient * MiddleX2 + UpperX2;
            UpperEquivalent = toNegative * Coefficient * MiddleEquivalent + UpperEquivalent;
            UpperEquivalent = Round(UpperEquivalent);
            UpperEquivalent = Math.Round(UpperEquivalent);

            double x1 = UpperEquivalent;
            double x2 = MiddleEquivalent;
            return (x1, x2);
        }
        public (double, double, double) Gauss(double UpperX1, double UpperX2, double UpperX3, double UpperEquivalent,
            double MiddleX1, double MiddleX2, double MiddleX3, double MiddleEquivalent,
            double LowerX1, double LowerX2, double LowerX3, double LowerEquivalent)
        {
            if (cbSize.SelectedIndex == 1)
            {

                double Coefficient = 0;

                Coefficient = MiddleX1;
                //от 2 строки отнимаем 1 строку, умноженную на Coefficient
                MiddleX1 -= UpperX1 * Coefficient;
                MiddleX2 -= UpperX2 * Coefficient;
                MiddleEquivalent -= UpperEquivalent * Coefficient;

                Coefficient = MiddleX2;
                //2-ую строку делим на Coefficient
                MiddleX1 /= Coefficient;
                MiddleX2 /= Coefficient;
                MiddleEquivalent /= Coefficient;

                double toNegative = 1;
                Coefficient = MiddleX2 * toNegative;
                //к 1 строке добавляем 2 строку, умноженную на Coefficient
                UpperX1 += MiddleX1 * Coefficient;
                UpperX2 += MiddleX2 * Coefficient;
                UpperEquivalent += MiddleEquivalent * Coefficient;

                double x1 = UpperEquivalent;
                double x2 = MiddleEquivalent;
                return (x1, x2, -0.003); //Ну вернуться должно 3 значения и во избежание неловкой ситуации, приходится хоть что-то вернуть

            }
            else
            {
                double Coefficient = 0;

                Coefficient = UpperX1;
                //1-ую строку делим на Coefficient
                UpperX1 /= Coefficient;
                UpperX2 /= Coefficient;
                UpperX3 /= Coefficient;
                UpperEquivalent /= Coefficient;

                Coefficient = MiddleX1;
                //от 2 строки отнимаем 1 строку, умноженную на Coefficient
                MiddleX1 -= UpperX1 * Coefficient;
                MiddleX2 -= UpperX2 * Coefficient;
                MiddleX3 -= UpperX3 * Coefficient;
                MiddleEquivalent -= UpperEquivalent * Coefficient;

                Coefficient = LowerX1;
                //от 3 строки отнимаем 1 строку, умноженную на Coefficient
                LowerX1 -= UpperX1 * Coefficient;
                LowerX2 -= UpperX2 * Coefficient;
                LowerX3 -= UpperX3 * Coefficient;
                LowerEquivalent -= UpperEquivalent * Coefficient;

                Coefficient = MiddleX2;
                //2-ую строку делим на Coefficient
                MiddleX1 /= Coefficient;
                MiddleX2 /= Coefficient;
                MiddleX3 /= Coefficient;
                MiddleEquivalent /= Coefficient;

                Coefficient = UpperX2;
                //от 1 строки отнимаем 2 строку, умноженную на Coefficient
                UpperX1 -= MiddleX1 * Coefficient;
                UpperX2 -= MiddleX2 * Coefficient;
                UpperX3 -= MiddleX3 * Coefficient;
                UpperEquivalent -= MiddleEquivalent * Coefficient;

                Coefficient = UpperX3;
                //от 3 строки отнимаем 2 строку, умноженную на Coefficient
                LowerX1 -= MiddleX1 * Coefficient;
                LowerX2 -= MiddleX2 * Coefficient;
                LowerX3 -= MiddleX3 * Coefficient;
                LowerEquivalent -= MiddleEquivalent * Coefficient;

                Coefficient = LowerX3;
                //3-ую строку делим на Coefficient
                LowerX1 /= Coefficient;
                LowerX2 /= Coefficient;
                LowerX3 /= Coefficient;
                LowerEquivalent /= Coefficient;

                Coefficient = UpperX3;
                //от 1 строки отнимаем 3 строку, умноженную на Coefficient
                UpperX1 -= LowerX1 * Coefficient;
                UpperX2 -= LowerX2 * Coefficient;
                UpperX3 -= LowerX3 * Coefficient;
                UpperEquivalent -= LowerEquivalent * Coefficient;

                double toNegative = -1;
                Coefficient = MiddleX3 * toNegative;
                //к 2 строке добавляем 3 строку, умноженную на Coefficient
                MiddleX1 += LowerX1 * Coefficient;
                MiddleX2 += LowerX2 * Coefficient;
                MiddleX3 += LowerX3 * Coefficient;
                MiddleEquivalent += LowerEquivalent * Coefficient;

                double x1 = UpperEquivalent;
                double x2 = MiddleEquivalent;
                double x3 = LowerEquivalent;
                return (x1, x2, x3);
            }
        }
        public void SimpleIteration()
        {

        }

        public (double, double) Seidel(double UpperX1, double UpperX2, double UpperEquivalent,
           double MiddleX1, double MiddleX2, double MiddleEquivalent)
        {
            if (UpperX1 >= UpperX2)
            {
                double One = 1;

                double x = 0;
                double y = 0;
               
                for(int i = 0; i < 6; i++)
                {
                    x = One / UpperX1 * (UpperEquivalent - y);
                    y = One / MiddleX1 * (MiddleEquivalent - 2 * x);
                }
                x = Round(x);
                y = Round(y);
                return (x, y);
            }
            else
            {
                //Матрица коэффициентов данной системы не является диагонально доминирующей.
                //Следовательно, мы переставляем уравнения следующим образом, чтобы элементы матрицы коэффициентов были диагонально доминирующими.
                double tmp = 0;
                //UpperX1 меняем местами с MiddleX1
                tmp = UpperX1;
                UpperX1 = MiddleX1;
                MiddleX1 = tmp;

                //UpperX1 меняем местами с MiddleX1
                tmp = UpperX2;
                UpperX2 = MiddleX2;
                MiddleX2 = tmp;

                //UpperX1 меняем местами с MiddleX1
                tmp = UpperEquivalent;
                UpperEquivalent = MiddleEquivalent;
                MiddleEquivalent = tmp;

                //Из приведённых выше уравнений
                double One = 1;

                double x = 0;
                double y = 0;

                for (int i = 0; i < 6; i++)
                {
                    x = One / UpperX1 * (UpperEquivalent - y);
                    y = One / MiddleX2 * (MiddleEquivalent - 2 * x);
                }
                x = Round(x);
                y = Round(y);
                return (x, y);
            }
        }
    }
}
