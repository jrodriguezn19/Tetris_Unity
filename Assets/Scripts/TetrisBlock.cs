using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class TetrisBlock : MonoBehaviour
{
    public static int boardY = 20;
    public static int boardX = 10;
    public Vector3 center;
    private static Transform[,] mesh = new Transform[boardX, boardY];
    private float lastTime = 0;
    public float deltaFallTime = 1.0f;
    public static int linesCounter = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move Tetris block to the right
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            transform.position += new Vector3(1, 0, 0);
            if (validMovement() == false)
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        //Move Tetris block to the left
        else if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            transform.position += new Vector3(-1, 0, 0);
            if (validMovement() == false)
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }//Rotate Tetris block        
        else if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {           
            for(int i  = 0; i <= 90; i = i + 10)
            {
                transform.RotateAround(transform.TransformPoint(center), new Vector3(0, 0, 1), i);
            }
            
            if (validMovement() == false)
            {
                transform.RotateAround(transform.TransformPoint(center), new Vector3(0, 0, 1), -90);
            }                
        }// Finish the game if escape key is pressed
        else if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene("StartMenu");
        }
        //Move Tetris block down
        if (Time.time - lastTime > (Input.GetKey(KeyCode.DownArrow) ? (deltaFallTime / 10) : deltaFallTime ))
        {
            transform.position += new Vector3(0, -1, 0);
            if (validMovement() == false)
            {
                transform.position -= new Vector3(0, -1, 0);
                AddNew();
                LineCompleted();
                this.enabled = false;
                FindObjectOfType<CreatorBlocks>().CreateBlock();
            }
            lastTime = Time.time;
        }
    }

    //Check if the requested movement is valid   
    bool validMovement()
    {
        foreach (Transform block in transform)
        {
            int intX = Mathf.RoundToInt(block.transform.position.x);

            int intY = Mathf.RoundToInt(block.transform.position.y);

            if((intX < 0) || (intX >= boardX) || (intY < 0) || (intY >= boardY))
            {
                return false;
            }
            if (mesh[intX, intY] != null)
            {
                return false;
            }
                
        }
        return true;
    }
    //Add new
    void AddNew()
    {
        foreach (Transform block in transform)
        {
            int intX = Mathf.RoundToInt(block.transform.position.x);

            int intY = Mathf.RoundToInt(block.transform.position.y);

            mesh[intX, intY] = block;
        }
    }
    //Check Line completed then remove and move everything down
    void LineCompleted()
    {
        for (int i = boardY - 1; i >= 0; i--)
        {
            if (checkLine(i) == true)
            {
                linesCounter++;
                RemoveLine(i);
                MoveAllDown(i);                
            }
        }
    }
    //Check if there was a line completed
    bool checkLine(int t)
    {
        for (int i = 0; i < boardX; i++)
        {
            if (mesh[i,t] == null)
            {
                return false;
            }
                
        }

        return true;
    }
    //Remove completed line
    void RemoveLine(int t)
    {
        for (int i = 0; i < boardX; i++)
        {
            Destroy(mesh[i,t].gameObject);
            mesh[i, t] = null;
        }
    }
    //Move down all Tetris blocks
    void MoveAllDown(int t)
    {
        for (int i = t; i < boardY; i++)
        {
            for (int j = 0; j < boardX; j++)
            {
                if (mesh[j,i] != null)
                {
                    mesh[j,i-1] = mesh[j,i];
                    mesh[j,i] = null;
                    mesh[j,i-1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }




}
