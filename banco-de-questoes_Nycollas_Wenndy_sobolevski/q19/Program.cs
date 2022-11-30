using System;

Vetor v = (1, 2);
Vetor u = (4, 3);
Vetor r = (5, 5);

Console.WriteLine($"{v} + {u} = {r}?");

if (v + u == r)
    Console.WriteLine("Sim!");
else Console.WriteLine("Não! (mas devia)");


public class Vetor
{
    public int a {get; set;}
    public int b {get; set;}
    public Vetor(int[] dados)
    {
        a = dados[0];
        b = dados[1];
    }

    public bool EIgual(Vetor vetor)
    {
        if (this.a == vetor.a && this.b == vetor.b)
            return true;
        else
            return false;   
    }

    public Vetor Soma(Vetor vetor)
    {
        int[] auxa = new int[2];
        auxa[0] = this.a + vetor.a;
        auxa[1] = this.b + vetor.b;


        Vetor aux = new Vetor(auxa);
        return aux;
    }

    public override string ToString()
    {
        return a.ToString() + ", " + b.ToString();
    }

    public static implicit operator Vetor((int, int) tupla)
        => new Vetor(new int[] {
            tupla.Item1, 
            tupla.Item2
        });

    public static implicit operator Vetor((int, int, int) tupla)
        => new Vetor(new int[] {
            tupla.Item1, 
            tupla.Item2,
            tupla.Item3
        });

    public static Vetor operator +(Vetor v, Vetor u)
        => v.Soma(u);

    public static bool operator ==(Vetor v, Vetor u)
        => v.EIgual(u);

    public static bool operator !=(Vetor v, Vetor u)
        => !v.EIgual(u);
}
