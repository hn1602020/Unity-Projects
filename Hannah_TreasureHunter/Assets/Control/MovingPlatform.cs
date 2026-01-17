using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public Transform start;
    public Transform end;
    public bool PlatControl;
    public float PlatSpeed;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("distance: "+ Vector2.Distance(start.position, end.position));


    }

    // Update is called once per frame
    void Update()
    {
        if (PlatControl == true)
        {
            //s to e
            platform.transform.position=Vector2.MoveTowards ( platform.transform.position, end.position, PlatSpeed * Time.deltaTime);
            if (Vector2.Distance(platform.transform.position,end.position) <= 0) PlatControl=false;

        }
        else
        {
            //e to s
            platform.transform.position=Vector2.MoveTowards ( platform.transform.position, start.position, PlatSpeed * Time.deltaTime);
            if (Vector2.Distance(platform.transform.position,start.position) <= 0) PlatControl=true;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(platform.transform);
        }
    
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    
    }
}
