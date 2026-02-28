using UnityEngine;

public class SharkScript : MonoBehaviour
{
    CapsuleCollider2D capsule;
    GameManager gameManager;
    Rigidbody2D rb;

    public float ChaseSpeed = 8f;
    public float NormalSpeed = 3f;
    float speed;
    void Start()
    {
        speed = NormalSpeed;
        rb = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        gameManager = GameObject.FindWithTag("GameController").gameObject.GetComponent<GameManager>();
        capsule.size = new Vector2(gameManager.sharkSize, gameManager.sharkSize+3);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 move = this.transform.TransformDirection(Vector2.up);
        rb.linearVelocity = move * speed;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision == null) { return; }
        if(collision.tag == "Player") {
            transform.LookAt(collision.transform);
            speed = ChaseSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision == null) { return; };
        if (collision.tag == "Player") {
            speed = NormalSpeed;
        }
    }
}
