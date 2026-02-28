using UnityEngine;

public class JellyFishScript : MonoBehaviour
{
    public float minBounceDistance = 1f;
    public float minTimeToBounce = 2f;
    public float maxBounceDistance = 8f;
    public float maxTimeToBounce = 10f;

    float bounceDistance;
    float timeToBounce;

    float timer;
    bool up = false;

    public float amplitude = 5f;   // How far it rotates (degrees)
    public float frequency = 3f;   // How fast it jiggles

    Rigidbody2D rb;
    void Start()
    {
        bounceDistance = Random.Range(minBounceDistance, maxBounceDistance);
        timeToBounce = Random.Range(minTimeToBounce, maxTimeToBounce);
        timer = timeToBounce;
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // bounce
        if (timer > 0) {
            int times = 1;

            if (!up) {
                times = -1;
            }
            
            rb.linearVelocityY = times * Time.deltaTime * 100 * (bounceDistance/timeToBounce);

            timer-=Time.deltaTime;
        } else {
            timer = timeToBounce;
            up = !up;
        }

        
        float angle = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);

        transform.position = transform.position + new Vector3(Mathf.Sin(Time.time * 10f), 0f, 0f) / 200;
    }
}
