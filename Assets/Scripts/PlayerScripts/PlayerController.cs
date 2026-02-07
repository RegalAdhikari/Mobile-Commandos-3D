using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas inputCanvas;
    public CharacterController controller;
    public VariableJoystick joystick;
    public bool isJoystick;
    public float moveSpeed;
    public float rotationSpeed;

    public Animator playerAnimator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0.0f,joystick.Direction.y);
            controller.SimpleMove(movementDirection * moveSpeed);
            if (movementDirection.sqrMagnitude <=0 )
            {
                playerAnimator.SetBool("isMoving",false);
                return;
            }
            playerAnimator.SetBool("isMoving",true);
            var targetDirection = Vector3.RotateTowards(controller.transform.forward, movementDirection, rotationSpeed*Time.deltaTime, 0.0f );
            controller.transform.rotation = Quaternion.LookRotation(targetDirection);
        }

        
    }
    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }
}
