using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    public BallMovement _ballMovement;
    public ScoreController _scoreController;
    bool _isPlayer1;


    private void BounceFromRocket(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 RocketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float x;
        if(c.gameObject.name == "Player1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (ballPosition.y - RocketPosition.y) / racketHeight;

        _ballMovement.IncreaseHitCoutner();
        _ballMovement.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player1" || other.gameObject.name == "Player2")
        {
            this.BounceFromRocket(other);
        }
        else if(other.gameObject.name == "WallLeft")
        {
            _isPlayer1 = false;
            _scoreController.GoalPlayer(_isPlayer1);
        }
        else if(other.gameObject.name == "WallRight")
        {
            _isPlayer1 = true;
            _scoreController.GoalPlayer(_isPlayer1);
        }

    }
}
