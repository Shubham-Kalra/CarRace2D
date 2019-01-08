﻿using UnityEngine;

public class CarSpawnner : MonoBehaviour {

    public GameObject[] cars;
    int carNo;
    public float maxPos = 2.2f;
    public float delayTimer = 0.5f;
    float timer;

	// Use this for initialization
	void Start () {
        timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector2 carPos = new Vector2(Random.Range(-maxPos, maxPos), transform.position.y);
            carNo = Random.Range(0, 5);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTimer;
        }
    }
}
