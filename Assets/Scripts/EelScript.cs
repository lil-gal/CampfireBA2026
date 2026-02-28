using UnityEngine;

public class EelScript : MonoBehaviour
{
    public float minSpeed = 2f;
    public float maxSpeed = 10f;
    public Vector2 direction;

    Rigidbody2D rb;
    
    float speed;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;
    }
}
