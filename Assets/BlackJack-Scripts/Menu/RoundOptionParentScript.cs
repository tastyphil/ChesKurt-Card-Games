using TMPro;
using UnityEngine;

public class RoundOptionParent : MonoBehaviour
{
    public GameObject roundOptionTemp, canvasParent;
    private int buttonPadding = -100;
    public int optionCount;
    public float canvasX, initialX = 430f;
    public float canvasY, initialY = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOption(GameObject b, int x) {     
        b.transform.position = Vector2.Lerp(b.transform.position, new Vector2(canvasX + initialX, canvasY + initialY + (optionCount * buttonPadding)), 80);
        transform.position = Vector2.Lerp(transform.position, new Vector2(canvasX + initialX, 100 * optionCount), 80);

        RoundOptionScript script = b.GetComponent<RoundOptionScript>();
        b.transform.SetParent(this.transform);
        script.InitButton(x);
        optionCount++;
    }
}
