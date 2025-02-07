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
    [ContextMenu("Spawn Card")]
    public void SpawnCard() {
        GameObject temp = Instantiate(cards, new Vector3(0, 0, 0), Quaternion.identity);
        var tempScript = temp.GetComponent<Card>();
        tempScript.InitCard(0);
    }
}
