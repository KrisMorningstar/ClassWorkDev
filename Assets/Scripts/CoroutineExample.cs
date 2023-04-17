using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndPrint(1f));
        InvokeRepeating("UpdateAIPathfinding", 1f, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateAIPathfinding()
    {
        Debug.Log("Checking AI Paths");
    }

    private IEnumerator WaitAndPrint(float _waitTime)
    {
        Debug.Log("First Message, no time has passed");
        yield return new WaitForSeconds(_waitTime);
        Debug.Log("Next Message, " + _waitTime + " seconds have passed");
        yield return new WaitForSeconds(_waitTime + 4);
        Debug.Log("Next Message, " + (_waitTime + 1f) + " seconds have passed");
    }


}
