using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Maze
{
    private static readonly (int i, int j)[] NeighbourPattern = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
    private readonly Cell[,] cells;
    private int Width { get { return cells.GetLength(0); } }
    private int Height { get { return cells.GetLength(1); } }

    public Maze(int width, int height)
    {
        cells = new Cell[width, height];
        ResetCells();
    }

    public void Randomize(int seed)
    {
        Random.InitState(seed);
        Cell currentCell = cells[0, 0];
        Stack<Cell> cellStack = new();
        currentCell.SetVisited(true);
        cellStack.Push(currentCell);
        while (cellStack.Count != 0)
        {
            currentCell = cellStack.Pop();
            List<Cell> neighbours = GetNeighbourCells(currentCell);
            if (neighbours.Count != 0)
            {
                int iRandom = UnityEngine.Random.Range(0, neighbours.Count);
                Cell rNeighbour = neighbours[iRandom];
                if (!rNeighbour.GetVisited())
                {
                    rNeighbour.SetVisited(true);
                    RemoveWall(currentCell, rNeighbour);
                    cellStack.Push(currentCell);
                    cellStack.Push(rNeighbour);
                }
                neighbours.RemoveAt(iRandom);
            }

        }
    }

    private void ResetCells()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                cells[i, j] = new Cell(i, j);
            }
        }
    }

    public void MazeToTilemap(Tilemap tilemap, Tile wall)
    {
        ResetTileMap(tilemap, wall);
        foreach (Cell cell in cells)
        {
            int tileX = 2 * cell.X + 1;
            int tileY = 2 * cell.Y + 1;
            tilemap.SetTile(new Vector3Int(tileX, tileY, 0), null);
            if (!cell.WU) { tilemap.SetTile(new Vector3Int(tileX, tileY + 1, 0), null); }
            if (!cell.WD) { tilemap.SetTile(new Vector3Int(tileX, tileY - 1, 0), null); }
            if (!cell.WL) { tilemap.SetTile(new Vector3Int(tileX - 1, tileY, 0), null); }
            if (!cell.WR) { tilemap.SetTile(new Vector3Int(tileX + 1, tileY, 0), null); }
        }
        tilemap.SetTile(new Vector3Int(0, 1, 0), null);
        tilemap.SetTile(new Vector3Int(2 * Width, 1, 0), null);
        tilemap.SetTile(new Vector3Int(Width, 2 * Height, 0), null);
        tilemap.SetTile(new Vector3Int(Width + 1, 2 * Height, 0), null);

    }

    private void ResetTileMap(Tilemap tilemap, Tile wall)
    {
        for (int x = 0; x < 2 * Width + 1; x++)
        {
            for (int y = 0; y < 2 * Height + 1; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y), wall);
            }
        }
    }

    private List<Cell> GetNeighbourCells(Cell cell, bool visited = false)
    {
        List<Cell> neighbours = new();

        foreach ((int i, int j) offset in NeighbourPattern)
        {
            int i = cell.X + offset.i;
            int j = cell.Y + offset.j;

            if (0 <= i && 0 <= j && i < Width && j < Height)
            {
                Cell neighbour = cells[i, j];
                if (neighbour.GetVisited() == visited)
                {
                    neighbours.Add(neighbour);
                }
            }
        }
        return neighbours;
    }

    private void RemoveWall(Cell cell, Cell rNeighbour)
    {
        if (rNeighbour.X == cell.X)
        {
            if (rNeighbour.Y < cell.Y)
            {
                rNeighbour.WU = false;
                cell.WD = false;
            }
            else
            {
                rNeighbour.WD = false;
                cell.WU = false;
            }
        }
        else if (rNeighbour.X < cell.X)
        {
            rNeighbour.WR = false;
            cell.WL = false;
        }
        else
        {
            rNeighbour.WL = false;
            cell.WR = false;
        }
    }
}