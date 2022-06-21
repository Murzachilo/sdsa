using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class SimbolCalculator
    {
        /**
    * Решаемое уравнение
    */
        private String equation;

        /**
         * Информация о значениях параметров уравнения
         */
        private List<ParamInfo> paramInfos = new List<ParamInfo>();

        /**
         * Конструктор
         * Выделяет переменные и добавляет их в класс
         *
         * @param equation - расчитываемое значение вида "A3 + B4 * (A2 - A1)"
         */
        public SimbolCalculator(String equation)
        {
            this.equation = modifyEquation(equation);

            List<String> parames = new List<String>(Selection.convert(this.equation));
            parames.Reverse();

            foreach (String s in parames)
            {
                this.paramInfos.Add(new ParamInfo(s));
            }
        }

        public List<ParamInfo> getParamInfos()
        {
            return paramInfos;
        }

        /**
         * Заменить переменные выражения значениями values
         */
        public void replaceValues()
        {
            foreach (ParamInfo paramInfo in getParamInfos())
                equation = equation.Replace(paramInfo.getSimb(), paramInfo.getValue().ToString());
        }


        /**
         * Изменяет и дополняет уравнение
         * Замена знаков деления(: на /)
         * Замена запятых на точки
         * Добавление знаков умножения (3x -> 3*x) (3(2+2) -> 3*(2+2))
         *
         * @param str уравнение
         * @return Исправленное уравнение
         */
        public static String modifyEquation(String str)
        {       //Обработка
            str = str.Replace(" ", "");
            str = str.Replace(":", "/"); //Заменяем знак деления на нужный нам оператор
            str = str.Replace(",", ".");
            int y = 1;
            String str2 = str;

            for (int i = 0; i < str.Length - 1; i++)
            {     // Добавление недостающих знаков умножения
                if (Char.IsDigit(str[i]) && Char.IsLetter(str[i+1])) {
                    str2 = (new StringBuilder(str2)).Insert(i + y, "*").ToString();
                    y++;
                }
                if ((Char.IsDigit(str[i]) || Char.IsLetter(str[i])) && str[i+1] == '(')
                {
                    str2 = (new StringBuilder(str2)).Insert(i + y, "*").ToString();
                    y++;
                }
            }

            return str2;
        }


        /**
         * Рассчитать выражение
         * Выводить ответ
         */
        public void calculate()
        {
            this.replaceValues();   //Замена переменных введёными значениями
            Decision des = new Decision(equation);
            Console.WriteLine("Ответ: " + des.getAnswer());
        }
    }
}
