using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madrugada.Utilities
{
    public static class ListToStringConverter
    {
        public static string Setter(IEnumerable<object> input, string emptyIndicator = null)
        {
            string output;
            if (input.Count() == 0)
            {
                output = emptyIndicator;
            }
            else
            {
                output = "";
                foreach (var item in input)
                {
                    output += item.ToString();
                    output += ",";
                }
                output = output.TrimEnd(',');
            }
            return output;
        }
        public static IEnumerable<long> LongGetter(string input, string emptyIndicator = null)
        {
            if (input == emptyIndicator)
            {
                return new List<long>();
            }
            else
            {
                var arr = input.Split(',');
                var lst = new List<long>();
                foreach (var item in arr)
                {
                    lst.Add(long.Parse(item));
                }
                return lst;
            }
        }
        /// <summary>
        /// 默认分隔符为 ','
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IEnumerable<string> StringGetter(string input, char splitter = ',', string emptyIndicator = null)
        {
            if ((input == emptyIndicator) || (input == null))
            {
                return new List<string>();
            }
            else
            {
                var arr = input.Split(splitter);
                var lst = new List<string>();
                foreach (var item in arr)
                {
                    lst.Add(item);
                }
                return lst;
            }
        }
    }
}
