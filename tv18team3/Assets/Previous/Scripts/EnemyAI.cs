﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class EnemyAI : MonoBehaviour {

	private Transform target;
	private Vector3 dest;
	private NavMeshAgent agent;

	private PlayerCondition pc;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
		agent = GetComponent<NavMeshAgent> ();
		dest = agent.destination;

		pc = GameObject.Find ("Player").GetComponent<PlayerCondition> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (dest, target.position) < 10.0f) {
			dest = target.position;
			agent.destination = dest;
			this.pc.stalkerFollowing ();
		}
	}
}
