using System;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите уравнение: ");
                string s = Console.ReadLine();
                SimbolCalculator calculator = new SimbolCalculator(s);

                //Ввод значений на которые будут заменены переменные
                inputValues(calculator);


                calculator.calculate();

                Console.WriteLine("Введите что-нибудь чтобы продолжить или Нажмите Enter что-бы выйти");
                s = Console.ReadLine();
                if (string.IsNullOrEmpty(s)) {
                    break;
                }
            }
        }
        private static void inputValues(SimbolCalculator calculator)
        {
            foreach (ParamInfo paramInfo in calculator.getParamInfos())
            {
                Boolean paramInitialize = false;
                do
                {
                    try
                    { 
                        Console.Write("Введите значение " + paramInfo.getSimb() + " = ");
                        double i = Convert.ToDouble(Console.ReadLine());
                        paramInfo.setValue(i);

                        paramInitialize = true;

                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Неправильно введено");
                        Console.Write("Введите снова: ");
                    }
                } while (!paramInitialize);
            }
        }
    }
}
