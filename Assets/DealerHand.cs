using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
public class DealerHand : MonoBehaviour
{
    public List<GameObject> myDeck;
    public GameObject cardTemp;
    public TMP_Text textDisplay;
    public Vector2 initialPos = new Vector2(-8.25f,2f);
    public int score = 0;
    public bool isDealerTurn = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    public void AddCard(GameObject c) {
        c.transform.position = Vector2.Lerp(c.transform.position, new Vector2(-8.25f + (1.25f * myDeck.Count), 2f), 80);
        Card temp = c.GetComponent<Card>();
        if (myDeck.Count != 1) {
            temp.FlipCard();
        }

        UpdateScore(temp.getScore());
        myDeck.Add(c);
    }

    public void DealersTurn() {
        if (!isDealerTurn) {
            isDealerTurn = true;
            // foreach (GameObject)
        }
    }

    public void UpdateScore(int x) {
        score += x;
        Debug.Log("This Card has a score of " + x);
        if (!isDealerTurn) {
            textDisplay.text = "Dealer: ?";
        } else {
            textDisplay.text = $"Dealer: {score}";
        }
    }
}
