using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public List<GameObject> myDeck;
    public GameObject cardTemp;
    public TMP_Text textDisplay;
    public float initialX = -1f;
    public float initialY = -2.75f;
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
        Card temp = c.GetComponent<Card>();
        c.transform.position = Vector3.Lerp(c.transform.position, new Vector3(transform.position.x + (0.4f * myDeck.Count), initialY, -0.1f * myDeck.Count), 80);
        
        //temp.PrintCard();
        temp.FlipCard();

        temp.SetParent(this);
        UpdateScore(temp.getScore());
        myDeck.Add(c);
        transform.position = Vector2.Lerp(transform.position, new Vector2(0 + (-0.181818f * myDeck.Count), initialY), 80);
    }

    public void ResetHand() {
        foreach (GameObject c in myDeck) {
            Destroy(c);
        }
        
        myDeck.Clear();
        score = 0;
    }

    public int GetScore() {
        return score;
    }

    public void UpdateScore(int x) {
        score += x;
        Debug.Log("This Card has a score of " + x);
        textDisplay.text = $"Player: {score}";
    }
}
