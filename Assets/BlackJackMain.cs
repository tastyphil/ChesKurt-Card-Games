using UnityEngine;

public class BlackJackMain : MonoBehaviour {

    public GameObject cards;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // instantiates a Card GameObject, uses its "Script" component to initialize the card
    [ContextMenu("Spawn Card")]
    public void SpawnCard() {
        GameObject temp = Instantiate(cards, new Vector2(0, 0), Quaternion.identity);
        var tempScript = temp.GetComponent<Card>();
        tempScript.InitCard(0);
    }
}
