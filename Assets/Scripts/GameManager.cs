using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UpgradeCard card;
    public float moveSpeed = 10;

    

    public void increaseSpeed(float by) {
        moveSpeed += by;
    }
}
