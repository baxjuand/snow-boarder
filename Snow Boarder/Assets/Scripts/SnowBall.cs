using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowBall : MonoBehaviour
{
    Transform transformComponent;
    bool isBallTouchingFloor;
    [SerializeField] Vector3 ballSize;
    void Start() 
    {
        transformComponent = GetComponent<Transform>();
    }

    void Update() 
    {
        if (isBallTouchingFloor)
        {
            transformComponent.transform.localScale += ballSize;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Floor")
        {
           isBallTouchingFloor = true;
        }
        else
        {
            isBallTouchingFloor = false;
        }

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
