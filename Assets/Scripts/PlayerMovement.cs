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

    private GameObject sprite;

    bool moving;

    void Start()
    {
        hurtbox = GetComponentInChildren<BoxCollider2D>();
        gameOverScreen = FindFirstObjectByType<GameOverScript>();
        sprite = GetComponentInChildren<SpriteRenderer>().gameObject;
    }

    public void Death() {
        Debug.Log("DIED");
    }

    public void UpdateStats() {
        moveSpeed = gameManager.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0,0,rotateInput.x) * rotateSpeed); //rotate


        Vector2 move = this.transform.TransformDirection(moveInput); //moves it in a direction
        characterController.Move(move * moveSpeed * Time.deltaTime);

        //rotation of the sprite
        if (moving) {
            float amplitude = moveSpeed;   // How far it rotates (degrees)
            float frequency = 3f;   // How fast it jiggles
            float angle = Mathf.Sin(Time.time * frequency) * amplitude;
            sprite.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        } else {
            sprite.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        } 
        

    }

    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();

        if(moveInput.y < 0) {
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

    public void Temp(InputAction.CallbackContext context) {
        if (!context.started) { return; }
        upgradePanel.LevelUp();
    }

}
