using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    RectTransform parent;
    GameManager gameManager;
    RectTransform rectTransform;
    Transform cameraTransform;

    void Start()
    {
        parent = transform.parent.gameObject.GetComponent<RectTransform>();
        gameManager = FindFirstObjectByType<GameManager>();
        rectTransform = GetComponent<RectTransform>();
        cameraTransform = FindFirstObjectByType<Camera>().transform;
    }

    void Update()
    {
        int currentZone = gameManager.GetCurrentZone(cameraTransform.position.y);
        float threshold = gameManager.GetThresholdForZone(currentZone);
        float fill = Mathf.Clamp01(gameManager.score / threshold);

        rectTransform.sizeDelta = new Vector2(parent.sizeDelta.x * fill, parent.sizeDelta.y);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rectTransform.rect.width);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rectTransform.rect.height);
    }
}