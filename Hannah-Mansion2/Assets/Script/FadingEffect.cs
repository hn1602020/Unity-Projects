using UnityEngine;

public class FadingEffect : MonoBehaviour

{   public Material fadeMat;
    float duration = 0.5f;
    public float maxScale;
    float timer;
    float t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeMat = this.GetComponent<MeshRenderer>().material;
        //colorFocus = "A";
        //ogscale = transform.localScale;
        transform.localScale = Vector3.zero; // set to size zero
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        t = timer/duration;
        AlphaColour();
        ScaleChange();
        
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    


    }
    void AlphaColour()
    {
        Color c = fadeMat.color;
        c.a = Mathf.Lerp(1f, 0f, t);
        fadeMat.color = c;
    }
    void ScaleChange()
    {   
        transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one * maxScale,t);
    }
}
