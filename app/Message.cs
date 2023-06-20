using System;
using System.Globalization;

public class Message
{
    private float balance;

    public float GetBalance()
    {
        return balance;
    }

    public void InputBalance()
    {
        Console.WriteLine("Hello, please enter your balance: ");
        
        string balanceInput = Console.ReadLine();

        if (float.TryParse(balanceInput, out float parsedBalance))
        {
            balance = parsedBalance;
            Console.WriteLine("Your balance is " + balance);
        }
        else
        {
            Console.WriteLine("Invalid balance input. Please try again.");
            InputBalance();
        }
    }
}