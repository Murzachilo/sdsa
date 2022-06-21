using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace calculator
{
    internal class Decision
    {
        public LinkedList<Double> st = new LinkedList<Double>(); //Лист операндов
        public LinkedList<Char> op = new LinkedList<Char>(); // Лист операторов
        private String equation; // Вычисляемое выражение

        /**
         * Конструктор
         * Принимаети выражение и вызывает метод calculation
         *
         * @param equation вычисляемое выражение типа ((2+2)*2)
         */
        public Decision(String equation)
        {
            this.equation = equation;
            сalculation();
        }


        /**
         * Проверять символ на оператор
         * Добаляет оператор в список оперпаторов и прогоняет через приоретет
         *
         * @param c Проверяемый символ
         * @return возвращает true если оператор
         */
        private Boolean isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%')
            {
                while (!(op.Count == 0) && priority(op.Last()) >= priority(c)) {
                    
                    processOperator(st, op.Last());
                    op.RemoveLast();
                }
                op.AddLast(c);
                return true;
            }
            return false;
        }


        /**
         * Определять приоритетность оператора
         *
         * @param op Проверяемый символ
         * @return Приоретет символа
         */
        static int priority(char op)
        {

            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                case '%':
                    return 2;
                default:
                    return -1;

            }
        }


        /**
         * Производить операцию над двумя значениями
         *
         * @param st Лист значений
         * @param op математический оператор
         */
        static void processOperator(LinkedList<Double> st, char op)
        {
            
            double r = st.Last();
            st.RemoveLast();
            double l = st.Last();
            st.RemoveLast();
            switch (op)
            {
                case '+':
                    st.AddLast(l + r);
                    break;
                case '-':
                    st.AddLast(l - r);
                    break;
                case '*':
                    double x = l * r;
                    st.AddLast(x);
                    break;
                case '/':
                    st.AddLast(l / r);
                    break;
                case '%':
                    st.AddLast(l % r);
                    break;
            }
        }

        /**
         * Производить проверку текущего символа - если текущий символ цифра,
         * проверят следующие символы пока не получится число
         *
         * @param i - индекс текущего символа
         * @return i
         */
        public int isNum(int i)
        {
            String operand = "";
            Boolean isContainDot = false;
            try
            {
                while (i < equation.Length && (Char.IsDigit(equation[i]) || equation[i] == '.'))
                {
                    if (equation[i] == '.')
                    {
                        if (isContainDot) try
                            {
                                throw new Exception(equation + " at position " + i);
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine("Что-то пошло не так в изнум");
                            }
                        else isContainDot = true;
                    }
                    operand += equation[i++];
                }
                --i;
                st.AddLast(Double.Parse(operand));
            }
            catch (Exception er)
            {
                i++;
                Console.WriteLine("Что-то пошло не так в изнум");
                st.AddFirst(0.0);
            }
            return i;
        }

        /**
         * Прогонять и разбивать на операнды и опероторы символы строки,
         * для дальнейших вычислений
         */
        public void сalculation()
        {
            equation += "  ";
            Console.WriteLine(equation);
            for (int i = 0; i < equation.Length - 1; i++)
            {
                switch (equation[i])
                {
                    case ' ':
                        {
                            continue;
                        }
                    case '(':
                        {
                            op.AddLast('(');
                            continue;
                        }
                    case ')':
                        {
                            while (op.Last() != '(')
                            {
                                
                                processOperator(st, op.Last());
                                op.RemoveLast();
                            }
                            op.RemoveLast();
                            continue;
                        }
                }
                if (!isOperator(equation[i]))  // Проверка на оператор
                    i = isNum(i);
            }
        }

        /**
         * Возвращать ответ
         *
         * @return результат типа Double
         */
        public double getAnswer()
        {
            while (!(op.Count == 0))
                try
                {  
                    processOperator(st, op.Last());
                    op.RemoveLast();
                }
                catch (Exception err)
                {
                    Console.WriteLine("Что-то пошло не так в гетАнс");
                    return 0;
                }
            return st.First();
        }
    }
}
