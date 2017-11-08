using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ENN
{
    /// <summary>
    /// Gene code, which decide the generation of network and have the function of combination.
    /// </summary>
    class GeneCode
    {
        List<BasicCode> m_code;
        DeadLine m_deadLine;

        public GeneCode(List<BasicCode> code)
        {
            m_code = code;
        }

        /// <summary>
        /// sometimes the gene code can variate. 
        /// The variation can only affect the next generation
        /// </summary>
        public void variation()
        {

        }

        /// <summary>
        /// combine another gene code
        /// </summary>
        /// <param name="geneCode"></param>
        /// <returns></returns>
        public GeneCode combine(GeneCode geneCode)
        {
            // combine the gene code
            return null;
        }

        public Individual growth()
        {
            return null;
        }

        static public GeneCode competition(GeneCode egg, List<GeneCode> geneCodes)
        {
            return null;
        }
    }
    
}
