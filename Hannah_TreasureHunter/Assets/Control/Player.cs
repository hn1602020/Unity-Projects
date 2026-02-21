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
    public int speed;
    public int JumpF=1; 
    public AudioSource sfxHit;
    public AudioSource sfxJump;
    public AudioSource sfxBGM;
    public AudioSource sfxChest;
    public string LeftControlKey;
    public string RightControlKey;
    public string SpaceControlKey;
    public string cointag;

    void Awake()
    {
        maxCoins = 0;
    }


    public void TrackCoins()
    {
        GameObject[] coinArray = GameObject.FindGameObjectsWithTag(cointag);
        maxCoins += coinArray.Length;
        Debug.Log("Total coins: "+maxCoins);
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
        
        TrackCoins();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsRunning",false);
        RB2D.linearVelocity = new Vector2(0, RB2D.linearVelocity.y);
        Move();
        Jump();
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void Move()
    {
        if (Input.GetKey(LeftControlKey))
        {
            Debug.Log("Move Left");
            RB2D.linearVelocity = new Vector2(-speed, RB2D.linearVelocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("IsRunning",true);

        }

        if (Input.GetKey(RightControlKey))
        {
            Debug.Log("Move Right");
            RB2D.linearVelocity = new Vector2(speed, RB2D.linearVelocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("IsRunning",true);

        }
    }

    public void Jump()
    {
        if (grounded == true)
        {
            if (Input.GetKeyDown(SpaceControlKey))
            {
                Debug.Log("Jump");
                RB2D.gravityScale = 1;
                RB2D.linearVelocity += new Vector2(0, JumpF);
                grounded = false;
                anim.SetBool("IsJumping",true);
                sfxJump.Play();
            
            }
           
        }
    }
     
    IEnumerator Lose()
    {
        sfxHit.Play();
        yield return new WaitForSeconds(0.19f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

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
            StartCoroutine(Lose());
        }

        

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == cointag)
        {
            IncreaseCoins();
            Debug.Log("collected: "+counter+" vs Total: "+maxCoins);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Chest")
        {
            ChestAnim = chestObj.GetComponent<Animator>(); 
            ChestAnim.Play("ChestOpen");
            sfxBGM.Stop();
            sfxChest.Play();
            StartCoroutine(Win());
           
        }

    }

   IEnumerator Win()
   {
        sfxChest.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelName);
   }
   
   
   
   
   
   public void QuitGame()
    {   
#if UNITY_EDITOR  
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    


}


