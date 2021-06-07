using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.DTO
{
  public  class ObjectCount
    {
        private string Values;
        private int Count;
        public ObjectCount(string a, int b)
        {
            Values1 = a;
            Count1 = b;
        }
        public string Values1 { get => Values; set => Values = value; }
        public int Count1 { get => Count; set => Count = value; }
    }
}
