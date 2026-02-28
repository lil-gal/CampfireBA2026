using UnityEngine;

public class CameraTargetScript : MonoBehaviour
{
    private Transform player_transform;

    void Start()
    {
        player_transform = transform.parent;
    }

    void Update()
    {
        var pos = player_transform.position;
        pos.y = Mathf.Min(0, player_transform.position.y);
        transform.position = pos;
    }
}