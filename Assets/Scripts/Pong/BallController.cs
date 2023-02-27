using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private float startDir;
    private Rigidbody rb;
    private bool collided = false;
    public Vector3 ballVect;

    private void Awake()
    {
        startDir = Random.Range(-1.0f, 1.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(startDir < 0.0f) { rb.velocity = Vector3.right * speed; }
        else { rb.velocity = -Vector3.right * speed; }
    }

    // Update is called once per frame
    void Update()
    {
        ballVect = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collided)
        {

            /*if (collision.collider.gameObject.name == "Middle Collider")
            {
                collided = true;
                Debug.Log("Middle");
                rb.velocity = -rb.velocity.normalized * speed;
            }
            else if (collision.collider.gameObject.name == "Top Collider")
            {
                collided = true;
                Debug.Log("Top");
                rb.velocity = (-rb.velocity.normalized + Vector3.forward) * speed;
            }
            else if (collision.collider.gameObject.name == "Bottom Collider")
            {
                collided = true;
                Debug.Log("Bottom");
                rb.velocity = (-rb.velocity.normalized + -Vector3.forward) * speed;
            }*/
            if(collision.collider.gameObject.name == "Paddle")
            {
                //rb.velocity = (-rb.velocity.normalized + collision.collider.attachedRigidbody.velocity.normalized) * speed;
                rb.velocity = new Vector3(-rb.velocity.x,0, collision.collider.attachedRigidbody.velocity.z).normalized * speed;
            }
            else if (collision.collider.gameObject.name == "Wall Top")
            {
                collided = true;
                Debug.Log("Wall Top");
                //rb.velocity = (rb.velocity.normalized + -Vector3.forward.normalized) * speed;
                rb.velocity = new Vector3(rb.velocity.x, 0, -1) * speed;
            }
            else if (collision.collider.gameObject.name == "Wall Bottom")
            {
                collided = true;
                Debug.Log("Wall Bottom");
                //rb.velocity = (rb.velocity.normalized + Vector3.forward.normalized) * speed;
                rb.velocity = new Vector3(rb.velocity.x, 0, 1) * speed;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collided)
        {
            collided = false;
        }
    }
}
