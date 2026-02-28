using UnityEngine;

public class CameraTargetScript : MonoBehaviour {
    private Transform player_transform;
    private float progress_x; // will only increment. player cannot go backwards
    void Start() {
        player_transform = transform.parent;
        progress_x = player_transform.position.x;
    }
    void Update() {
        var pos = player_transform.position;
        pos.x = Mathf.Max(progress_x, player_transform.position.x);
        pos.y = Mathf.Min(0, player_transform.position.y);
        transform.position = pos;

        progress_x = pos.x;
    }
}
