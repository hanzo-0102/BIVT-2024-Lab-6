using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private int[] penaltyTimes;
            private int matchCount;

            public string Name => name;
            public string Surname => surname;
            public int[] PenaltyTimes => penaltyTimes;

            public int TotalTime
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < matchCount; i++)
                    {
                        total += penaltyTimes[i];
                    }
                    return total;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    for (int i = 0; i < matchCount; i++)
                    {
                        if (penaltyTimes[i] == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.penaltyTimes = new int[10];
                this.matchCount = 0;
            }

            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10)
                {
                    throw new ArgumentException("Неверное время. Возможные значения: 0, 2, 5, 10");
                }

                if (matchCount < penaltyTimes.Length)
                {
                    penaltyTimes[matchCount] = time;
                    matchCount++;
                }
                else
                {
                    throw new InvalidOperationException("Превышено допустимое количество матчей");
                }
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => x.TotalTime.CompareTo(y.TotalTime));
            }

            // Method to print participant information
            public void Print()
            {
                string status = "";
                if (IsExpelled)
                {
                    status = "Исключён";
                }
                else
                {
                    status = "Остаётся в составе";
                }
                Console.WriteLine($"Имя - {Name},\nФамилия - {Surname},\nВсего времени в 'бане' - {TotalTime},\n{status}");
            }
        }
    }
}