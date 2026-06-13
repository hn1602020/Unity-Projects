using UnityEngine;

public class FadingEffect : MonoBehaviour

{   public Material effect;
    float duration = 1f;
    Vector3 ogscale;
    float timer;
    float t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effect = GameObject.Find("Effect").GetComponent<MeshRenderer>().material;
        //colorFocus = "A";
        ogscale = transform.localScale;
        transform.localScale = Vector3.zero;
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        t= timer/duration;
        AlphaColour();
        ScaleChange();
        
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    


    }
    void AlphaColour()
    {
        Color c = effect.color;
        c.a = Mathf.Lerp(1f, 0f, t);
        effect.color = c;
    }
    void ScaleChange()
    {   
        transform.localScale = Vector3.Lerp(Vector3.zero,ogscale,t);
    }
}
