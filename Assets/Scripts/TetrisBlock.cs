﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public static int boardY = 20;
    public static int boardX = 10;
    public Vector3 center;
    private static Transform[,] mesh = new Transform[boardX, boardY];
    private float lastTime = 0;
    public float deltaFallTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move Tetris blocks to the right
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            transform.position += new Vector3(1, 0, 0);
            if (validMovement() == false)
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        //Move Tetris blocks to the left
        else if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            transform.position += new Vector3(-1, 0, 0);
            if (validMovement() == false)
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }//Rotate Tetris blocks        
        else if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {           
            transform.RotateAround(transform.TransformPoint(center), new Vector3(0, 0, 1), 90);
            if (validMovement() == false)
            {
                transform.RotateAround(transform.TransformPoint(center), new Vector3(0, 0, 1), -90);
            }                
        }
        //Accelerate falling speed
        if (Time.time - lastTime > (Input.GetKey(KeyCode.DownArrow) ? deltaFallTime / 10 : deltaFallTime ))
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

            if(intX < 0 || intX >= boardX || intY < 0 || intY >= boardY)
            {
                return false;
            }
            if (mesh[intX, intY] != null)
                return false;
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
            if (checkLine(i))
            {
                RemoveLine(i);
                MoveDownAll(i);
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
    void MoveDownAll(int t)
    {
        for (int y = t; y < boardY; y++)
        {
            for (int i = 0; i < boardX; i++)
            {
                if (mesh[i,y] != null)
                {
                    mesh[i,y-1] = mesh[i,y];
                    mesh[i,y] = null;
                    mesh[i,y-1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }




}
