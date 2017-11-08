using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace ENN
{
    class World
    {
        ObservableCollection<Individual> m_individuals;
        static World m_world = null;
        List<Individual> m_marryApplyList;
        Dictionary<Individual, Individual> m_marriedList;
        List<Individual> m_workApplyList;

        private World()
        {
        }

        public static World getInstance()
        {
            if (World.m_world == null)
            {
                bigBang();
            }
            return m_world;
        }

        static void bigBang()
        {
            m_world = new World();
            m_world.m_individuals = new ObservableCollection<Individual>();
            m_world.m_individuals.CollectionChanged += m_world.newBabyCome;
        }

        public int run()
        {
            while (!World.getInstance().isDestory())
            {
                foreach (Individual i in m_individuals)
                {
                    i.spendOneDay();
                }

                World.getInstance().handleWorkApplyList();
                World.getInstance().handleMarryApplyList();
            }
            return 0;
        }

        public bool isDestory()
        {
            return false;
        }

        public int newBaby(Individual newBaby)
        {
            m_individuals.Add(newBaby);
            return 0;
        }

        private void newBabyCome(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                (args.NewItems[0] as Individual).alive();
            }
        }

        public int applyMarry(Individual owner)
        {
            if (!m_marryApplyList.Contains(owner))
            {
                m_marryApplyList.Add(owner);
                return 1;
            }
            return 0;
        }

        public int wedding(Individual owner)
        {
            return 0;
        }

        public int applyWork(Individual owner)
        {
            return 0;
        }

        public int funeral(Individual owner)
        {
            return 0;
        }

        private int handleWorkApplyList()
        {
            return 0;
        }
        private int handleMarryApplyList()
        {
            return 0;
        }
    }
}
