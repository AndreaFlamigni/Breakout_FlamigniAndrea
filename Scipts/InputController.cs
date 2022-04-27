using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    GameController gameController;
    Paddle paddle;

    //-----------------
    public PaddleSelector paddleSelector;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        paddle = FindObjectOfType<Paddle>();
        //paddleSelector =
    }

    private void Update()
    {
        if (!gameController.IsPlaying && gameController.IsPaused)
        {
            //Paddle Selection
            if (Input.GetKeyDown(KeyCode.A)) //|| Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.A))            
            {
                Debug.Log("A was pressed");
                int selection = 0;
                paddleSelector.SelectPaddle(selection);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("B was pressed");
                int selection = 1;
                paddleSelector.SelectPaddle(selection);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("C was pressed");
                int selection = 2;
                paddleSelector.SelectPaddle(selection);
            }
        }


        //On pause
        if (gameController.IsPlaying && gameController.IsPaused)
        {
            if (Input.anyKeyDown && !Input.GetMouseButton(0))
            {
                gameController.UnpauseGame();
            }

        }
        //While Playing
        else if(gameController.IsPlaying && !gameController.IsPaused)
        {
            //moving the paddle
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                paddle.Move(Vector2.left);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                paddle.Move(Vector2.right);
            }
            //Shooting
            if (Input.GetKey(KeyCode.Space) && paddle.fireDuration <= 0.0f)
            {
                paddle.Shoot();
            }
            paddle.fireDuration -= Time.deltaTime;

            //Mettere in pausa durante il gioco
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameController.PauseGame();
            }
        }
    }
}
