using System.Collections.Generic;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
    public List<Card> myDeck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card DrawCard() {
        Card temp = myDeck[myDeck.Count];
        myDeck.RemoveAt(myDeck.Count);
        return temp;
    }
    public void AddCard(Card c) {
        myDeck.Add(c);
    }
}
