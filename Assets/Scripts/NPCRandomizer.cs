using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCRandomizer : MonoBehaviour
{
    [SerializeField] NPCTemplate ManTemplate;
    [SerializeField] NPCTemplate WomenTemplate;

    [SerializeField] private List<Transform> _npcPositions; 

    [SerializeField] List<Sprite> _legs;
    [SerializeField] List<Sprite> _manAsses;
    [SerializeField] List<Sprite> _manTopBodies;
    [SerializeField] List<Sprite> _blackManHands;
    [SerializeField] List<Sprite> _blackManHeads;
    [SerializeField] List<Sprite> _whiteManHands;
    [SerializeField] List<Sprite> _whiteManHeads;

    [SerializeField] List<Sprite> _womanAsses;
    [SerializeField] List<Sprite> _womanTopBodies;
    [SerializeField] List<Sprite> _blackWomanHands;
    [SerializeField] List<Sprite> _blackWomanHeads;
    [SerializeField] List<Sprite> _whiteWomanHands;
    [SerializeField] List<Sprite> _whiteWomanHeads;

    // Start is called before the first frame update
    void Start()
    {
        _legs = Resources.LoadAll<Sprite>("NPC/Legs/").ToList();

        _manAsses = Resources.LoadAll<Sprite>("NPC/Man/Ass/").ToList();
        _manTopBodies = Resources.LoadAll<Sprite>("NPC/Man/TopBody/").ToList();
        _blackManHands = Resources.LoadAll<Sprite>("NPC/Man/Black/Hands/").ToList();
        _blackManHeads = Resources.LoadAll<Sprite>("NPC/Man/Black/Head/").ToList();
        _whiteManHands = Resources.LoadAll<Sprite>("NPC/Man/White/Hands/").ToList();
        _whiteManHeads = Resources.LoadAll<Sprite>("NPC/Man/White/Head/").ToList();

        _womanAsses = Resources.LoadAll<Sprite>("NPC/Women/Ass/").ToList();
        _womanTopBodies = Resources.LoadAll<Sprite>("NPC/Women/TopBody/").ToList();
        _blackWomanHands = Resources.LoadAll<Sprite>("NPC/Women/Black/Hands/").ToList();
        _blackWomanHeads = Resources.LoadAll<Sprite>("NPC/Women/Black/Head/").ToList();
        _whiteWomanHands = Resources.LoadAll<Sprite>("NPC/Women/White/Hands/").ToList();
        _whiteWomanHeads = Resources.LoadAll<Sprite>("NPC/Women/White/Head/").ToList();

        for (int i = 0; i < _npcPositions.Count; i++)
        {
            Sprite leg = _legs[Random.Range(0, _legs.Count)];

            string assId = leg.name.Split('_').Last();

            int sex = Random.Range(0, 2);
            int skinColor = Random.Range(0, 2);

            Sprite ass;
            Sprite body;
            Sprite hand;
            Sprite head;

            if (sex == 1)
            {
                ass = _manAsses.First(a => a.name.Contains(assId));
                body = _manTopBodies[Random.Range(0, _manTopBodies.Count)];                
                hand = skinColor == 0 ? _whiteManHands[Random.Range(0, _whiteManHands.Count)] : _blackManHands[Random.Range(0, _blackManHands.Count)];
                head = skinColor == 0 ? _whiteManHeads[Random.Range(0, _whiteManHeads.Count)] : _blackManHeads[Random.Range(0, _blackManHeads.Count)];
                Instantiate(ManTemplate, _npcPositions[i]).SetSprites(head, body, ass, hand, leg);
            }
            else 
            {
                ass = _womanAsses.First(a => a.name.Contains(assId));
                body = _womanTopBodies[Random.Range(0, _womanTopBodies.Count-1)];
                
                hand = skinColor == 0 ? _whiteWomanHands[Random.Range(0, _whiteWomanHands.Count-1)] : _blackWomanHands[Random.Range(0, _blackWomanHands.Count-1)];
                head = skinColor == 0 ? _whiteWomanHeads[Random.Range(0, _whiteWomanHeads.Count)] : _blackWomanHeads[Random.Range(0, _blackWomanHeads.Count)];
                Instantiate(WomenTemplate, _npcPositions[i]).SetSprites(head, body, ass, hand, leg);
            }                        
        }
    }    
}
