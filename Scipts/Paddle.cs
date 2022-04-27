using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float MoveSpeed;

    public GameObject BulletPrefab;
    float fireRate = 0.3f;
    public float fireDuration;

    GameObject ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>().gameObject;
    }

    public void Move(Vector2 _direction)
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        GameObject.Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        fireDuration = fireRate;
    }

}
