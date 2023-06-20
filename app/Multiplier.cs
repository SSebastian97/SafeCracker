public class Multiplier
{
    private DrawFirstGrid drawGrid;
    private string multiplier;

    public void SetDrawGrid(DrawFirstGrid grid)
    {
        drawGrid = grid;
    }

    public int Transform(DrawFirstGrid drawGrid)
{
    multiplier = drawGrid.GetMultiplierValue();
    string numericPart = multiplier.Substring(1);
    int result = int.Parse(numericPart);
    return result;
}
}