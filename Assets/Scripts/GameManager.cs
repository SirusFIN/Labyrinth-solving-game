using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private Tile wall;
    [SerializeField] private Tilemap walls;
    private GameObject dataObject;
    private Maze maze;

    // Start is called before the first frame update
    void Start()
    {
        dataObject = GameObject.Find("DataManager");
        maze = new Maze(width, height);
        int seed = UnityEngine.Random.Range(0, 1000000);
        maze.Randomize(seed);
        maze.MazeToTilemap(walls, wall);
    }

    public void ResetMaze()
    {
        SceneManager.LoadScene(0);
    }

    public GameObject Player1Text;
    public GameObject Player2Text;

    private float Player1Score;
    private float Player2Score;

    public void Player1Scores()
    {
        Player1Score += 1;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        dataObject.GetComponent<DataManager>().Player1Score += 1;
    }

    public void Player2Scores()
    {
        Player2Score += 1;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        dataObject.GetComponent<DataManager>().Player2Score += 1;
    }

}
