using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private int[,] marks;

            public string Name => name;
            public string Surname => surname;
            public int[,] Marks => marks;

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            total += marks[i, j];
                        }
                    }
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[2, 5];
            }

            public void Jump(int[] result)
            {
                if (result.Length != 5)
                {
                    return;
                }

                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    bool isNull = true;
                    for (int j = 0; j < marks.GetLength(1); j++)
                    {
                        if (marks[i, j] != 0)
                        {
                            isNull = false;
                            break;
                        }
                    }

                    if (isNull)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            marks[i, j] = result[j];
                        }
                        return;
                    }
                }

                return;
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
            }

            public void Print()
            {
                Console.WriteLine($"Имя участника - {Name},\nФамилия участника - {Surname},\nСумма баллов - {TotalScore}");
                Console.WriteLine("Оценки судей:");
                for (int jumpIndex = 0; jumpIndex < marks.GetLength(0); jumpIndex++)
                {
                    Console.Write("Прыжок №" + (jumpIndex + 1) + ": ");
                    for (int judgeIndex = 0; judgeIndex < marks.GetLength(1); judgeIndex++)
                    {
                        Console.Write($"Судья {judgeIndex + 1}: {marks[jumpIndex, judgeIndex]}, ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}