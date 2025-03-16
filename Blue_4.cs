using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 { 
    public class Blue_4 {
        public struct Team
        {
            private string name;
            private int[] scores;
            private int matchCount;

            public string Name => name;
            public int[] Scores => scores;

            public int TotalScore
            {
                get
                {
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
                this.scores = new int[10];
                this.matchCount = 0;
            }

            public void PlayMatch(int result)
            {
                if (matchCount < scores.Length)
                {
                    scores[matchCount] = result;
                    matchCount++;
                }
                else
                {
                    throw new InvalidOperationException("Превышено допустимое колличество матчей");
                }
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
                this.teams = new Team[12];
                this.teamCount = 0;
            }

            public void Add(Team team)
            {
                if (teamCount < teams.Length)
                {
                    teams[teamCount] = team;
                    teamCount++;
                }
                else
                {
                    throw new InvalidOperationException("Превышено максимальное количество команд в группе");
                }
            }

            public void Add(Team[] newTeams)
            {
                foreach (var team in newTeams)
                {
                    Add(team);
                }
            }

            public void Sort()
            {
                Array.Sort(teams, 0, teamCount, Comparer<Team>.Create((x, y) => y.TotalScore.CompareTo(x.TotalScore)));
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Team[] mergedTeams = new Team[size];
                int index = 0;

                for (int i = 0; i < group1.teamCount && index < size; i++)
                {
                    mergedTeams[index++] = group1.teams[i];
                }

                for (int i = 0; i < group2.teamCount && index < size; i++)
                {
                    mergedTeams[index++] = group2.teams[i];
                }

                Group finalGroup = new Group("Финалисты");
                finalGroup.Add(mergedTeams);

                return finalGroup;
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