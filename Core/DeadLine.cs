using System;
using System.Collections.Generic;
using System.Text;

namespace ENN
{
    class DeadLine
    {
        public float current = 0;
        public float end;

        void setEnd()
        {
            // TODO: set the end by guassian distribution
        }

        public DeadLine()
        {

            current = 0;
            setEnd();
        }
        public bool move()
        {
            current++;
            return current < end;
        }
    }
}
