using Unity.VisualScripting;
using UnityEngine;

public class PlatformDetection : MonoBehaviour
{
    public GameObject player;
    public BoxCollider2D bxcd2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        if (bxcd2d == null) this.GetComponent<BoxCollider2D>();
        bxcd2d.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y - this.transform.position.y >= 0.75f)
        {
            //do
            bxcd2d.enabled = true;

        }

        if (player.transform.position.y - this.transform.position.y <= -0.75f )
        {
            bxcd2d.enabled = false;
        }
    }
}
