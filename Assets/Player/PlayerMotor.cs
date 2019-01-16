using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	[SerializeField]
	private Camera camera;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	//Gets a movement vector
	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
	}

	//Gets a movement vector
	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}

	//Gets a camera rotation vector
	public void RotateCamera(Vector3 _cameraRotation)
	{
		cameraRotation = _cameraRotation;
	}

	//Run every physics iteration
	private void FixedUpdate()
	{
		PerformMovement();
		PerformRotation();
	}

	//performovment based on velocity variable
	void PerformMovement()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	//perform rotation
	void PerformRotation()
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		if (camera != null)
		{
			camera.transform.Rotate(-cameraRotation);
		}
	}
}
