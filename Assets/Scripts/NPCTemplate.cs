using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTemplate : MonoBehaviour
{
    [SerializeField] SpriteRenderer _head;
    [SerializeField] SpriteRenderer _bodyTop;
    [SerializeField] SpriteRenderer _ass;
    [SerializeField] SpriteRenderer _leftHand;
    [SerializeField] SpriteRenderer _rightHand;
    [SerializeField] SpriteRenderer _leftLeg;
    [SerializeField] SpriteRenderer _rightLeg;

    public void SetSprites(Sprite head, Sprite bodyTop, Sprite ass, Sprite hand, Sprite leg) 
    {
        _head.sprite = head;
        _bodyTop.sprite = bodyTop;
        _ass.sprite = ass;
        _leftHand.sprite = hand;
        _rightHand.sprite = hand;
        _leftLeg.sprite = leg;
        _rightLeg.sprite = leg;
    }
}
