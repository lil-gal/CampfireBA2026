using UnityEngine;

public class ParalaxBG : MonoBehaviour {
    public Transform CameraTransform;
    public float YPositionMultiply = .75f;
    public float XPositionMultiply = .75f;

    void Start() {
        if (CameraTransform == null)
            CameraTransform = FindFirstObjectByType<Camera>().transform;
    }

    void Update() {
        var pos = transform.localPosition;
        pos.x = CameraTransform.position.x * XPositionMultiply;
        pos.y = CameraTransform.position.y * YPositionMultiply;
        transform.localPosition = pos;
    }
}