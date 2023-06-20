using System;
using System.Collections.Generic;

internal class Calcul
{
    private Message? balance;
    private Multiplier goodMultiplier;
    private float result;

    public void SetBalance(Message message)
    {
        balance = message;
    }

    public void SetMultiplier(Multiplier multiplier)
    {
        goodMultiplier = multiplier;
    }

    public void Calculate(DrawFirstGrid drawGrid)
    {
        result = balance.GetBalance() * goodMultiplier.Transform(drawGrid);
        Console.WriteLine("Congratulations, your new balance is: " + result);
    }
}