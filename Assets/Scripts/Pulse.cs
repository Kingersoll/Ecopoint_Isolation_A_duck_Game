using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    // Start is called before the first frame update
    public float approachSpeed ;
    public float growthBound;
    public float shrinkBound;
    private float currentRatio = 4;

    private Coroutine routine;
    private bool keepGoing = true;
    private bool closeEnough = false;

    public void Start()
    {
        StartCoroutine("Pulses");
    }

    IEnumerator Pulses()
    {
        print("start pulse");
        // Run this indefinitely
        while (keepGoing)
        {
            // Get bigger for a few seconds
            while (this.currentRatio != this.growthBound)
            {
                print("gB");
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                // Update our text element
                this.transform.localScale = Vector3.one * currentRatio;


                yield return new WaitForEndOfFrame();
            }

            // Shrink for a few seconds
            while (this.currentRatio != this.shrinkBound)
            {
                print("SB");
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                // Update our text element
                this.transform.localScale = Vector3.one * currentRatio;


                yield return new WaitForEndOfFrame();
            }
        }
    }
}
