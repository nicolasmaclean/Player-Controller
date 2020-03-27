using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSRigidBodyCameraController : MonoBehaviour
{
    public Transform target;
    public float lookSpeed = 30f;

    private float _camRotation;
    Rigidbody rigidBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidBody = target.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Cursor.lockState == CursorLockMode.Locked) {
            float y = Input.GetAxis("Mouse Y");
            float x = Input.GetAxis("Mouse X");
            
            _camRotation -= y * lookSpeed * Time.deltaTime * 10f;
            _camRotation = Mathf.Clamp(_camRotation, -60f, 60f);
            
            transform.localRotation = Quaternion.Euler(_camRotation , 0f ,0f);
            
            rigidBody.rotation = Quaternion.Euler(rigidBody.rotation.eulerAngles + x * lookSpeed * Time.deltaTime * 10f * Vector3.up);
        }
        
        if(Input.GetMouseButton(0))
            Cursor.lockState = CursorLockMode.Locked;
        
        if(Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.Confined;
    }
}
