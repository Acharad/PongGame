using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float extraSpeedPerHit;
    [SerializeField] float maxExtraSpeed;

    int hitCounter = 0;

    private void Start()
    {
        StartCoroutine(StartBall());
    }

    private void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if(isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);

        this.hitCounter = 0;
        yield return new WaitForSeconds(1);
        if(isStartingPlayer1)
            this.MoveBall(new Vector2(-1, 0));
        else
            this.MoveBall(new Vector2(1, 0));
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        Rigidbody2D _rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>(); 

        _rigidBody2D.velocity = dir * speed;
    }

    public void IncreaseHitCoutner()
    {
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }
}
