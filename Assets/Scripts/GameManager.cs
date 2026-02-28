using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<UpgradeCard> cards;
    public float moveSpeed = 10f;
    public float sharkSize = 40f;
    public float score = 0f;

    

    public void increaseSpeed(float by) {
        moveSpeed += by;
    }

    public void decreaseSpeed(float by) { moveSpeed -= by; }
    public void addScore(float by) { score += by; }

}
