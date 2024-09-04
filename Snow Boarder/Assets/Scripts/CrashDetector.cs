using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D headCollider;
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem headCrashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed;

    void Start() 
    {
        headCollider = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Floor" && headCollider.IsTouching(other.collider) && !hasCrashed)
        {
            
            FindObjectOfType<PlayerController>().DisableControls();
            headCrashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            hasCrashed = true;
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene ()
    {
        SceneManager.LoadScene("Main");
        hasCrashed = false;
    }
}
