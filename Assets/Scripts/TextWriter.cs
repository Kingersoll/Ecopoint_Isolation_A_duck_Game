using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    private bool invisibleCharacters;
    private float timeSinceStart;
    private bool run;

    private AudioSource audioSource;

    public AudioClip beep;
    public AudioClip deepBeep;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = beep;

    }

    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;

    }

    private void Update()
    {
        timeSinceStart += Time.deltaTime;

        if(timeSinceStart>= 2)
        {
            run = true;
        }

        if (run)
        {
            if (uiText != null)
            {
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    timer += timePerCharacter;
                    characterIndex++;
                    string text = textToWrite.Substring(0, characterIndex);

                    

                    if ( characterIndex==9)
                    {
                        audioSource.clip = deepBeep;
                        audioSource.Play();

                    }
                    else
                    {
                        audioSource.clip = beep;
                        audioSource.Play();
                    }


                    if (invisibleCharacters)
                    {
                        text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";

                    }
                    uiText.text = textToWrite.Substring(0, characterIndex);

                    if (characterIndex >= textToWrite.Length)
                    {
                        uiText = null;
                        return;
                    }
                }
            }
        }
      
    }
}
