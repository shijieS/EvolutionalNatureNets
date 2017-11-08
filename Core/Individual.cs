using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace ENN
{
    class Individual
    {
        #region property
        public GeneCode m_geneCode;
        public ObservableCollection<GeneCode> m_babyGeneCode;
        public Body m_body;
        public Individual m_husband;
        #endregion

        #region interface
        public Individual(GeneCode geneCode)
        {
            m_geneCode = geneCode;
        }
        /// <summary>
        /// act is generate from input to output
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Output act(Input input)
        {
            return null;
        }
        #endregion

        public void spendOneDay()
        {
            if (m_body.moveOn() != 0)
            {
                buildBody();        // add age and go to mature
                goToStudy();        // only one learn
                if (hasWork())
                    goToWork();         // combination structure
                else
                    World.getInstance().applyWork(this);

                if (isMature())
                {
                    wantMarry();
                }

                goToSleep();

                if (isMarred())
                {
                    haveSex();
                }
            }
            goDie();
        }

        #region stages during the living
        /// <summary>
        /// build the body by gene code
        /// </summary>
        void buildBody()
        {
            // TODO: during this stage
            // if statisfy the final result, it will mature
            mature();
        }

        void mature()
        {
            m_babyGeneCode.CollectionChanged += spermEggCombination;
        }

        bool isMature()
        {
            return false;
        }

        bool hasWork()
        {
            return false;
        }

        public int wantMarry()
        {
            // If two individual marry, they will have many sex, and will have more probability to have baby.
            World.getInstance().applyMarry(this);
            return 0;
        }

        public bool isMarred()
        {
            return false;
        }
        public int haveSex()
        {
            // If two individual have sex. the parameter will translate a huge sperm with variation to this individual

            // forplay
            m_husband.forplay();

            // shot
            List<GeneCode> sperms = m_husband.shot();

            // the cometition of sperms
            GeneCode successSperm = GeneCode.competition(m_geneCode, sperms);

            // combination with egg.
            if (successSperm != null)
            {
                GeneCode babyGene = m_geneCode.combine(successSperm);
                m_babyGeneCode.Add(babyGene);
            }
            return 0;
        }

        #region about study and work
        public int goToStudy()
        {

            return 0;
        }
        public int goToWork()
        {
            return 0;
        }

        public int goToSleep()
        {
            return 0;
        }
        #endregion

        #region about sex & baby

        public int forplay()
        {
            // prepare genecode(sperm) with little variation
            return 0;
        }
        public List<GeneCode> shot()
        {
            return null;
        }

        private void spermEggCombination(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                Individual baby = (args.NewItems[0] as GeneCode).growth();
                (sender as ObservableCollection<GeneCode>).Remove((args.NewItems[0] as GeneCode));
            }
        }
        #endregion

        #region about die
        public int goDie()
        {
            World.getInstance().funeral(this);
            return 0;
        }
        public int testament()
        {
            // tell my child and my parent I am dead
            // it will change the gene of its own child and his wife will become unmarried.
            if (isMarred())
            {
            }
            return 0;
        }
        public int funeral()
        {
            // tell other people and the world, I am dead.
            return 0;
        }
        #endregion

        #endregion
    }
}
