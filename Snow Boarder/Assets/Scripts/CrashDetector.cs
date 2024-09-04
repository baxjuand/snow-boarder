using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D headCollider;
    [SerializeField] float reloadDelay = 1f;

    void Start() 
    {
        headCollider = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Floor" && headCollider.IsTouching(other.collider))
        {
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene ()
    {
        SceneManager.LoadScene("Main");
    }
}
