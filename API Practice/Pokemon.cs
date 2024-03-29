using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Practice
{
    internal class Pokemon
    {
        private int maxMovesDisplay = 5;
        public int id { get; set; }
        public string name { get; set; }
        public List<string> moves { get; set; }
        public int weight { get; set; }
        public int height { get; set; }

        public Pokemon(int id, string name, List<string> moves, int weight, int height)
        {
            this.id = id;
            this.name = name;
            this.moves = moves;
            this.weight = weight;
            this.height = height;
        }

        public void print() {
            Console.WriteLine("---------------------\n");
            Console.WriteLine("Pokemon: {0}\nWeight: {1}\nHeight: {2}\nMoves:", this.name, this.weight, this.height);

            int i;

            for (i = 0; i < maxMovesDisplay; i++) {
                if (i > this.moves.Count) 
                    break;
                Console.WriteLine("\t* {0}", this.moves[i]);
            }

            if (i < this.moves.Count) 
                Console.WriteLine("\tand {0} others...", this.moves.Count - i);

            Console.WriteLine("");
        }
    }
}
