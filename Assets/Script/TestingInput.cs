using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class TestingInput : MonoBehaviour
{
    private Rigidbody TestRigidBody;
    private PlayerInput playerInput;
    private PlayerInputAction playerInputAction;
    // Start is called before the first frame update
    void Awake()
    {
        TestRigidBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

         playerInputAction = new PlayerInputAction();
         playerInputAction.Player.Enable(); // c sharp
         playerInputAction.Player.Jump.performed += Jump;
        


        playerInputAction.Player.Movement.performed += Movement_performed;

    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        

    }
    private void Update()
    {
        if(Keyboard.current.tKey.wasPressedThisFrame) 
        {
            playerInput.SwitchCurrentActionMap("UI");
           // playerInputAction.Player.Disable(); //c sharp
           // playerInputAction.UI.Enable(); //c sharp
        }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            playerInput.SwitchCurrentActionMap("Player");
        }
    }

    private void FixedUpdate()
    {
        
        Vector2 inputVector = playerInputAction.Player.Movement.ReadValue<Vector2>();
        float speed = 2f;
        TestRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }



    // Update is called once per frame 
    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("jump" + context.phase);
            TestRigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        
    }

    public void Submit(InputAction.CallbackContext context)
    {
        Debug.Log("Submit"+context);

    }
}
