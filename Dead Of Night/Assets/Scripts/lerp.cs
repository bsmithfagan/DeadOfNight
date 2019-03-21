using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp : MonoBehaviour
{
    float t;
    // Start is called before the first frame update
    void Start()
    {
        t = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 0) return;
        t += .01f;
        GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(255, 0, 0, .5f), new Color(0, 0, 0, 1), t);
    }
    public void begin()
    {
        t = 0;
    }
}
