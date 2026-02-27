using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CharacterController characterController;
    public float rotateSpeed = 10f;

    public float backwardsSpeedDivide;

    private Vector2 moveInput;
    private Vector2 rotateInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0,0,rotateInput.x) * rotateSpeed); //rotate

        Vector2 move = this.transform.TransformDirection(moveInput); //moves it in a direction
        characterController.Move(move * moveSpeed * Time.deltaTime);
        

    }

    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();

        if(moveInput.y < 0) {
            moveInput /= backwardsSpeedDivide;
        }
    }

    public void OnRotate(InputAction.CallbackContext context) {
        rotateInput = -context.ReadValue<Vector2>();
        Debug.Log("ROT");
    }
}
