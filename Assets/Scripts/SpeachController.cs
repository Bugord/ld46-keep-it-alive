using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SpeachController : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private Text _textContainer;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //Speak("Ai bliaaaaaaaaaaaa");
    }

    public void Speak(string text) 
    {
        _textContainer.text = "";
        StartCoroutine(SaySpeach(text.ToCharArray()));
    }

    private IEnumerator SaySpeach(char[] text) 
    {
        _canvas.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        foreach (char ch in text)
        {            
            while (_audioSource.isPlaying) 
            {
                yield return null;
            }
            if (char.IsLetter(ch))
            {
                _audioSource.Play();
                
                yield return new WaitForSeconds(0.05f);
            }
            else 
            {
                yield return new WaitForSeconds(0.2f);
            }
            _textContainer.text += ch;
        }

        yield return new WaitForSeconds(1f);
        _canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
