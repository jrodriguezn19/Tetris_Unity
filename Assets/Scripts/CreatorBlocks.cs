using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorBlocks : MonoBehaviour
{
    public GameObject[] blocks;
    public Text linesText;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateBlock();
    }

    // Update is called once per frame
    void Update()
    {
       // linesText.text = linesCounter.ToString();
    }
    //Create a new Tetris Block
    public void CreateBlock()
    {
        Instantiate(blocks[Random.Range(0, blocks.Length)], transform.position, Quaternion.identity);
    }
}
