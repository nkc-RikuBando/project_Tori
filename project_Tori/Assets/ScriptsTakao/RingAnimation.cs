using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppearAnimstion()
    {
        animator.SetBool("isAppear", true);
    }

    public void DisappearAnimation()
    {
        animator.SetBool("isAppear", false);
    }

    public void PassingAnimation()
    {
        animator.SetBool("isPassing", true);
    }

}
