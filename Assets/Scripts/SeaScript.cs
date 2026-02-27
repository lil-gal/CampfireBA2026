using Unity.VisualScripting;
using UnityEngine;

public class SeaScript : MonoBehaviour {
    public float Speed = 2.5f; // speed of the waves when the player isnt moving

    public float YOffset = 0; // meant to be used by another object; pseudo: YOffset = -Player.Y
    public float XOffsetPoll = 0; // meant to be used by another object; pseudo: XOffsetPoll += Player.X; NO DELTATIME MULTIPLYING FOR NOW 

    private float move_back_to = 0;

    void Start() {
        var sprite_renderer = GetComponent<SpriteRenderer>();
        move_back_to = -sprite_renderer.sprite.texture.width / sprite_renderer.sprite.pixelsPerUnit * transform.localScale.x;
    }

    void Update() {
        var pos = transform.position;

        float move_by = Speed * Time.deltaTime + XOffsetPoll; // im unsure whether i sohuld multiply it by deltatime; ig time will tell
        
        pos.x += move_by;
        pos.y = YOffset;
        if (pos.x > 0) pos.x = move_by+move_back_to;
        
        transform.position = pos;

        XOffsetPoll = 0; // reset the poll
    }
}
