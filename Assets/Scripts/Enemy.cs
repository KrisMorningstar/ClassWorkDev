using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isPlayerCaught = false;
    public Vector3 currentNode;

    //delegate gameoverdelegate
    //event gameoverdelegate gameoverevent delegate

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerCaught == false)
        {
            if(currentNode == null)
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isPlayerCaught == false)
        {
            if(other.tag == "Player")
            {
                isPlayerCaught = true;
                //game over event invoke
            }
        }
    }
}
