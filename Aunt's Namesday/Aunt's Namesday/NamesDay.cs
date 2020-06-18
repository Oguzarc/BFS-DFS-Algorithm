using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aunt_s_Namesday
{
    class NamesDay
    {
        //enum to get the name from the tables.
        enum Name
        {
            Faruk,
            Oguz,
            Senol,
            Merve,
            Mehmet,
            Ahmet,
        }
        //Creating table for persons.
        static Stack<int> table1 = new Stack<int>();
        static Stack<int> table2 = new Stack<int>();
        static Stack<int> getout = new Stack<int>();
        //Dictionary for the tables to reach separately.
        static Dictionary<string, Stack<int>> tables = new Dictionary<string, Stack<int>>();

        class Plan 
        {           
            public int V;        
            public List<int>[] adj;

            // Constructor 
            public Plan(int V) 
            { 
                this.V = V; 
                adj = new List<int>[V];               
                for (int i = 0; i < adj.Length; i++) 
                    adj[i] = new List<int>();
                tables.Add("Table1", table1);
                tables.Add("Table2", table2);
                tables.Add("getout", getout);
            }

            //Control for the person who sit on table.
            public bool Control(List<int> adj, Stack<int> table)
            {
                foreach(int i in adj)
                {
                    if (table.Contains(i))
                    {
                        return true;
                    }                                     
                }
                return false;
            }
            //Adding person to table using Control Func.
            public void SittingPlan(int i, List<int> adj)
            {               
                if (!Control(adj, table1))
                {
                    table1.Push(i);
                }
                else if (!Control(adj, table2))
                {
                    table2.Push(i);
                }
                else
                {
                    getout.Push(i);
                }               
            }

            public void DislikeConnection(int v, int w) 
            { 
                adj[v].Add(w);
            } 
          
            //DFS Part
            public void ExConnection(int s, List<bool> visited) 
            { 
                Stack<int> stack = new Stack<int>();               
                stack.Push(s); 
              
                while(stack.Count != 0) 
                { 
                    s = stack.Peek(); 
                    stack.Pop(); 
                    if(visited[s] == false) 
                    {                       
                        SittingPlan(s,adj[s]);
                        visited[s] = true;
                    } 
                    foreach(int itr in adj[s])  
                    { 
                        int v = itr; 
                        if(!visited[v]) 
                            stack.Push(v); 
                    } 
                  
                } 
            }
            //DFS initialization
            public void Connection() 
            { 
                List<bool> visited = new List<bool>(V); 
                for (int i = 0; i < V; i++) 
                    visited.Add(false); 
      
                for (int i = 0; i < V; i++) 
                    if (!visited[i]) 
                        ExConnection(i, visited); 
            }  
        } 
        
        public static void Main(string[] args)  
        {
            int myName0 = (int)Name.Faruk;
            int myName1 = (int)Name.Oguz;
            int myName2 = (int)Name.Senol;
            int myName3 = (int)Name.Merve;
            int myName4 = (int)Name.Mehmet;
            int myName5 = (int)Name.Ahmet;

            Plan plan = new Plan(6); 
            //Creating dislike conn.
            plan.DislikeConnection(myName0, myName1); 
            plan.DislikeConnection(myName0, myName2); 
            plan.DislikeConnection(myName0, myName3); 
            plan.DislikeConnection(myName1, myName3); 
            plan.DislikeConnection(myName3, myName4); 
            plan.DislikeConnection(myName4, myName5); 
            plan.DislikeConnection(myName5, myName2); 
            plan.DislikeConnection(myName2, myName5); 
            plan.DislikeConnection(myName3, myName0); 
            plan.DislikeConnection(myName1, myName0);
            
            //printing table
            Console.WriteLine("This is the Sitting Plan For Aunt's NamesDay"); 
            plan.Connection();
            foreach (KeyValuePair<string, Stack<int>> table in tables)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("{0}", table.Key);
                foreach (int person in table.Value)
                {
                    Console.WriteLine("Person: {0}", (Name)person);
                }
                Console.WriteLine("--------------------------------------");
            }
        } 
    } 
}
