﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {
    public AnimationClip replaceableAtackAnim;
    public AnimationClip[] defaultAttackAnimationSet;
    protected AnimationClip[] currentAttackAnimSet;
    const float locomotionAnimationSmoothTime = .1f;
    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    public AnimatorOverrideController overrideController;
	// Use this for initialization
	protected virtual void  Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        if(overrideController == null)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        
        animator.runtimeAnimatorController = overrideController;
        currentAttackAnimSet = defaultAttackAnimationSet;
        combat.OnAttack += OnAttack;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        float speedPercent = agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);

        animator.SetBool("inCombat", combat.InCombat);
	}

    protected virtual void OnAttack()
    {
        animator.SetTrigger("Attack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideController[replaceableAtackAnim.name] = currentAttackAnimSet[attackIndex];
    }
}
