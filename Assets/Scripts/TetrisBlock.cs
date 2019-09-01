using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private float lastTime = 0;
    private float deltaFallTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }

 
        
        if (Time.time - lastTime > (Input.GetKey(KeyCode.DownArrow) ? deltaFallTime / 10 : deltaFallTime ))
        {
            transform.position += new Vector3(0, -1, 0);
            lastTime = Time.time;
        }
        Debug.Log(Time.time);
    }
}
