using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triwizard_Tournament
{
    class Supervisor
    {
        static void Main(string[] args)
        {
            Labyrinth labyrinth = new Labyrinth(13);
            //add edges
            labyrinth.addEdge(0, 3);
            labyrinth.addEdge(1, 3);
            labyrinth.addEdge(1, 4);
            labyrinth.addEdge(1, 5);
            labyrinth.addEdge(2, 5);
            labyrinth.addEdge(3, 6);
            labyrinth.addEdge(3, 4);
            labyrinth.addEdge(4, 5);
            labyrinth.addEdge(4, 7);
            labyrinth.addEdge(3, 7);
            labyrinth.addEdge(5, 8);
            labyrinth.addEdge(8, 7);
            labyrinth.addEdge(7, 6);
            labyrinth.addEdge(6, 9);
            labyrinth.addEdge(9, 10);
            labyrinth.addEdge(10, 11);
            labyrinth.addEdge(10, 12);
            labyrinth.addEdge(8, 11);
            labyrinth.addEdge(5, 7);
            //set finish point
            labyrinth.setFinish(11);
            //setting wizard name, start-point, and speed
            Wizards wizard = new Wizards("Hermione", 0, 2);
            Wizards wizard1 = new Wizards("Sirius Black", 1, 3);
            Wizards wizard2 = new Wizards("Dobby", 2, 4);

            Console.WriteLine("------------------Finish--------------------");
            Console.WriteLine(string.Format("The finish is {0}. Node. " ,Labyrinth.getFinish()));
            Console.WriteLine("--------------------------------------------\n");

            Console.WriteLine(wizard.getWizard());
            Console.WriteLine(wizard1.getWizard());
            Console.WriteLine(wizard2.getWizard());
            Console.WriteLine("--------Path which is used by Wizard--------\n");
            wizard1.magicalWand();
            wizard.magicalWand();
            wizard2.magicalWand();

            float[] times = new float[3];
            times[0] = wizard.getTime();
            times[1] = wizard1.getTime();
            times[2] = wizard2.getTime();
            float min = times[0];
            int temp = 0;
            for (int i = 1; i < times.Length; i++)
            {
                if (min > times[i])
                {
                    min = times[i];
                    temp = i;
                }
            }
            Console.WriteLine("------------------Winner--------------------");
            switch (temp)
            {
                case 0:
                    Console.WriteLine(string.Format("Winner is {0},Time: {1} " ,wizard.getName(),wizard.getTime()));
                    break;
                case 1:
                    Console.WriteLine(string.Format("Winner is {0},Time: {1} ", wizard1.getName(), wizard1.getTime()));
                    break;
                default:
                    Console.WriteLine(string.Format("Winner is {0},Time: {1} ", wizard2.getName(), wizard2.getTime()));
                    break;
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}

