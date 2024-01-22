using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickTime = 0;
    float maxComboDelay = 1;
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Swing 1"))
        {
            anim.SetBool("Sword Swing 1", false);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Swing 2"))
        {
            anim.SetBool("Sword Swing 2", false);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Swing 3"))
        {
            anim.SetBool("Sword Swing 3", false);
            noOfClicks = 0;
        }
        
        if(Time.time - lastClickTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if(Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
    
    }

    void OnClick()
    {
        lastClickTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            anim.SetBool("Sword Swing 1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if(noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Swing 1"))
        {
            anim.SetBool("Sword Swing 1", false);
            anim.SetBool("Sword Swing 2", true);
        }


        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Sword Swing 2"))
        {
            anim.SetBool("Sword Swing 2", false);
            anim.SetBool("Sword Swing 3", true);
        }








    }









}
