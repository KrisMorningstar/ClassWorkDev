using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    // variable for controlling speed
    [SerializeField] private float speed;
    // variabel for controlling accelleration
    [SerializeField] private float acceleration;

    // variable for controlling acceleration direction
    private bool forwardGear = true;

    // variable for controlling steering force
    private Vector3 steering;

    private Rigidbody rb;

    private void Awake()
    {
        if (!TryGetComponent<Rigidbody>(out rb))
        {
            Debug.Log("uh oh, someone made a fucky wucky with the rigidbody uwu~");
        }
        /*if(rb == null)
        {
            if(!TryGetComponent<Rigidbody>(out rb))
            {
                Debug.Log("uh oh, someone made a fucky wucky with the rigidbody uwu~");
            }
        }*/
        acceleration = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        // subscribe to acceleration and decelleration events
        CarButton.changeAccelerationEvent += Accelerate;
        // subscribe to steering events

    }

    // Update is called once per frame
    void Update()
    {
        if (forwardGear)
        {
            Vector3 move = transform.forward * speed * acceleration * Time.deltaTime;
            move = move.normalized;
            rb.velocity = move;
        }
        else
        {
            Vector3 Move = -transform.forward * speed * acceleration * Time.deltaTime;
            Move = Move.normalized;
            rb.velocity = Move;
        }
    }

    public void Accelerate(float _acceleration)
    {
        acceleration += _acceleration;
    }
}
