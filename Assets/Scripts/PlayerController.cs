using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool IsPlayer1;

    public float xRangeL = -3;
    public float xRangeR = 44;
    public float yRangeT = 41;
    public float yRangeB = -3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        LimitUser();
    }

    private void UpdateMovement()
    {
        rb.velocity = GetUserInput() * speed;
    }

    private Vector2 GetUserInput() 
    {
        if (IsPlayer1) { return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); }
        else { return new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2")); }
    }

    private void LimitUser() 
    {
        if (transform.position.x < xRangeL)
        {
            transform.position = new Vector2(xRangeL, transform.position.y);
        }
        if (transform.position.x > xRangeR) 
        {
            transform.position = new Vector3(xRangeR, transform.position.y);
        }
        if (transform.position.y < yRangeB)
        {
            transform.position = new Vector2(transform.position.x, yRangeB);
        }
        if (transform.position.y > yRangeT)
        {
            transform.position = new Vector3(transform.position.x, yRangeT);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            if(!IsPlayer1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scores();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scores();
            }
        }
    }
}

