using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlackJackMain : MonoBehaviour {

    public GameObject drawPile, playerHand, dealerHand;
    private DrawPile pile;
    private PlayerHand player;
    private DealerHand dealer;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        pile = drawPile.GetComponent<DrawPile>();
        player = playerHand.GetComponent<PlayerHand>();
        dealer = dealerHand.GetComponent<DealerHand>();
        pile.InitDrawPile();

        initBoard();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void initBoard() {
        for (int i = 1; i <= 2; i++) {
            player_drawCard();
            dealer.AddCard(pile.DrawCard());
        }
    }

    public void player_drawCard() {
        player.AddCard(pile.DrawCard());    
    }
}
