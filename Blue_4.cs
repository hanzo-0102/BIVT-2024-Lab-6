using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_6 { 
    public class Blue_4 {
        public struct Team
        {
            private string name;
            private int[] scores;
            private int matchCount;

            public string Name => name;
            public int[] Scores
            {
                get
                {
                    if (scores == null) return null;
                    int[] Nscores = new int[scores.Length];
                    for (int i = 0; i < Nscores.Length; i++)
                    {
                        Nscores[i] = scores[i];
                    }
                    return Nscores;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null) return 0;
                    int total = 0;
                    for (int i = 0; i < matchCount; i++)
                    {
                        total += scores[i];
                    }
                    return total;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.scores = new int[0];
                this.matchCount = 0;
            }

            public void PlayMatch(int result)
            {
                int[] NScores = new int[scores.Length + 1];
                for (int i = 0; i < scores.Length; i++)
                {
                    NScores[i] = scores[i];
                }
                NScores[NScores.Length - 1] = result;
                scores = NScores;
            }

            public void Print()
            {
                Console.WriteLine($"Команда - {Name} заработала: {TotalScore}");
            }
        }

        public struct Group
        {
            private string name;
            private Team[] teams;
            private int teamCount;

            public string Name => name;
            public Team[] Teams => teams;
            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[0];
                this.teamCount = 0;
            }

            public void Add(Team team)
            {
                if ((teamCount >= 12) || (teams == null)) return;

                else
                {
                    Team[] newteams = new Team[teamCount + 1];
                    newteams[teamCount] = team;
                    teamCount++;
                    teams = newteams;
                }
            }
            public void Add(Team[] teams)
            {
                if (teams == null || teams.Length == 0 || teams == null) return;

                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }

            public void Sort()
            {
                if (teams.Length == 0 || teams == null) return;
                for (int i = 0; i < teams.Length; i++)
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
                Group finalists = new Group("Финалисты");


                if (size != 12) return finalists;
                group1.Sort();
                group2.Sort();


                for (int i = 0; i < size / 2; i++)
                {
                    finalists.Add(group1.Teams[i]);
                }

                for (int i = 0; i < size / 2; i++)
                {
                    finalists.Add(group2.Teams[i]);
                }
                finalists.Sort();
                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {Name}");
                for (int i = 0; i < teamCount; i++)
                {
                    teams[i].Print();
                }
            }
        }
    }
}