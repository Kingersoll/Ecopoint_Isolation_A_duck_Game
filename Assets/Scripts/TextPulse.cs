using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPulse : MonoBehaviour
{
    public float upperGrowth;
    public float lowerGrowth;

    public float GrowthRate;

    private Transform startPos;
    public float startY;

    public void Start()
    {
        
        startY = transform.position.y;
    }


    private void Update()
    {
        
        if(transform.position.y < (startY += upperGrowth))
        {
            transform.position += new Vector3(transform.position.x, transform.position.y+GrowthRate);
        }

        if (transform.position.y > (startY += lowerGrowth))
        {
            transform.position += new Vector3(transform.position.x, transform.position.y - GrowthRate);
        }
        

    }
    

}
