using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrail;
    [SerializeField] AudioClip snowBoardingSFX;
    CapsuleCollider2D snowboardCollider;

    // Start is called before the first frame update
    void Start() 
    {
        snowboardCollider = GetComponent<CapsuleCollider2D>();    
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Floor" && snowboardCollider.IsTouching(other.collider))
        {
            snowTrail.Play();
            GetComponent<AudioSource>().PlayOneShot(snowBoardingSFX);
        }    
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Floor")
        {
            snowTrail.Stop();
        }
    }
}
