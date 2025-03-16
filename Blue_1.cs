using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            private string name;
            private string surname;
            private int votes;
            public string Name => name;
            public string Surname => surname;
            public int Votes => votes;

            public Response(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.votes = 0;
            }

            public int CountVotes(Response[] responses)
            {
                int count = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == this.Name && responses[i].Surname == this.Surname)
                    {
                        count++;
                    }
                }
                votes = count;
                return votes;
            }

            public void Print()
            {
                Console.WriteLine($"Имя - {Name},\nФамилия - {Surname},\nГолоса - {Votes};");
            }
        }
    }
}