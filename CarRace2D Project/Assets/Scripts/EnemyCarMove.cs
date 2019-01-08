using UnityEngine;

public class EnemyCarMove : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 1f, 0) * speed * Time.deltaTime);
	}
}
