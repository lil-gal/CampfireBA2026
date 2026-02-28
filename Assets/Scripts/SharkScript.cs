using UnityEngine;

public class SharkScript : MonoBehaviour
{
    CircleCollider2D detection_collider;
    GameManager gameManager;
    Rigidbody2D rb;
    float speed;

    public float ChaseSpeed = 8f;
    public float NormalSpeed = 3f;

    private float water_level = 0; //its not like this will change..

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        detection_collider = GetComponent<CircleCollider2D>();

        speed = NormalSpeed;
        gameManager = FindFirstObjectByType<GameManager>();
        detection_collider.radius = gameManager.sharkSize;
    }

    void Update() {
        Vector2 move = transform.TransformDirection(Vector2.up);
        if (transform.position.y<water_level) {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = move * speed;
        } else 
            rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision == null) { return; }
<<<<<<< Updated upstream
        if(collision.tag == "Hurtbox" || collision.tag == "PlayerCollector") {
=======
        var player = collision.transform.parent;
        if (player.tag == "Player" && player.GetComponent<PlayerMovement>().isAlive) {
>>>>>>> Stashed changes
            LookAt(collision.transform.position);
            speed = ChaseSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision == null) { return; };
<<<<<<< Updated upstream
        if (collision.tag == "Hurtbox" || collision.tag == "PlayerCollector") {
=======
        if (collision.transform.parent.tag == "Player") {
>>>>>>> Stashed changes
            speed = NormalSpeed;
        }
    }

    private void LookAt(Vector3 target) {
        var distance = (target-transform.position).normalized;
        rb.MoveRotation(-Mathf.Atan2(distance.x, distance.y)*Mathf.Rad2Deg);
    }
}
