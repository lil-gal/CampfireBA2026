using Unity.VisualScripting;
using UnityEngine;

public class SeaScript : MonoBehaviour {
    public float Speed = 2.5f; // always-present speed of the waves, visible when the player isnt moving

    public Transform CameraTransform;
    private float last_camera_position_x;

    private float move_back_to = 0;

    void Start() {
        if (CameraTransform == null) 
            CameraTransform = FindFirstObjectByType<Camera>().transform;
        
        var sprite_renderer = GetComponent<SpriteRenderer>();
        move_back_to = -sprite_renderer.sprite.texture.width / sprite_renderer.sprite.pixelsPerUnit * transform.localScale.x;

        last_camera_position_x = CameraTransform.position.x;
    }

    void Update() {
        var camera_delta = CameraTransform.position.x - last_camera_position_x;
        var pos = transform.localPosition;

        float move_by = Speed * Time.deltaTime - camera_delta; // im unsure whether i sohuld multiply it by deltatime; ig time will tell

        pos.x += move_by;
        if (pos.x > 0) pos.x = move_by+move_back_to;
        pos.x %= move_back_to;

        pos.y = -CameraTransform.position.y;

        transform.localPosition = pos;


        last_camera_position_x = CameraTransform.position.x;
    }
}
