using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorBlocks : MonoBehaviour
{
    public GameObject[] blocks;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateBlock();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Create a new Tetris Block
    public void CreateBlock()
    {
        Instantiate(blocks[Random.Range(0, blocks.Length)], transform.position, Quaternion.identity);
    }
}
