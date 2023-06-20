class MainProgram
{
    static void Main(string[] args)
    {
        // Create objects
        DrawFirstGrid grid = new DrawFirstGrid();
        Message message = new Message();
        DrawFirstGrid drawGrid = new DrawFirstGrid();
        Calcul calc = new Calcul();
        Multiplier multiplier = new Multiplier();

        // Input balance
        message.InputBalance();

        // Play the game and generate the grid
        drawGrid.Grid();

        // Set the drawGrid object for the multiplier
        multiplier.SetDrawGrid(drawGrid);

        // Set the balance and multiplier for calculation
        calc.SetBalance(message);
        calc.SetMultiplier(multiplier);

        // Calculate the result
        calc.Calculate(drawGrid);
    }
}