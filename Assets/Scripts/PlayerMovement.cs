using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private BoxCollider2D hurtbox;
    private GameOverScript gameOverScreen;

    public CharacterController characterController;
    public float rotateSpeed = 10f;
    public float backwardsSpeedDivide;

    private Vector2 moveInput;
    private Vector2 rotateInput;

    public GameManager gameManager;
    public upgradePanelScript upgradePanel;

    public bool isAlive = true;

    private GameObject sprite;
    bool moving;

    [HideInInspector] public bool isBouncing = false;
    private float bounceTimer = 0f;
    public float bounceDuration = 0.6f;
    public float bounceSpeed = 5f;
    private float bounceRotationTarget;
    public float bounceRotationSpeed = 8f;

    [HideInInspector] public float lowerBoundaryY = float.MinValue;
    [HideInInspector] public float upperBoundaryY = float.MaxValue;

    void Start()
    {
        hurtbox = GetComponentInChildren<BoxCollider2D>();
        gameOverScreen = FindFirstObjectByType<GameOverScript>();
        sprite = GetComponentInChildren<SpriteRenderer>().gameObject;
        hurtbox.enabled = true;
        isAlive = true;
    }

    public void Death() {
        hurtbox.enabled = false;
        gameOverScreen.ShowGameOver = true;
        gameOverScreen.setScores(gameManager.score);
        GameSounds.instance.PlaySoundEffect("death");
        isAlive = false;
    }

    public void UpdateStats() {
        moveSpeed = gameManager.moveSpeed;
    }

    public void Bounce() {
        isBouncing = true;
        bounceTimer = bounceDuration;
        bounceRotationTarget = transform.eulerAngles.z + 180f;
    }

    void Update()
    {
        if (!isAlive) {
            moveInput = Vector2.zero;
            rotateInput = Vector2.zero;
            moving = false;
        }

        transform.Rotate(new Vector3(0, 0, rotateInput.x) * rotateSpeed);

        Vector2 move;
        if (isBouncing) {
            bounceTimer -= Time.deltaTime;

            float currentZ = transform.eulerAngles.z;
            float newZ = Mathf.LerpAngle(currentZ, bounceRotationTarget, Time.deltaTime * bounceRotationSpeed);
            transform.rotation = Quaternion.Euler(0f, 0f, newZ);

            moveInput = Vector2.zero;
            move = this.transform.TransformDirection(Vector2.up);
        } else {
            move = this.transform.TransformDirection(moveInput);
        }

        if (transform.position.y <= lowerBoundaryY && move.y < 0) {
            move.y = 0;
            if (!isBouncing) Bounce();
        }

        if (transform.position.y >= upperBoundaryY && move.y > 0) {
            move.y = 0;
            if (!isBouncing) Bounce();
        }

        characterController.Move(move * (isBouncing ? bounceSpeed : moveSpeed) * Time.deltaTime);

        if (isBouncing && bounceTimer <= 0f)
            isBouncing = false;

        if (moving && !isBouncing) {
            float amplitude = moveSpeed;
            float frequency = 3f;
            float angle = Mathf.Sin(Time.time * frequency) * amplitude;
            sprite.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        } else if (!isBouncing) {
            sprite.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();

        if (moveInput.y < 0) {
            moveInput /= backwardsSpeedDivide;
        }

        if (context.canceled) {
            moving = false;
        } else {
            moving = true;
        }
    }

    public void OnRotate(InputAction.CallbackContext context) {
        rotateInput = -context.ReadValue<Vector2>();
    }
    
}
