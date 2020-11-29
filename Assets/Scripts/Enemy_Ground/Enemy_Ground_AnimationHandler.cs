using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ground_AnimationHandler : MonoBehaviour
{
    [SerializeField] Animator crabAnimator = null;
    // Start is called before the first frame update
    void Start()
    {
        if (crabAnimator == null)
        {
            crabAnimator = gameObject.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        crabAnimator.Play("Crab_Walk");
    }
}
