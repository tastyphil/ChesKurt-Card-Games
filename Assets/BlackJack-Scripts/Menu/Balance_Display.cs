using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Balance_Display : MonoBehaviour
{
    public void UpdateBalance() {
        TMP_Text text =GetComponent<TMP_Text>();
        text.text = GameParameters.balance + " CHIPS";
    }
}
