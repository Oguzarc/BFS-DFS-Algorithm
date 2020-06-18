using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triwizard_Tournament
{
    public class Wizards
    {
        private string name;
        private int startPoint;
        private  int speed;
        private  int V;
        private  List<int>[]adj;
        float time;

        public Wizards(string name, int start, int speed)
        {
            V = Labyrinth.getV();
            adj = Labyrinth.getAdj();
            this.name = name;
            startPoint = start;
            this.speed = speed;
            time = 0;
        }
        public string getName()
        {
            return name;
        }
        //Show the path that follow by wizard
        public void Show(Stack<int> path)
        {
            Console.Write(name);
            foreach(var i in path.Reverse())
            {
                Console.Write("-"+i);
            }
            Console.WriteLine("\n");
        }
        //using bfs
        //Help the wizard to find shorthest path
        public void magicalWand()
        {
            Stack<int> path = new Stack<int>();
            List<int> queue = new List<int>();
            bool[] visited = new bool[V];

            visited[startPoint] = true;
            queue.Add(startPoint);
            while (queue.Count!=0)
            {
                startPoint = queue[0];
                queue.RemoveAt(0);
                if (startPoint == Labyrinth.getFinish())
                {
                    break;
                }
                path.Push(startPoint);              
                foreach (int i in adj[startPoint])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Add(i);
                    }
                }
            }
            Show(path);
            time = path.Count() / (float)speed;
        }

        public float getTime()
        {
            return time;
        }

        public string getWizard()
        {
            string wizard = "Wizard Name: " + name + "\n" +
                            "Wizard Initial Point: " + startPoint + "\n" +
                            "Wizard Speed: " + speed + "\n";
            return wizard;
        }
    }
}
