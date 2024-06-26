using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInput : MonoBehaviour
{
    private Rigidbody TestRigidBody;
    // Start is called before the first frame update
    void Awake()
    {
        TestRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("jump" + context.phase);
            TestRigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        
    }
}
