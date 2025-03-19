using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
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
                    if (penaltyTimes == null) return 0;
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
                    if (penaltyTimes == null) return false;
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
                if ((time != 0 && time != 2 && time != 5 && time != 10) || penaltyTimes == null || matchCount < 0)
                {
                    return;
                }

                if (matchCount < penaltyTimes.Length)
                {
                    penaltyTimes[matchCount] = time;
                    matchCount++;
                }
                else
                {
                    return;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

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