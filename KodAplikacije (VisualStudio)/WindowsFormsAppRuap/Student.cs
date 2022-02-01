using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RUAP
{
    public class Value
    {
        public List<string> ColumnNames { get; set; }
        public List<string> ColumnTypes { get; set; }
        public List<List<string>> Values { get; set; }

        public string getLastValue() {
            int i, j;
            string last="0";
            for (i = 0; i < Values.Count; i++) {
                for (j = 0; j < Values[i].Count; j++) {
                    last = Values[i][j];             
                }
            }
            return last;
        }
    }

    public class Output1
    {
        public string type { get; set; }
        public Value value { get; set; }
    }

    public class Results
    {
        public Output1 output1 { get; set; }
    }

    public class Root
    {
        public Results Results { get; set; }
    }

}
