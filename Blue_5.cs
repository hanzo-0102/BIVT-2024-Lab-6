using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Sportsman
{
    private string name;
    private string surname;
    private int place;
    private bool placeSet;

    public string Name => name;
    public string Surname => surname;
    public int Place => place;

    public Sportsman(string name, string surname)
    {
        this.name = name;
        this.surname = surname;
        this.place = 0;
        this.placeSet = false;
    }

    public void SetPlace(int place)
    {
        if (placeSet)
        {
            throw new InvalidOperationException("Место уже объявлено");
        }

        if (place < 1 || place > 18)
        {
            throw new ArgumentException("Недопустимое значение. Возможный диапазон - от 1 до 18 включительно");
        }

        this.place = place;
        this.placeSet = true;
    }

    // Method to print sportsman information
    public void Print()
    {
        Console.WriteLine($"{Name} {Surname}, занял(а) {Place} место");
    }
}

public struct Team
{
    private string name;
    private Sportsman[] sportsmen;
    private int sportsmanCount;

    public string Name => name;
    public Sportsman[] Sportsmen => sportsmen;

    public int SummaryScore
    {
        get
        {
            int totalScore = 0;
            for (int i = 0; i < sportsmanCount; i++)
            {
                int place = sportsmen[i].Place;
                if (place == 1) totalScore += 5;
                else if (place == 2) totalScore += 4;
                else if (place == 3) totalScore += 3;
                else if (place == 4) totalScore += 2;
                else if (place == 5) totalScore += 1;
            }
            return totalScore;
        }
    }
    public int TopPlace
    {
        get
        {
            int topPlace = int.MaxValue;
            for (int i = 0; i < sportsmanCount; i++)
            {
                if (sportsmen[i].Place < topPlace)
                {
                    topPlace = sportsmen[i].Place;
                }
            }
            return topPlace;
        }
    }
    public Team(string name)
    {
        this.name = name;
        this.sportsmen = new Sportsman[6];
        this.sportsmanCount = 0;
    }

    public void Add(Sportsman sportsman)
    {
        if (sportsmanCount < sportsmen.Length)
        {
            sportsmen[sportsmanCount] = sportsman;
            sportsmanCount++;
        }
        else
        {
            throw new InvalidOperationException("Слишком большая команда (максимальное число спортсменов в команде - 6)");
        }
    }

    public void Add(Sportsman[] newSportsmen)
    {
        foreach (var sportsman in newSportsmen)
        {
            Add(sportsman);
        }
    }

    public static void Sort(Team[] teams)
    {
        Array.Sort(teams, (x, y) =>
        {
            int scoreComparison = y.SummaryScore.CompareTo(x.SummaryScore);
            if (scoreComparison == 0)
            {
                return x.TopPlace.CompareTo(y.TopPlace);
            }
            return scoreComparison;
        });
    }

    public void Print()
    {
        Console.WriteLine($"Команда {Name} заработала в сумме: {SummaryScore}. Высшая позиция в команде: {TopPlace}");
        for (int i = 0; i < sportsmanCount; i++)
        {
            sportsmen[i].Print();
        }
    }
}