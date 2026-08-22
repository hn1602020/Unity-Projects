using UnityEngine;

public class CarCtrl : MonoBehaviour
{
    public float speed;
    public float rotaspeed;
    public Rigidbody rbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbody.linearVelocity += this.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rbody.linearVelocity += this.transform.forward * -speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0,rotaspeed,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0,-rotaspeed,0);
        }
    }
}
