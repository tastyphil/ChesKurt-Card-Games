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
        

        InitBoard();
    }

    // Update is called once per frame
    void Update() {
        
    }

    [ContextMenu("Initialize Board")]
    void InitBoard() {
        pile.InitDrawPile();
        player.ResetHand();
        dealer.ResetHand();

        for (int i = 1; i <= 2; i++) {
            player_hit();
            dealer.AddCard(pile.DrawCard());
        }
    }

    // Player draws a card
    public void player_hit() {
        if (!dealer.GetIsDealersTurn()) player.AddCard(pile.DrawCard());    
    }

    public void player_stand() {
        dealer.DealersTurn();

        while (dealer.GetScore() < 17) {
            dealer.AddCard(pile.DrawCard());
        }
    }
}
