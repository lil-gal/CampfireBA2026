using UnityEngine;

public class ProgressBar : MonoBehaviour {

    RectTransform parent;
    GameManager gameManager;
    RectTransform rectTransform;
    Transform cameraTransform;

    private float currentFill = 0f;
    public float animationSpeed = 5f;

    void Start() {
        parent = transform.parent.gameObject.GetComponent<RectTransform>();
        gameManager = FindFirstObjectByType<GameManager>();
        rectTransform = GetComponent<RectTransform>();
        cameraTransform = FindFirstObjectByType<Camera>().transform;
    }

    void Update() {
        int currentZone = gameManager.GetCurrentZone(cameraTransform.position.y);
        float threshold = gameManager.GetThresholdForZone(currentZone);
        float targetFill = Mathf.Clamp01(gameManager.score / threshold);

        currentFill = Mathf.Lerp(currentFill, targetFill, Time.deltaTime * animationSpeed);

        rectTransform.sizeDelta = new Vector2(parent.sizeDelta.x * currentFill, parent.sizeDelta.y);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rectTransform.rect.width);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rectTransform.rect.height);
    }
}