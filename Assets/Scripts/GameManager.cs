using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<UpgradeCard> cards;
    public float moveSpeed = 10f;
    public float sharkSize = 40f;
    public float score = 0f;



    public void changeSpeedBy(float by) { moveSpeed += by; }

    public void changeScoreBy(float by) { score += by; }
    public void changeSharkSizeBy(float by) { sharkSize += by; }

    public void changeCollectorBy(float by) {
        GameObject.FindWithTag("PlayerCollector").GetComponent<CapsuleCollider2D>().size += new Vector2(by,by);
    }

}
