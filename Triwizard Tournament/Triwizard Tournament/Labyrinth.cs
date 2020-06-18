using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triwizard_Tournament
{
    class Labyrinth
    {
        public static int V;
        public static List<int>[] adj;
        public static int finish;

        public Labyrinth(int v)
        {
            V = v;
            adj = new List<int>[V];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        public void setFinish(int finish)
        {
            Labyrinth.finish = finish;
        }

        public static int getFinish()
        {
            return finish;
        }

        public static int getV()
        {
            return V;
        }

        public static List<int>[] getAdj()
        {
            return adj;
        }

        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }
    }
}
