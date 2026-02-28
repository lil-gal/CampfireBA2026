using TMPro;
using UnityEngine;

public class ZoneDisplay : MonoBehaviour
{
    private GameManager gameManager;
    private TextMeshProUGUI text;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = $"{gameManager.deepestZoneReached + 1}";
    }
}