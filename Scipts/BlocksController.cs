using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    //my try on winning condition
    //public List<GameObject> Bricks = new List<GameObject>();  //Had to change Blocks --> Bricks
    public GameController GameController;
    int BlocksCount;


    //Matt's BlockController
    public GameObject BlockPrefab;

    List<Vector3> BlockPositions = new List<Vector3>();
    Block[] Blocks;



    private void Awake()
    {
        Blocks = GetComponentsInChildren<Block>();

        foreach(Block block in Blocks)
        {
            BlockPositions.Add(block.transform.position);
        }
        ResetBlocks();
    }

    public void ResetBlocks()
    {
        //remove old blocks
        for (int i = Blocks.Length -1; i >= 0; i--)
        {
            if(Blocks[i] != null)
            {
                Destroy(Blocks[i].gameObject);
            }
        }

        //create new blocks
        for (int i = 0; i < BlockPositions.Count; i++)
        {
            GameObject newBlockobj = GameObject.Instantiate(BlockPrefab, BlockPositions[i], Quaternion.identity, transform);
            Blocks[i] = newBlockobj.GetComponent<Block>();

        }
        //
        BlocksCount = Blocks.Length;
            //Debug.Log(BlocksCount);
    }




    //Subtract count to achive victory! To be modified...
    public void LessenBlocksCount()
    {
        BlocksCount--;
            //Debug.Log(BlocksCount);

        if (BlocksCount == 0) //6)
        {
            GameController.Winning();
        }
    }


    //ex way of resetting blocks
    //public void BlocksReset()
    //{
    //    for (int i = 0; i <= Bricks.Count - 1; i++)
    //    {
    //        Bricks[i].SetActive(true);
    //    }
    //    BlocksCount = 0;
    //}
}
