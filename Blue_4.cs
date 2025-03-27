using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string name;
            private int[] scores;


            public string Name { get { return name; } }
            public int[] Scores
            {
                get
                {
                    if (scores == null) return null;
                    int[] NScores = new int[scores.Length];
                    for (int i = 0; i < NScores.Length; i++){ NScores[i] = scores[i]; }
                    return NScores;
                }
            }

            public Team(string newname)
            {
                name = newname;
                scores = new int[0];
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null) return 0;
                    int ts = 0;
                    for (int i = 0; i < scores.Length; i++){ ts += scores[i]; }
                    return ts;
                }
            }

            public void PlayMatch(int result)
            {
                int[] NScores = new int[scores.Length + 1];
                for (int i = 0; i < scores.Length; i++) { NScores[i] = scores[i]; }
                NScores[NScores.Length - 1] = result;
                scores = NScores;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} набрала {TotalScore}.");
            }

        }

        public struct Group
        {
            private string name;
            private Team[] teams;
            private int curteams;

            public string Name { get { return name; } }
            public Team[] Teams { get { return teams; } }
            public Group(string newname)
            {
                name = newname;
                teams = new Team[12];
                curteams = 0;
            }
            public void Add(Team team)
            {
                if ((curteams >= 12) || (teams == null)) return;

                else
                {
                    teams[curteams] = team;
                    curteams++;
                }
            }
            public void Add(Team[] newteams)
            {
                if (teams == null || newteams.Length == 0 || newteams == null) return;

                for (int i = 0; i < newteams.Length; i++)
                {
                    Add(newteams[i]);
                }
            }
            public void Sort()
            {
                if (teams == null || teams.Length == 0) return;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group ngroup = new Group("Финалисты");

                if (size != 12) return ngroup;
                
                group1.Sort();
                group2.Sort();


                for (int i = 0; i < size / 2; i++)
                {
                    ngroup.Add(group1.Teams[i]);
                }

                for (int i = 0; i < size / 2; i++)
                {
                    ngroup.Add(group2.Teams[i]);
                }

                ngroup.Sort();

                return ngroup;
            }

            public void Print()
            {
                Console.WriteLine($"Группа {name}");
                for (int i = 0; i < teams.Length; i++)
                {
                    teams[i].Print();
                }


            }

        }

    }

}