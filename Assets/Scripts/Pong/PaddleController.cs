using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private Rigidbody rb;
    private KeyCode UpKey;
    private KeyCode DownKey;
    [SerializeField] private bool isPlayerOne;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (isPlayerOne)
        {
            case true:
                UpKey = KeyCode.W;
                DownKey = KeyCode.S;
                break;
            case false:
                UpKey = KeyCode.UpArrow;
                DownKey= KeyCode.DownArrow;
                break;
        }

        if (Input.GetKey(UpKey)) { rb.velocity = Vector3.forward * speed; }
        else if (Input.GetKey(DownKey)) { rb.velocity = -Vector3.forward * speed; }
        else { rb.velocity = Vector3.zero; }
    }
}
