using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UpgradeCard card;
    public float speed = 10;

    public void increaseSpeed(float by) {
        speed += by;
    }
}
