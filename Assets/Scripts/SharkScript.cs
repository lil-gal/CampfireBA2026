using UnityEngine;

public class SharkScript : MonoBehaviour
{
    CircleCollider2D detection_collider;
    GameManager gameManager;
    Rigidbody2D rb;
    float speed;

    public float ChaseSpeed = 8f;
    public float NormalSpeed = 3f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        detection_collider = GetComponent<CircleCollider2D>();

        speed = NormalSpeed;
        gameManager = FindFirstObjectByType<GameManager>();
        detection_collider.radius = gameManager.sharkSize;
    }

    void Update() {
        Vector2 move = transform.TransformDirection(Vector2.up);
        rb.linearVelocity = move * speed;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision == null) { return; }
        if(collision.tag == "Player") {
            LookAt(collision.transform.position);
            speed = ChaseSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision == null) { return; };
        if (collision.tag == "Player") {
            speed = NormalSpeed;
        }
    }

    private void LookAt(Vector3 target) {
        var distance = (target-transform.position).normalized;
        rb.MoveRotation(-Mathf.Atan2(distance.x, distance.y)*Mathf.Rad2Deg);
    }
}
