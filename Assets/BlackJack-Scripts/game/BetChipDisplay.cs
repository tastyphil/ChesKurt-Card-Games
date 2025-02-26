using System;
using UnityEngine;

public class BetChipDisplay : MonoBehaviour
{
    public Sprite[] chips;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitChip(string s) {
        string[] type = {"Small Bet", "Large Bet", "Larger Bet", "All-In Bet", "Crazy Bet"};
        gameObject.GetComponent<SpriteRenderer>().sprite = chips[Array.IndexOf(type, s)];
    }
}
