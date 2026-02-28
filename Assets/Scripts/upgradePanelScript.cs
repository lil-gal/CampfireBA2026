using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeCard;

public class upgradePanelScript : MonoBehaviour {

    public GameObject cardPrefab;
    public int cardSlots = 3;

    private GameManager gameManager;

    private void Awake() {
        gameManager = FindAnyObjectByType<GameManager>();
        DeactivateSelf();
    }

    public void LevelUp() {
        for (int i = 0; i < cardSlots; i++) {
            GameObject card = Instantiate(cardPrefab, transform);
            card.GetComponent<UpgradeCardScript>().card = getRandomCard();
        }

        ActivateSelf();
    }

    public void AfterPick() {
        DestroyChildren();
        DeactivateSelf();
    }

    void DeactivateSelf() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    void ActivateSelf() {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    void DestroyChildren() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

    UpgradeCard getRandomCard(int tries = 0) {
        int num = Random.Range(0, 100 + 1);
        Rarities rarity = Rarities.Common;

        // get random rarity
        if (num < (int)Rarities.Legendary) {
            rarity = Rarities.Legendary;
        } else if (num < (int)Rarities.Rare) {
            rarity = Rarities.Rare;
        }

        // make all rarities into 1 group
        List<UpgradeCard> rarityCards = new List<UpgradeCard>();
        foreach (UpgradeCard card in gameManager.cards) {
            if (card.rarity == rarity) {
                rarityCards.Add(card);
            }
        }

        // pick random card from rarity collection
        num = Random.Range(0, rarityCards.Count);
        return rarityCards[num];
    }
}