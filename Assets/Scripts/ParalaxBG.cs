using UnityEngine;

public class ParalaxBG : MonoBehaviour {
    public Transform CameraTransform;
    public float YPositionMultiply = .75f;

    void Start() {
        if (CameraTransform == null)
            CameraTransform = FindFirstObjectByType<Camera>().transform;
    }
    void Update() {
        var pos = transform.localPosition;
        pos.y = -CameraTransform.position.y*YPositionMultiply;
        transform.localPosition = pos;
    }
}
