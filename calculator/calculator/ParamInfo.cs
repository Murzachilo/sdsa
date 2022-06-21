using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class ParamInfo
    {
        /**
    * Обозначение параметра
    */
        private String simb;

        /**
         * Значение параметра
         */
        private Double value;


        public String getSimb()
        {
            return simb;
        }

        public void setSimb(String simb)
        {
            this.simb = simb;
        }

        public Double getValue()
        {
            return value;
        }


        public void setValue(Double value)
        {

            this.value = value;
        }

        public ParamInfo(String simb)
        {
            this.simb = simb;
        }
    }
}
