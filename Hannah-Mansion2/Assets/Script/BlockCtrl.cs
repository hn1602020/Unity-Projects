
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlockCtrl : MonoBehaviour
{
    public GameObject mainblk;
    public float yStart;
    public float yDelta;
    public int blockNumber;
    public GameObject blockPrefab;
    public GameObject HangingPrefab;
    public GameObject PerfectEffect;
    public int colorshift;

    public Color startColor;
    public Color nextColour;
    public Camerascript cs;

    public string colorFocus = "";
    public int colorChange = 0;
    public GameObject currentblk;
    public GameObject previousblk;
    public float a;
    public float b;
    public float l;
    public float s;
    public float d;
    public float p;

    private Rigidbody spblk;
    public Collider spwblk;

    public TMP_Text scoreui;
    public GameObject startButton;
    bool InGame;
    public AudioSource perfectsound;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Time.timeScale = 1;
       yStart = 0.6f;
       yDelta = 0.2f;
       blockNumber = 0;
       UpdateScore();
       InGame = false;

       // change mainblk to a random colour
       SetRandomColor( mainblk );
       DecideNext();
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        Debug.Log("Start!");
        InGame = true;
    }

    public void SetRandomColor( GameObject blkgo )
    {
        startColor = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1.0f);
        blkgo.GetComponent<MeshRenderer>().material.color = startColor;
        nextColour = startColor;
    }

    public void ChangeToNextColour( GameObject blkgo )
    {
        
        if (colorFocus == "R")
        {
            Color c = nextColour;
            c.r += 0.1f * colorshift;
            nextColour = c;

            blkgo.GetComponent<MeshRenderer>().material.color = nextColour;

            if (nextColour.r < 0.2 || nextColour.r > 0.8) DecideNext();
        }
        else if (colorFocus == "B")
        {
             Color c = nextColour;
            c.b += 0.1f * colorshift;
            nextColour = c;

            blkgo.GetComponent<MeshRenderer>().material.color = nextColour;
            if (nextColour.b < 0.2 || nextColour.b > 0.8) DecideNext();
        }
        else if (colorFocus == "G")
        {
            
             Color c = nextColour;
            c.g += 0.1f * colorshift;
            nextColour = c;

            blkgo.GetComponent<MeshRenderer>().material.color = nextColour;
            if (nextColour.g < 0.2 || nextColour.g > 0.8) DecideNext();
        }

    }

    public void DecideNext()
    {
        int dice = Random.Range(1,4);
        
        if(dice == 1)
        {
            colorFocus = "R";
            if (nextColour.r > 0.5f) colorshift = -1;
            else colorshift = +1;
            
        }
        if(dice == 2)
        {
            colorFocus = "G";
            if (nextColour.r > 0.5f) colorshift = -1;
            else colorshift = +1;
        }
        if(dice == 3)
        {
            colorFocus = "B";
            if (nextColour.r > 0.5f) colorshift = -1;
            else colorshift = +1;
        }
    }

    public void IncreaseBlkNum()
    {
        blockNumber ++;
        UpdateScore();
    }

    public void UpdateScore()
    {
        int score = blockNumber - 1;
        scoreui.text = "" + score;

        if ( score < 0) scoreui.text = "" + 0;
    }

    public void SpawnNewBlock()
    {
        Vector3 ypos = new Vector3(0, yStart + yDelta * blockNumber, 0);
        if (currentblk != null) previousblk = currentblk;
        GameObject newblk = Instantiate(blockPrefab, new Vector3(ypos.x, ypos.y, ypos.z - 3f), blockPrefab.transform.rotation);
        currentblk = newblk;
        currentblk.transform.localScale = new Vector3 (previousblk.transform.localScale.x, 0.2f, previousblk.transform.localScale.z);
        ChangeToNextColour(newblk);
    }
    public void SpawnHangingBlock()
    {
        if (blockNumber > 0)
        {
            float zpos = 0;
            if (previousblk.transform.position.z < currentblk.transform.position.z ) zpos = previousblk.transform.position.z + l/2 + d/2;
            else zpos = previousblk.transform.position.z - l/2 - d/2;
            
            Vector3 spawnpos = new Vector3( previousblk.transform.position.x, yStart + yDelta * (blockNumber-1), zpos );

            GameObject hanging = Instantiate(HangingPrefab, spawnpos, HangingPrefab.transform.rotation);
            hanging.transform.localScale = new Vector3(hanging.transform.localScale.x, 0.2f, d );  
            spblk = this.GetComponent<Rigidbody>();
            hanging.GetComponent<MeshRenderer>().material.color=currentblk.GetComponent<MeshRenderer>().material.color;
            spwblk = this.GetComponent<Collider>();
            Destroy(hanging,1.0f);

            //change colour of hanging
        }
       
    }

    public void StopCurrent()
    {
        if (currentblk != null) 
        {
            BlockMotion bm = currentblk.GetComponent<BlockMotion>();
            if (bm != null) bm.moving = false;
        }
    }
    
    public void CutOffCurentBlock()
    {
        if (currentblk != null && previousblk != null && blockNumber > 0)
        {
            currentblk.transform.localScale = new Vector3(currentblk.transform.localScale.x, 0.2f,s);
        
            if (previousblk.transform.position.z < currentblk.transform.position.z)
            {
                currentblk.transform.position = new Vector3(currentblk.transform.position.x, currentblk.transform.position.y, previousblk.transform.position.z + d/2);
            }
            else 
            {
                currentblk.transform.position = new Vector3(currentblk.transform.position.x, currentblk.transform.position.y, previousblk.transform.position.z - d/2);
            }    
        }
    }

    public void Calculation()
    {
        if (previousblk != null && currentblk != null)
        {
            a = previousblk.transform.position.z;
            b = currentblk.transform.position.z;
    

            l = previousblk.transform.localScale.z;
            d = Mathf.Abs(b-a);
            s = l-d;
            if (s <= 0) s = 0;
            p = b - ( 0.5f * d ); 
        }
 

    }
    public void Perfect()
    {
        if (currentblk != null && previousblk != null && blockNumber > 0)
        {
            currentblk.transform.position = new Vector3( previousblk.transform.position.x, currentblk.transform.position.y, previousblk.transform.position.z);
            GameObject pe = Instantiate(PerfectEffect, currentblk.transform.position - Vector3.up*0.1f, PerfectEffect.transform.rotation);
            perfectsound.Play();
            IncreasePitch();
        }
    }


    public void OnLose()
    {
        if (s <= 0.01f && blockNumber > 0) 
        {
            Time.timeScale = 0;
            Debug.Log("lose");
        }
    }

    public void IncreasePitch()
    {
        perfectsound.pitch += 0.2f;
    }
    public void ResetPitch()
    {
        perfectsound.pitch = 1.0f;
    }


    // Update is called once per frame
    void Update()
    {
        Calculation();
        if (Input.GetMouseButtonDown(0))
        {
            if (InGame == true)
            {
                Calculation();
                StopCurrent();
                if(d < 0.2f)
                {
                    Perfect();
                }
                else
                {
                    CutOffCurentBlock();
                    SpawnHangingBlock();
                    ResetPitch();

                }
                
                
                OnLose();
                SpawnNewBlock();
                IncreaseBlkNum();
                cs.UpdatePos();
            }
        
        }
    }
}



