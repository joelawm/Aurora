using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	//Class Variables
	[SerializeField]
	private float speed = 2f;
	[SerializeField]
	private float mouseSensitivity = 3f;
	[SerializeField]
	private float UpperViewangle = 45.0f;
	[SerializeField]
	private float LowerViewangle = -45.0f;
	[SerializeField]
	private float _xRotation = 0;

	private PlayerMotor motor;

	private void Start()
	{
		motor = GetComponent<PlayerMotor>();
	}

	void Update()
	{
		//Calculate movemnt velocity as 3d Vector
		float _xMovement = Input.GetAxisRaw("Horizontal");
		float _zMovement = Input.GetAxisRaw("Vertical");

		Vector3 _MovementHorizontal = transform.right * _xMovement;
		Vector3 _MovementVeritcal = transform.forward * _zMovement;

		//Final Movement vector
		Vector3 _Velocity = (_MovementHorizontal + _MovementVeritcal).normalized * speed;

		//Apply movement
		motor.Move(_Velocity);

		//Calculate Rotation as 3D vector (turning around)
		float _yRotation = Input.GetAxisRaw("Mouse X");
		Vector3 _rotation = new Vector3(0f, _yRotation, 0f) * mouseSensitivity;

		//apply rotation
		motor.Rotate(_rotation);

		//Calculate camera rotation as 3D vector (turning around)
		_xRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
		//Vector3 _cameraRotation = new Vector3(_xRotation, 0f, 0f) * mouseSensitivity; Old Method
		Vector3 _cameraRotation = new Vector3(Mathf.Clamp(_xRotation, LowerViewangle, UpperViewangle), 0f, 0f);


		//Make this shit work
		//_rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
		//_xRotation = Mathf.Clamp(_xRotation, LowerViewangle, UpperViewangle); //Clamps the vertical angle within the min and max limits (45 degrees)

		//float rotationY = transform.localEulerAngles.y;

		//transform.localEulerAngles = new Vector3(_xRotation, rotationY, 0);

		//Debug for clamping
		//Debug.Log(_cameraRotation);

		//apply rotation
		motor.RotateCamera(_cameraRotation);
	}
}
