using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject toFollow;

   private void LateUpdate()
    {
        transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, -8);
    }

}
