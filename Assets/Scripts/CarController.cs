using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float carAcceleration, turningSpeed;
    public float carAccelBasic, carAccelBoost;
    public float maxCarSpeed;
    [SerializeField] private InputActionReference moveInput, boostInput;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer carBody;
    [SerializeField] private Material carTexturedMaterial, carMaterialNotexture;

    public bool ChangeMaterial = false;


    private float colAmount = 0;

    private float moveX, moveY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //get a reference to the current rigidbody on this gameobject
    }

    // Update is called once per frame
    void Update()
    {
        RegisterInput();
        MoveVehicle();
        Turnvehicle();
        if (ChangeMaterial)
        {
            carBody.material = carTexturedMaterial;
        }
        else
        {
            carBody.material = carMaterialNotexture;
        }
    }


    private void RegisterInput()
    {
        if (boostInput.action.IsPressed())
        {
            carAcceleration = carAccelBoost;
        }
        else
        {
            carAcceleration = carAccelBasic;
        }
        moveX = moveInput.action.ReadValue<Vector2>().x;
        moveY = moveInput.action.ReadValue<Vector2>().y;
    }

    private void MoveVehicle()
    {
        //limit the velocity
        if (rb.linearVelocity.magnitude < maxCarSpeed)
        {
            rb.AddForce(-transform.forward * carAcceleration * moveY * Time.deltaTime);
        }
        if (moveY != 0)
        {
            //Debug.Log("Vehicle Is Moving, current speed: " + rb.linearVelocity.magnitude);
        }
    }

    private void Turnvehicle()
    {
        transform.Rotate(0, 90 * moveX * Time.deltaTime, 0);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //on collision enter allows us to detect collisions, the collision that is passed in is the collision object of the 
        //object we collided with
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            colAmount += 1;
            Debug.Log("Obstacle Detected: Collision Amount = " + colAmount);

        }

    }
}
