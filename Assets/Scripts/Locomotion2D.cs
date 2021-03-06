﻿using UnityEngine;
using System.Collections;

public class Locomotion2D {

	private Animator _animator = null;
	private int _speedId = 0;
	private int _jumpId = 0;
	private int _castId = 0;

	// Use this for initialization
	public Locomotion2D(Animator animator) {
		_animator = animator;
		_speedId = Animator.StringToHash("Speed");
		_jumpId = Animator.StringToHash("Jump");
		_castId = Animator.StringToHash("CastSpell");
	}

	public void Update (bool jump, float speed) {
		_animator.SetFloat (_speedId, speed);
		AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
		if (jump && !state.IsName ("Jump")) {
			_animator.SetBool (_jumpId, true);
		} else if (state.IsName ("Jump")) {
			_animator.SetBool (_jumpId, false);
		} else if (state.IsName ("CastingSpell")) {
			_animator.SetBool (_castId, false);
		}
	}

	public void CastSpell() {
		_animator.SetBool (_castId, true);
	}
}
