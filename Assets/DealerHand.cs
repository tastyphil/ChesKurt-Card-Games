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
    public float initialX = -1f;
    public float initialY = 2f;
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
        Card temp = c.GetComponent<Card>();
        c.transform.position = Vector3.Lerp(c.transform.position, new Vector3(transform.position.x + (0.4f * myDeck.Count), initialY, -0.1f * myDeck.Count), 80);
        if (myDeck.Count != 1) {
            temp.FlipCard();
        }

        temp.SetParent(this);
        UpdateScore(temp.getScore());
        myDeck.Add(c);
        transform.position = Vector2.Lerp(transform.position, new Vector2(0 + (-0.181818f * myDeck.Count), initialY), 80);

    }

    public void DealersTurn() {
        if (!isDealerTurn) {
            isDealerTurn = true;
            Card secondCard = myDeck[1].GetComponent<Card>();
            secondCard.FlipCard();
            UpdateScore(0);
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

    public bool GetIsDealersTurn() {
        return isDealerTurn;
    }

    public int GetScore() {
        return score;
    }

    public void ResetHand() {
        foreach (GameObject c in myDeck) {
            Destroy(c);
        }

        isDealerTurn = false;
        myDeck.Clear();
        score = 0;
    }
}
