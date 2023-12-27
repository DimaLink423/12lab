//1 задача
/*
using System;
using System.Collections.Generic;

class EllipticCurvePointsFinder
{
    static void Main()
    {
        int p = 23; // модуль

        Console.WriteLine("Points on the elliptic curve y^2 = (x^3 + x + 1) mod 23:");

        List<Tuple<int, int>> points = FindEllipticCurvePoints(p);

        foreach (var point in points)
        {
            Console.WriteLine("(" + point.Item1 + ", " + point.Item2 + ")");
        }
    }

    static List<Tuple<int, int>> FindEllipticCurvePoints(int p)
    {
        List<Tuple<int, int>> curvePoints = new List<Tuple<int, int>>();

        for (int x = 0; x < p; x++)
        {
            int ySquared = (x * x * x + x + 1) % p;

            // Якщо y^2 - квадрат цілого числа, то знаходимо його корені
            for (int y = 0; y < p; y++)
            {
                if ((y * y) % p == ySquared)
                {
                    curvePoints.Add(new Tuple<int, int>(x, y));
                    curvePoints.Add(new Tuple<int, int>(x, p - y)); // Додаємо відповідний антипод
                }
            }
        }

        return curvePoints;
    }
}
*/
/*
using System;

class Program
{
    static void Main()
    {
        int p = 23; // модуль
        int[] G = { 17, 25 }; // базова точка

        int order = FindPointOrder(G, p);

        Console.WriteLine("Order of point G = (" + G[0] + ", " + G[1] + ") on the elliptic curve y^2 = (x^3 + x + 1) mod 23 is: " + order);
    }

    static int FindPointOrder(int[] G, int p)
    {
        int[] currentPoint = G;
        int order = 1;

        while (!IsZeroPoint(currentPoint))
        {
            currentPoint = AddPoints(currentPoint, G, p);
            order++;
        }

        return order;
    }

    static bool IsZeroPoint(int[] point)
    {
        return (point[0] == -1 && point[1] == -1); // Перевірка на нульову точку
    }

    static int[] AddPoints(int[] P, int[] Q, int p)
    {
        int[] result = new int[2];
        int lambda;

        if (P[0] == Q[0] && P[1] == Q[1])
        {
            lambda = ((3 * P[0] * P[0] + 1) * ModInverse(2 * P[1], p)) % p;
        }
        else
        {
            lambda = ((Q[1] - P[1]) * ModInverse(Q[0] - P[0] + p, p)) % p;
        }

        result[0] = (lambda * lambda - P[0] - Q[0]) % p;
        result[1] = (lambda * (P[0] - result[0]) - P[1]) % p;

        if (result[0] < 0)
        {
            result[0] += p;
        }

        if (result[1] < 0)
        {
            result[1] += p;
        }

        return result;
    }

    static int ModInverse(int a, int m)
    {
        a = a % m;

        for (int x = 1; x < m; x++)
        {
            if ((a * x) % m == 1)
            {
                return x;
            }
        }

        return 1;
    }
}*/



//2  задача


using System;

class Program
{
    static void Main()
    {
        int p = 23; // модуль
        int[] G = { 17, 25 }; // базова точка

        int order = FindPointOrder(G, p);

        Console.WriteLine("Order of point G = (" + G[0] + ", " + G[1] + ") on the elliptic curve y^2 = (x^3 + x + 1) mod 23 is: " + order);
    }

    static int FindPointOrder(int[] G, int p)
    {
        int[] currentPoint = G;
        int order = 1;

        while (!IsBasePoint(currentPoint, G))
        {
            currentPoint = AddPoints(currentPoint, G, p);
            order++;
        }

        return order;
    }

    static bool IsBasePoint(int[] point, int[] basePoint)
    {
        return (point[0] == basePoint[0] && point[1] == basePoint[1]); // Перевірка на базову точку
    }

    static int[] AddPoints(int[] P, int[] Q, int p)
    {
        int[] result = new int[2];
        int lambda;

        if (P[0] == Q[0] && P[1] == Q[1])
        {
            lambda = ((3 * P[0] * P[0] + 1) * ModInverse(2 * P[1], p)) % p;
        }
        else
        {
            lambda = ((Q[1] - P[1]) * ModInverse(Q[0] - P[0] + p, p)) % p;
        }

        result[0] = (lambda * lambda - P[0] - Q[0]) % p;
        result[1] = (lambda * (P[0] - result[0]) - P[1]) % p;

        if (result[0] < 0)
        {
            result[0] += p;
        }

        if (result[1] < 0)
        {
            result[1] += p;
        }

        return result;
    }

    static int ModInverse(int a, int m)
    {
        a = a % m;

        for (int x = 1; x < m; x++)
        {
            if ((a * x) % m == 1)
            {
                return x;
            }
        }

        return 1;
    }
}