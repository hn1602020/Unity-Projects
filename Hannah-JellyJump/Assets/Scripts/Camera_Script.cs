using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Script : MonoBehaviour

{
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
         if (player.transform.position.y > this.transform.position.y)
        {
            //do
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);

        }
    }
}

