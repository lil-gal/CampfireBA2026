using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<UpgradeCard> cards;
    public float moveSpeed = 10f;
    public float sharkSize = 40f;
    public float score = 0f;

    [Header("Zone Points Requirements")]
    public float[] ZonePointThresholds = new float[] { 100f, 250f, 500f, 1000f };
    public float ZoneSize = 40f;

    [HideInInspector] public int deepestZoneReached = 0;

    public int GetCurrentZone(float cameraY) {
        return Mathf.FloorToInt(Mathf.Abs(cameraY) / ZoneSize);
    }

    public float GetThresholdForZone(int zone) {
        if (zone >= ZonePointThresholds.Length) return ZonePointThresholds[ZonePointThresholds.Length - 1];
        return ZonePointThresholds[zone];
    }

    public void changeSpeedBy(float by) { moveSpeed += by; if (moveSpeed < 1) { moveSpeed = 1; } }
    public void changeScoreBy(float by) { score += by; }
    public void changeSharkSizeBy(float by) { sharkSize += by; }

    public void changeCollectorBy(float by) {
        GameObject.FindWithTag("PlayerCollector").GetComponent<CircleCollider2D>().radius += by;
    }
}