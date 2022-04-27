using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSelector : MonoBehaviour
{

    //now the problem with childing the sprites, RGBD and Colliders
    //is that the Paddle(parent) slides across the L/R Walls


    //different speeds
    public Vector3 MoveSpeeds;
    public Paddle Paddle;

    public List<GameObject> Paddles = new List<GameObject>();
    int Selection;

    public void SelectPaddle(int _value)
    {
        Selection = _value;
        //Debug.Log(Selection);
        for (int i = Paddles.Count - 1; i >= 0; i--)
        {
            if (i != Selection)
            {
                Paddles[i].SetActive(false);
                
            }
            else
            {
                Paddles[i].SetActive(true);
                Paddle.MoveSpeed = MoveSpeeds[i];
            }

        }

        //Paddle.MoveSpeed = PaddleMoveSpeed;
    }
}
