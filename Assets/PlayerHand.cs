using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public List<GameObject> myDeck;
    public GameObject cardTemp;
    public Vector2 initialPos = new Vector2(-8.25f,-3.25f);
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
        temp.FlipCard();
        myDeck.Add(c);
    }
}
