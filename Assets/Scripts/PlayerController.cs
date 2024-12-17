using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;

    CameraController cameraController;
    Animator animator;
    CharacterController characterController;
    void Awake(){
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveInput = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 moveDir = cameraController.PlanarRotation() * moveInput;

        if (moveInput.magnitude > 0){
            characterController.Move(moveDir * speed * Time.deltaTime);
            // transform.position += moveDir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        animator.SetFloat("moveAmount", moveInput.magnitude);
    }
}
