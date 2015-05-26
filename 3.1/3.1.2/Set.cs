using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._2
{
    public class Set : Queue
    {
        public override void Enqueue(object obj)
        {
            if (!base.Contains(obj))
            {
                base.Enqueue(obj);
            }
        }
    }
}
