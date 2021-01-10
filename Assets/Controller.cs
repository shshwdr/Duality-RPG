using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Move ball1;

    public Move ball2;

    Rigidbody2D ball1R;
    Rigidbody2D ball2R;

    public AudioClip toggleClip;
    public AudioClip failedClip;
    public AudioClip iceClip;

    AudioSource audioSource;

    bool isBall1Active;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isBall1Active = ball1.isActive;
        ball1R = ball1.GetComponent<Rigidbody2D>();

        ball2R = ball2.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllUI.Instance.life == 0)
        {
            //game over
            return;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Vector2 previousVelocity = -(isBall1Active ? ball1.previousVelocity() : ball2.previousVelocity())/2;

            Move activeBall = isBall1Active ? ball1 : ball2;
            int collideResult = activeBall.CanToggle();
            if (collideResult > 0)
            {
                if (collideResult == 1)
                {

                    audioSource.PlayOneShot(toggleClip);
                }
                else
                {
                    audioSource.PlayOneShot(iceClip);

                }


                ball1.toggleActive();
                ball2.toggleActive();
                isBall1Active = !isBall1Active;

                if (isBall1Active)
                {
                    ball1.setVelocity(previousVelocity);

                }
                else
                {
                    ball2.setVelocity(previousVelocity);
                }
            }
            else
            {
                //show failed image
                audioSource.PlayOneShot(failedClip);
            }
        }
    }
}
