using System;
using System.Collections.Generic;

public class DrawFirstGrid
{
    private List<string> valuesList = new List<string>();
    private string multiplier;

    public void SetListValue(List<string> newValue)
    {
        valuesList = newValue;
    }

    public List<string> GetValue()
    {
        return valuesList;
    }

    public void SetMultiplierValue(string multiplierValue)
    {
        multiplier = multiplierValue;
    }

    public string GetMultiplierValue()
    {
        return multiplier;
    }

    public void Grid()
    {
        int rows = 3; // Number of rows in the grid
        int columns = 3; // Number of columns in the grid
        string[,] gridValues = new string[rows, columns];

        GridInitialization(gridValues);

        DrawGrid(gridValues);

        int filledCells = 0;
        Random random = new Random();
        bool stopInput = false;
        int spinCount = 0;
        bool duplicateMultiplierFound = false;

        do
        {
            Console.WriteLine("Press space to play or press 'Q' to quit.");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Q)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                spinCount++;

                int cellIndex = GetRandomUnfilledCell(gridValues, random);
                if (cellIndex == -1)
                {
                    Console.WriteLine("No more unfilled cells available.");
                    continue;
                }

                int row = cellIndex / columns;
                int column = cellIndex % columns;

                if (spinCount <= valuesList.Count)
                {
                    if (gridValues[row, column] == (row * columns + column + 1).ToString() && gridValues[row, column] != "X")
                    {
                        if (!valuesList.Contains(gridValues[row, column]))
                        {
                            gridValues[row, column] = valuesList[spinCount - 1];
                        }
                        else
                        {
                            // Cell already contains a modifier, skip this iteration
                            continue;
                        }
                    }
                    else
                    {
                        // Cell already modified, skip this iteration
                        continue;
                    }
                }
                else
                {
                    string randomMultiplier = new RandomNumber().GenerateMultiplier();
                    valuesList.Add(randomMultiplier);
                    SetListValue(valuesList);
                    gridValues[row, column] = randomMultiplier;
                }

                filledCells++;
                DrawGrid(gridValues);

                if (CheckForRepeatedValue(valuesList))
                {
                    duplicateMultiplierFound = true;
                    break; // Exit the loop when a duplicate multiplier appears within the first 4 spins
                }

                Console.WriteLine("Multiplier appeared in cell: " + (cellIndex + 1));
            }
        }
        while (!stopInput);

        if (duplicateMultiplierFound)
        {
            Console.WriteLine("Game ended. Multiplier repeated!");
        }
        
    }

    private void GridInitialization(string[,] gridValues)
    {
        int rows = gridValues.GetLength(0);
        int columns = gridValues.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                gridValues[i, j] = (i * columns + j + 1).ToString();
            }
        }
    }

    private int GetRandomUnfilledCell(string[,] gridValues, Random random)
    {
        int rows = gridValues.GetLength(0);
        int columns = gridValues.GetLength(1);
        List<int> unfilledCells = new List<int>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (gridValues[i, j] != "X" && !valuesList.Contains(gridValues[i, j]))
                {
                    int cellIndex = i * columns + j;
                    unfilledCells.Add(cellIndex);
                }
            }
        }

        if (unfilledCells.Count == 0)
        {
            return -1;
        }

        int randomIndex = random.Next(unfilledCells.Count);
        return unfilledCells[randomIndex];
    }

    private bool CheckForRepeatedValue(List<string> values)
    {
        HashSet<string> uniqueValues = new HashSet<string>();
        foreach (string value in values)
        {
            if (!uniqueValues.Add(value))
            {
                Console.WriteLine("Your multiplier is: " + value);
                SetMultiplierValue(value);
                return true;
            }
        }

        return false;
    }

    private void DrawGrid(string[,] gridValues)
    {
        int rows = gridValues.GetLength(0);
        int columns = gridValues.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write("----");
            }
            Console.WriteLine("-");

            for (int j = 0; j < columns; j++)
            {
                Console.Write($"| {gridValues[i, j]} ");
            }
            Console.WriteLine("|");
        }

        for (int j = 0; j < columns; j++)
        {
            Console.Write("----");
        }
        Console.WriteLine("-");
    }
}