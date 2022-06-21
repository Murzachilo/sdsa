using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace calculator
{
    internal class Selection
    {
        private String str;

        public Selection(String str)
        {
            this.str = str;
        }

        /**
         * Проверка символа на оператор
         *
         * @param c Проверяемый символ
         * @return возвращает true если оператор
         */
        public static Boolean isOperator(char c)
        {     // Проверка является ли символ оператором
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '(' || c == ')';
        }

        /**
         * Вытаскивает все переменные из уравнения и возвращает List переменных
         *
         * @param str уравнение
         * @return List Переменных
         */
        public static HashSet<String> convert(String str)
        {   //метод вытаскивающий переменные из записи
            String variable = "";   //То что добавляется в ArrayList
            HashSet<String> arr = new HashSet<String>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')    // Пропускаем пробелы
                    continue;

                if (Char.IsDigit(str[i]))
                {     // Если текущий символ цифра
                    if (variable == "")
                        continue;
                    else
                        variable += str[i];

                }

                if (Char.IsLetter(str[i]) == true)
                {    // Если текущий символ буква
                    variable += str[i];
                }

                if (Selection.isOperator(str[i]))
                {      // Если текущий оператор
                    if (variable != "")
                    {
                        try
                        {
                            arr.Add(variable);
                        }
                        catch (Exception err)
                        {

                        }
                        variable = "";
                    }
                }
            }


            if (variable != "")
            {
                try
                {
                    arr.Add(variable);
                }
                catch (Exception err)
                {
                }
            }
            Console.WriteLine(arr.ToString());
            return arr;
        }
    }
}
