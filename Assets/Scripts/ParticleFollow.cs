using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    [SerializeField] Transform toFollow;
    // Start is called before the first frame update
  
    void Update()
    {
        transform.position = toFollow.transform.position;
    }
}
