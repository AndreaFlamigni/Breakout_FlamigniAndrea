using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Score = 0;
    public int Lives = 3;
    public int InitialLives = 3;

    public UIController UIController;
    public AudioController AudioController;
    //Blocks reset&win condition
    public BlocksController BlocksController;

    public Ball Ball;
    public Vector3 BallResetPosition;
    // Paddle reset
    public Paddle Paddle;
    public Vector3 PaddleResetPosition;

    public GameObject ExplosionPrefab;

    private bool isPlaying  = false;
    public bool IsPlaying { get { return isPlaying; } }
    private bool isPaused = false;
    public bool IsPaused { get { return isPaused; } }

    //bug at the very start or when quitted
    //private bool outGame = true;

    //Timer?




    public void Start()
    {
        UIController.UpdateScoreText(Score);
        UIController.UpdateLives(Lives);

        PauseGame();

        //outGame = true;

    }

    //private void Update()
    //{
    //    if (!isPaused && Input.GetKeyDown(KeyCode.Escape)) //&& !outGame)
    //    {
    //        PauseGame();
    //    }
    //    else if (isPaused && Input.anyKeyDown)      //GetKeyDown(KeyCode.Escape))   //Input.anyKeyDown  
    //    {
    //        //if (!outGame)
    //        //{
    //            UnpauseGame();
    //        //}
    //        //else
    //        //{
    //        //    Debug.Log("HEY!");
    //        //    //meta stuff. To be commented for a correct use
    //        //    UnpauseGame();
    //        //    UIController.ShowMetaDialogues();
    //        //}
  
    //    }
    //}

    public void AddScore(int _value)
    {
        Score += _value;
        UIController.UpdateScoreText(Score);
    }



    public void BallLost()
    {
        //reset pos
        Ball.transform.position = BallResetPosition;

        Vector3 currentVelocity = Ball.Velocity;
        currentVelocity.y = Mathf.Abs(currentVelocity.y);
        // Ball.Velocity.y = currentVelocity.y * Random.value;
        // Ball.Velocity.x = currentVelocity.x * Random.value;
        //randomizzare initial vel
        Ball.Velocity = currentVelocity;


        //Double hit on top wall bug
        Ball.lastObjectHit = null;


        //lose life
        Lives--;
        UIController.UpdateLives(Lives);
        if (Lives < 0)
        {
            GameOver();
        }

    }

    void GameOver()
    {
        UIController.ShowGameOver();
        isPlaying = false;
        PauseGame();
    }

    public void Winning()
    {
        UIController.ShowWinningPanel();
        isPlaying = false;
        PauseGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        //outGame = false;
        ResetGame();
        UnpauseGame();
    }
    void ResetGame()
    {
        Lives = InitialLives;
        Score = 0;
        //Double hit on top wall bug
        Ball.lastObjectHit = null;

        //reset ball and paddle pos & vel 
        Ball.transform.position = BallResetPosition;
        //Ball.Velocity.y = Mathf.Abs(Ball.Velocity.y);
        Ball.Velocity = Ball.InitialVelocity;
        Paddle.transform.position = PaddleResetPosition;


        //reset bricks former way
        //BlocksController.BlocksReset();
        //new way
        BlocksController.ResetBlocks();



        UIController.UpdateScoreText(Score);
        UIController.UpdateLives(Lives);
        UIController.HideStartGamePanel();
        UIController.HideGameOver();
        //
        UIController.HideWinningPanel();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
            //Debug.Log(outGame);

        if(isPlaying)
        {
            UIController.ShowPausePanel();
        }
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        UIController.HidePausePanel();
            //Debug.Log(outGame);
    }

    public void QuitGame()
    {
        isPlaying = false;
        //outGame = true;
        PauseGame();
        UIController.HideGameOver();
        UIController.HidePausePanel();
        //
        UIController.HideWinningPanel();
        UIController.ShowStartGamePanel();

        //Block reset former way
        //BlocksController.BlocksReset();
        //new way
        BlocksController.ResetBlocks();

        //Double hit on top wall bug
        Ball.lastObjectHit = null;
        //Ball initial vel reset
        Ball.Velocity = Ball.InitialVelocity;


        Ball.transform.position = BallResetPosition;
        Paddle.transform.position = PaddleResetPosition;
    }

}
