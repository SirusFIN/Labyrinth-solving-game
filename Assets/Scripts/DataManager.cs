using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instanse;
    public int Player1Score { get; set; }
    public int Player2Score { get; set; }


    private void Awake()
    {
        if (Instanse != null && Instanse != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instanse = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
