public class Cell
{
    private bool visited;
    private bool[] walls;


    public bool WU { get { return walls[0]; } set { walls[0] = value; } }
    public bool WD { get { return walls[1]; } set { walls[1] = value; } }
    public bool WL { get { return walls[2]; } set { walls[2] = value; } }
    public bool WR { get { return walls[3]; } set { walls[3] = value; } }
    
    public int X { get; }
    public int Y { get; }

    public Cell(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
        visited = false;
        walls = new bool[] { true, true, true, true };
    }

    public void SetVisited(bool state)
    {
        visited = state;
    }

    public void SetWall(int iWall, bool state)
    {
        walls[iWall] = state;
    }

    public bool[] GetWalls()
    {
        return walls;
    }

    public bool GetVisited()
    {
        return visited;
    }
}