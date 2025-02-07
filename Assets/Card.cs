using UnityEngine;

public class Card : MonoBehaviour {
    public Sprite[] spriteSheet;
    private int rank;
    private string suit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteSheet[0];
    }

    // Update is called once per frame
    void Update() {
        
    }
}
