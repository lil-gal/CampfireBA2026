using UnityEngine;

public class ParalaxBG : MonoBehaviour {
    public Transform CameraTransform;
    public float YPositionMultiply = 0f;
    public float XPositionMultiply = 0f;

    public Color[] DepthColors = new Color[] {
        new Color(0.0f, 0.5f, 0.9f),
        new Color(0.0f, 0.3f, 0.7f),
        new Color(0.0f, 0.15f, 0.5f),
        new Color(0.0f, 0.05f, 0.3f),
        new Color(0.02f, 0.0f, 0.1f),
    };
    public float ZoneSize = 40f;

    private SpriteRenderer _spriteRenderer;

    void Start() {
        if (CameraTransform == null)
            CameraTransform = FindFirstObjectByType<Camera>().transform;

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        var pos = transform.localPosition;
        pos.x = CameraTransform.position.x * XPositionMultiply;
        pos.y = CameraTransform.position.y * YPositionMultiply;
        transform.localPosition = pos;

        UpdateDepthColor();
    }

    void UpdateDepthColor() {
        if (_spriteRenderer == null || DepthColors.Length < 2) return;

        float depth = Mathf.Abs(CameraTransform.position.y);
        float zoneFloat = depth / ZoneSize;
        int zoneIndex = Mathf.FloorToInt(zoneFloat);
        float t = zoneFloat - zoneIndex;

        int fromIndex = Mathf.Clamp(zoneIndex, 0, DepthColors.Length - 1);
        int toIndex   = Mathf.Clamp(zoneIndex + 1, 0, DepthColors.Length - 1);

        _spriteRenderer.color = Color.Lerp(DepthColors[fromIndex], DepthColors[toIndex], t);
    }
}