using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public List<GameObject> myDeck;
    public GameObject cardTemp;
    public TMP_Text textDisplay;
    public Vector2 initialPos = new Vector2(-8.25f,-3.25f);
    public int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(GameObject c) {
        c.transform.position = Vector2.Lerp(c.transform.position, new Vector2(-8.25f + (1.25f * myDeck.Count), -3.25f), 80);
        var temp = c.GetComponent<Card>();
        //temp.PrintCard();
        temp.FlipCard();

        UpdateScore(temp.getScore());
        myDeck.Add(c);
    }

    public void ResetHand() {
        foreach (GameObject c in myDeck) {
            Destroy(c);
        }
        
        myDeck.Clear();
        score = 0;
    }

    public void UpdateScore(int x) {
        score += x;
        Debug.Log("This Card has a score of " + x);
        textDisplay.text = $"Player: {score}";
    }
}
