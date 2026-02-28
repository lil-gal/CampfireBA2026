using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FishGravity : MonoBehaviour
{
    [SerializeField] private float waterGravity = 2f;
    [SerializeField] private float airGravity = 18f;
    [SerializeField] private float waterLevel = 0f;
    [SerializeField] private float waterDrag = 5f;

    private CharacterController cc;
    private float verticalVelocity = 0f;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (transform.position.y < waterLevel)
        {
            verticalVelocity = Mathf.Lerp(verticalVelocity, 0f, waterDrag * Time.deltaTime);
        }
        else
        {
            verticalVelocity -= airGravity * Time.deltaTime;
        }

        cc.Move(new Vector3(0, verticalVelocity * Time.deltaTime, 0));
    }

    public void AddVerticalVelocity(float amount)
    {
        verticalVelocity += amount;
    }
}