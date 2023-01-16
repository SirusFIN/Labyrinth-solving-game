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
    private DataManager dataObject;
    private Maze maze;
    public AudioSource soundtrack;
    public GameObject Player1Text;
    public GameObject Player2Text;

    // Start is called before the first frame update
    void Start()
    {
        dataObject = GameObject.Find("DataManager").GetComponent<DataManager>();
        maze = new Maze(width, height);
        int seed = UnityEngine.Random.Range(0, 1000000);
        maze.Randomize(seed);
        maze.MazeToTilemap(walls, wall);
        UpdateScore();
    }

    public void ResetMaze()
    {
        SceneManager.LoadScene(1);
    }



    public void Player1Scores()
    {
        dataObject.GetComponent<DataManager>().Player1Score += 1;
        UpdateScore();
    }

    public void Player2Scores()
    {
        dataObject.GetComponent<DataManager>().Player2Score += 1;
        UpdateScore();
    }

    public void UpdateScore()
    {
        Player1Text.GetComponent<TextMeshProUGUI>().text = dataObject.Player1Score.ToString();
        Player2Text.GetComponent<TextMeshProUGUI>().text = dataObject.Player2Score.ToString();
    }

}
