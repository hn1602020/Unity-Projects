using UnityEngine;

public class BlockMotion : MonoBehaviour
{
    public bool motion;
    public Vector3 start;
    public Vector3 end;
    public float PlatSpeed;
    public bool moving = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = this.transform.position;
        end = start + Vector3.forward * 6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
             if (motion == true)
            {
                //s to e
                this.transform.position=Vector3.MoveTowards (this.transform.position, end, PlatSpeed * Time.deltaTime);
                if (Vector3.Distance(this.transform.position,end) <= 0) motion = false;

            }
            else
            {
                //e to s
                this.transform.position=Vector3.MoveTowards (this.transform.position, start, PlatSpeed * Time.deltaTime);
                if (Vector3.Distance(this.transform.position,start) <= 0) motion = true;
            }
        }
    }
}
