using UnityEngine;

public class MaceRotate : MonoBehaviour
{
    public float zangle;
    public bool Macecontrol;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zangle = this.transform.rotation.eulerAngles.z;

        if (Macecontrol==true)
        {
            this.transform.Rotate(0,0,speed * Time.deltaTime);
            if (zangle>250)
            {
                Macecontrol=false;
            }
        }
        else
        {
            this.transform.Rotate(0,0,-speed * Time.deltaTime);
            if (zangle<110)
            {
                Macecontrol=true;
            }
        }
    }
}
