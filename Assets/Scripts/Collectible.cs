using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update

    public Text interactText;
    public Image associatedImage;

    private bool interactable;
    // Update is called once per frame

    private void Update()
    {
        if(interactable && Input.GetKeyDown(KeyCode.F))
        {
            //trigger something for the win condition
            associatedImage.color = new Color(1, 1, 1);

            GameObject.Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactText.enabled = true;
            interactable = true;
            //turns the UI element from an outline to a fully colored Image
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactText.enabled = false;
            interactable = false;
        }
    }
}
