using System;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour {
    public Sprite[] spriteSheet;
    public int id;
    private int rank;
    private string suit;
    private bool isBackShowing = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void InitCard(int i) {
        this.id = i;
        this.rank = (id % 13 == 0) ? 13: id % 13;
        // rank = (id % 13 == 0 || id % 13  > 10) ? 10 : id % 13;
        double suitTemp = Convert.ToDouble(id) / 13;

        if (suitTemp >= 0 && suitTemp <= 1) {
            suit = "Clubs";
        } else if (suitTemp > 1 && suitTemp <= 2) {
            suit = "Diamond";
        } else if (suitTemp > 2 && suitTemp <= 3) {
            suit = "Hearts";
        } else if (suitTemp > 3 && suitTemp <= 4) {
            suit = "Spades";
        }

        // Debug.Log($"Card: {rank} of {suitTemp}");
        this.name = rank + " of " + suit;
        RenderSprite();
    }

    public void FlipCard() {
        if (isBackShowing) {
            isBackShowing = false;
        } else {
            isBackShowing = true;
        }

        RenderSprite();
    }

    public void PrintCard() {
        Debug.Log(rank + " of " + suit);
    }


    public void RenderSprite() {
        int temp = id;
        if (isBackShowing) temp = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteSheet[temp];
    }

    public void OnMouseDown() {
        Debug.Log(rank + " of " + suit + " got clicked!");
    }
}
