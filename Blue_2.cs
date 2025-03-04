using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        this.marks = new int[5, 2];
    }

    public void Jump(int[] result)
    {
        if (result.Length < 5)
        {
            throw new ArgumentException("Похоже, кто-то из судей опаздывает. (Нужно ровно 5 значений)");
        }
        else if (result.Length > 5)
        {
            throw new ArgumentException("Слишком много глаз, программа нервничает. (Нужно ровно 5 значений)");
        }

        for (int jumpIndex = 0; jumpIndex < marks.GetLength(1); jumpIndex++)
        {
            bool isEmpty = true;
            for (int judgeIndex = 0; judgeIndex < marks.GetLength(0); judgeIndex++)
            {
                if (marks[judgeIndex, jumpIndex] != 0)
                {
                    isEmpty = false;
                    break;
                }
            }

            if (isEmpty)
            {
                for (int judgeIndex = 0; judgeIndex < marks.GetLength(0); judgeIndex++)
                {
                    marks[judgeIndex, jumpIndex] = result[judgeIndex];
                }
                return;
            }
        }
    }

    public static void Sort(Participant[] array)
    {
        Array.Sort(array, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
    }

    public void Print()
    {
        Console.WriteLine($"Имя участника - {Name},\nФамилия участника - {Surname},\nСумма баллов - {TotalScore}");
        Console.WriteLine("Оценки судей:");
        for (int jumpIndex = 0; jumpIndex < marks.GetLength(1); jumpIndex++)
        {
            Console.Write("Прыжок №" + (jumpIndex + 1) + ": ");
            for (int judgeIndex = 0; judgeIndex < marks.GetLength(0); judgeIndex++)
            {
                Console.Write($"Судья {judgeIndex}: {marks[judgeIndex, jumpIndex]}, ");
            }
            Console.WriteLine();
        }
    }
}
