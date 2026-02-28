using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<UpgradeCard> cards;
    public float moveSpeed = 10f;
    public float sharkSize = 40f;

    

    public void increaseSpeed(float by) {
        moveSpeed += by;
    }
}
