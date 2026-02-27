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
        Vector2 move = this.transform.TransformDirection(moveInput);
        characterController.Move(moveInput * moveSpeed * Time.deltaTime);
        this.transform.Rotate(rotateInput * rotateSpeed * Time.deltaTime);

    }

    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();

        if(moveInput.y < 0) {
            moveInput /= backwardsSpeedDivide;
        }
        Debug.Log("moveInput");
    }

    public void OnRotate(InputAction.CallbackContext context) {
        rotateInput = context.ReadValue<Vector2>();
    }
}
