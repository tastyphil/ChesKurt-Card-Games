using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
    public List<GameObject> myDeck;
    public PlayerHand playerHand;
    public GameObject cardTemp;
    public Vector2 initialPos = new Vector2(0,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Pops top card from myDeck and returns it 
    public GameObject DrawCard() {
        GameObject drawnCard = myDeck[myDeck.Count-1];
        myDeck.RemoveAt(myDeck.Count-1);
        return drawnCard;
    }

    // Initializes a drawPile with 52*x cards
    [ContextMenu("InitCards")]
    public void InitDrawPile() {
        foreach (GameObject g in myDeck) {
            Destroy(g);
        }
        myDeck.Clear();

        // creates a sorted deck in temp
        for (int i = 0; i < 1; i++) {
            for (int j = 1; j <= 52; j++) {
                GameObject newCard = Instantiate(cardTemp, initialPos, Quaternion.identity);
                var newCardScript = newCard.GetComponent<Card>();
                newCardScript.InitCard(j);
                myDeck.Add(newCard);
            }
        }

        myDeck = myDeck.OrderBy(i => Guid.NewGuid()).ToList();
    }

}
