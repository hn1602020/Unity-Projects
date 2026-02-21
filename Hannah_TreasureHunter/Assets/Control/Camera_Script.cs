using UnityEngine;

public class Camera_Script : MonoBehaviour

{
    public GameObject player;
    public GameObject player2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        if (player2 == null) player2 = GameObject.FindGameObjectWithTag("Player2");



    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player2 != null)
        {
            if (player.transform.position.x > player2.transform.position.x)
            {
               this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(player2.transform.position.x, this.transform.position.y, this.transform.position.z);
            }
        }
        else
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        
    

    }
}
