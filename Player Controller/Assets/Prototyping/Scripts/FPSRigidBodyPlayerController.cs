using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSRigidBodyPlayerController : MonoBehaviour
{

    public float moveSpeed = 35f;

    public float sprintSpeedMultiplier = 1.6f;

    public float jumpForce = 35f;
	public float dashDistance = 10f;
	float dashCooldown = .75f;

    public Transform groundCheckTransform;

    public LayerMask groundCheckLayerMask;

	public bool crouched = false;
	public Collider StandingHitbox;
	public Collider CrouchingHitbox;
    
    Vector3 _inputVector;
    bool _isGrounded = true;
	Rigidbody rigidBody;
	float heightCheck;
	Vector3 movement;
	float timer = 0f;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
		heightCheck = StandingHitbox.bounds.extents.y*2;
	}
    private void Update()
    {
        _inputVector = new Vector3(Input.GetAxis("Horizontal") , 0f , Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift)) // sprinting
            _inputVector.z *= sprintSpeedMultiplier;
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) { // jumping
            rigidBody.AddForce(jumpForce * 10 * transform.up, ForceMode.Acceleration);
            _isGrounded = false;
        }

		if(timer > 0f) {
            timer -= Time.deltaTime;
        } else {
            if(Input.GetKeyDown(KeyCode.V)) {
                Vector3 dashVelocity = Vector3.Scale(movement.normalized, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * 
					rigidBody.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rigidBody.drag + 1)) / -Time.deltaTime)));
					rigidBody.AddForce(dashVelocity, ForceMode.VelocityChange);
                timer = dashCooldown;
            }
        }

		Vector3 cameraTransform = Camera.main.transform.localPosition; // crouching
		if(Input.GetKeyDown(KeyCode.C) ) {
			CrouchingHitbox.enabled = true;
			StandingHitbox.enabled = false;
			Camera.main.transform.localPosition = new Vector3(cameraTransform.x, .8f, cameraTransform.z);

		} else if(Input.GetKeyUp(KeyCode.C) && !Physics.Raycast(StandingHitbox.transform.position, Vector3.up, heightCheck, groundCheckLayerMask)) {
			CrouchingHitbox.enabled = false;
			StandingHitbox.enabled = true;
			Camera.main.transform.localPosition = new Vector3(cameraTransform.x, 1.7f, cameraTransform.z);
		}

		if(transform.position.y <= -20) { // resets player if they go off map
            transform.position = Vector3.zero;
			rigidBody.velocity = Vector3.zero;
			movement = Vector3.zero;
		}
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(groundCheckTransform.position, 0.3f, groundCheckLayerMask);
        
        movement = moveSpeed * 10f * _inputVector.z * Time.fixedDeltaTime * transform.forward + moveSpeed * 10f * _inputVector.x * Time.fixedDeltaTime * transform.right;

        rigidBody.MovePosition(rigidBody.position + movement);
	}
}
