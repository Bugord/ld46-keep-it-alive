using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCTemplate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _head;
    [SerializeField] private SpriteRenderer _bodyTop;
    [SerializeField] private SpriteRenderer _ass;
    [SerializeField] private SpriteRenderer _leftHand;
    [SerializeField] private SpriteRenderer _rightHand;
    [SerializeField] private SpriteRenderer _leftLeg;
    [SerializeField] private SpriteRenderer _rightLeg;

    [SerializeField] private Animator _animator;

    private bool _isMan;

    private bool _canSpeak;

    [SerializeField] private float _handsUpTime = 10;
    [SerializeField] private float _time;

    [SerializeField] private SpeachController _speachController;

    private List<string> _messages;

    private void Start()
    {
        _handsUpTime = Random.Range(5, 15);
        _messages = new List<string> 
        { 
            "Boooo!",
            "Wow!",
            "Whoa!",
            "Eww!",
            "So fresh!",
            "My goodness!",
            "What am I doing here?",
            "Praise the sun!"
        };
    }

    private void Update()
    {
        if (_time > _handsUpTime) 
        {
            _time = 0;
            _handsUpTime = Random.Range(5, 15);

            if (_isMan)
            {
                _animator.Play("manHandsUp");
            }
            else 
            {
                _animator.Play("womanHandsUp");
            }
            if (_canSpeak) 
            {
                _speachController.Speak(_messages[new System.Random().Next(0, _messages.Count)], false);
            }
        }
        _time += Time.deltaTime;
    }

    public void SetSprites(string name, Sprite head, Sprite bodyTop, Sprite ass, Sprite hand, Sprite leg) 
    {
        _head.sprite = head;
        _bodyTop.sprite = bodyTop;
        _ass.sprite = ass;
        _leftHand.sprite = hand;
        _rightHand.sprite = hand;
        _leftLeg.sprite = leg;
        _rightLeg.sprite = leg;
        _isMan = name == "npcIdle";        
        _canSpeak = Convert.ToBoolean(Random.Range(0, 2));
        StartCoroutine(PlayIdle(name));
    }

    private IEnumerator PlayIdle(string name) 
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        _animator.Play(name);
    }
}
