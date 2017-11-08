using System;
using System.Collections.Generic;
using System.Text;

namespace ENN
{
    class Body
    {
        /// <summary>
        /// Every change of the body, close to the end of the deadline.
        /// </summary>
        public DeadLine m_deadLine;

        public int moveOn()
        {
            return 1;
        }
    }
}
