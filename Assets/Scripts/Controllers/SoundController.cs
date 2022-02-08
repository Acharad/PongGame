using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource _wallSound;
    [SerializeField] AudioSource _racketSound;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player1" || other.gameObject.name == "Player2")
        {
            _racketSound.Play();
        }
        else
        {
            _wallSound.Play();
        }
    }
}
