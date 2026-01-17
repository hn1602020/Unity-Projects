using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D RB2D;
    public bool grounded;
    public Animator anim;
    public GameObject chestObj;
    public Animator ChestAnim;
    public static int counter;
    public static int maxCoins;
    public string levelName;
    public int JumpF=1; 

    public void TrackCoins()
    {
        GameObject[] coinArray = GameObject.FindGameObjectsWithTag("Coin");
        maxCoins = coinArray.Length;
    }
    public void IncreaseCoins()
    {
        //inc coins by 1
        counter ++;

         if (counter == maxCoins)
        {
            chestObj.SetActive(true);
            //set chest active to true3
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = 0;
        anim = this.GetComponent<Animator>();
        RB2D.linearVelocity = new Vector2( Input.GetAxis("Horizontal") * 5, RB2D.linearVelocity.y);
        TrackCoins();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsRunning",false);
        RB2D.linearVelocity = new Vector2(0, RB2D.linearVelocity.y);
        Move();
        Jump();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Move Left");
            RB2D.linearVelocity = new Vector2(-5, RB2D.linearVelocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("IsRunning",true);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Move Right");
            RB2D.linearVelocity = new Vector2(5, RB2D.linearVelocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("IsRunning",true);

        }
    }

    public void Jump()
    {
        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jump");
                RB2D.gravityScale = 1;
                RB2D.linearVelocity += new Vector2(0, JumpF);
                grounded = false;
                anim.SetBool("IsJumping",true);
            
            }
           
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetBool("IsJumping",false);
            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            IncreaseCoins();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Chest")
        {
            ChestAnim = chestObj.GetComponent<Animator>(); 
            ChestAnim.Play("ChestOpen");
            StartCoroutine(Win());
           
        }

    }

   IEnumerator Win()
   {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelName);

   }
}


