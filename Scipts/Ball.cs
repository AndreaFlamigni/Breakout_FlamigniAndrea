using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //public due to bug, see GController #64
    public GameObject lastObjectHit;
    CircleCollider2D circleCollider;

    //for reset ball vel
    public Vector2 InitialVelocity = new Vector2(4, 4);
    public Vector2 Velocity;

    GameController gameController;

    public AudioClip OnWallHitAudio;
    public AudioClip OnPaddleHitAudio;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        gameController = FindObjectOfType<GameController>();
    }

    public void Start()
    {
        Velocity = InitialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Velocity * Time.deltaTime);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, circleCollider.radius, Velocity, (Velocity * Time.deltaTime).magnitude);
        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider != circleCollider && hit.transform.gameObject != lastObjectHit)
            {
                lastObjectHit = hit.transform.gameObject;
                //Debug.Log(lastObjectHit);
                Velocity = Vector2.Reflect(Velocity, hit.normal);

                if (hit.transform.GetComponent<Paddle>())
                {
                    Velocity.y = Mathf.Abs(Velocity.y);
                    gameController.AudioController.PlayClip(OnPaddleHitAudio);
                }

                if (hit.transform.GetComponent<Block>())
                {
                    hit.transform.GetComponent<Block>().OnHit();
                }

                gameController.AudioController.PlayClip(OnWallHitAudio);
            }
        }

        if (transform.position.y < -Camera.main.orthographicSize)
        {
            //Debug.Log("Ball morta");
            gameController.BallLost();
        }
    }
}
