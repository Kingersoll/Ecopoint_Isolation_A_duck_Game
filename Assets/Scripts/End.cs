using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class End : MonoBehaviour
{
    public GameObject player;

    public Image gun;
    public Image clip;
    public Image ammo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.color.r == 1&& clip.color.r == 1&& ammo.color.r == 1)
        {
            player.winGame();
        }


    }
}
