using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float carSpeed, turningSpeed;
    [SerializeField] private InputActionReference moveInput, boostInput;

    private float moveX, moveY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RegisterInput();
        MoveVehicle();
        Turnvehicle();
    }


    private void RegisterInput()
    {
        if (boostInput.action.IsPressed())
        {
            carSpeed = 20;
        }
        else
        {
            carSpeed = 10;
        }
        moveX = moveInput.action.ReadValue<Vector2>().x;
        moveY = moveInput.action.ReadValue<Vector2>().y;
    }

    private void MoveVehicle()
    {
        transform.Translate(-Vector3.forward * moveY * carSpeed * Time.deltaTime);
        if (moveX != 0)
        {
            Debug.Log("Vehicle Is Moving");
        }
    }

    private void Turnvehicle()
    {
        transform.Rotate(0, 90 * moveX * Time.deltaTime, 0);
    }
}
