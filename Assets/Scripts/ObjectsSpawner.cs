﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour {

	public List<GameObject> objects = new List<GameObject>();
	public Vector2[] positions; 
    public float firstInvokeTime = 0;
    public float newX;
    public float minTime = 1.2f;
    public float maxTime = 5f;
    public bool randomVariance = false;
    public float minPosRandom = 5;
    public float maxPosRandom = 5;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", firstInvokeTime, Random.Range(minTime, maxTime));
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.instance.gameSpeed == 0){
			CancelInvoke();
		}
    }

    void Spawn()
    {
		float chance = Random.Range(0f, 1f);
		if(chance < 0.1f){
			Instantiate(objects[0], positions[Random.Range(0, positions.Length)], this.transform.rotation);
		}else{
			Instantiate(objects[Random.Range(1, objects.Count)], positions[Random.Range(0, positions.Length)], this.transform.rotation);
		}
		
	}
}