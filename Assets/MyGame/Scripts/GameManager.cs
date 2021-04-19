using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int numSpace;
    int numK;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            numSpace++;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            numK++;
        }
        if(numK>10)
        {
            Debug.Log("rote Blumen");
        }
    }
}
