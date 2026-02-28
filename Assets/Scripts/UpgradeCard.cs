using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[Serializable]
public class UpgradeCard
{
    [Serializable]
    public enum Rarities {
        Common = 70,
        Rare = 25,
        Legendary = 5
    } //chances?

    //each card has

    public Rarities rarity;
    public string name;
    public string description;

    public UnityEvent<float> method;
    public float incrementBy;
    public Sprite icon;

    public void Take() {
        if (method != null) {
            method.Invoke(incrementBy);
        }
    }

}
