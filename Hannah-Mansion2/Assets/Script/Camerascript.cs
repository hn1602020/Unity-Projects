using UnityEngine;

public class Camerascript : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 nextPos;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = this.transform.position;
        nextPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
        this.transform.Rotate(Vector3.up * speed *Time.deltaTime);
        
    }

    public void UpdatePos()
    {
        nextPos = nextPos + Vector3.up * 0.2f;
        // to use when new block appears
        // so we know where to move to
    }

    public void MoveCam()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,nextPos,Time.deltaTime * 0.5f);
        // after updatepos()
        // constantly move to updated pos
    }
}

