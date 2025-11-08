using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D RB2D;

    public GameObject Platform;
    private Vector3 pos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start Game");
        RB2D = this.GetComponent<Rigidbody2D>();
        RB2D.gravityScale = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("In Game");

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Move Left");
            RB2D.linearVelocity = new Vector2(-5,RB2D.linearVelocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Move Right");
            RB2D.linearVelocity = new Vector2(5,RB2D.linearVelocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Start Falling");
            RB2D.gravityScale = 1;
            // downward velocity here
            RB2D.linearVelocity += new Vector2(0,-20);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {   
            int h = 5;
            for (int x = -0; x < 68; x++)
            {
                int y = h + 2 * x;
                pos = new Vector3( Random.Range(-6,6)  , y, 0);

                Instantiate(Platform, pos, Quaternion.identity);
            }
        }
        
    }
    
}

