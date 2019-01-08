using UnityEngine;
//using UnityEngine.UI;

public class CarController : MonoBehaviour {

    public float carSpeed;
    public float maxPos = 2.2f;
    public UIManager ui;

    Vector2 position;

    public AudioManager am;

    bool currentPlatformAndroid = false;

    //float middle;

    Rigidbody2D rb;

    //public Button Left;
    //public Button Right;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        #if UNITY_ANDROID
            currentPlatformAndroid = true;
        #else
            currentPlatformAndroid = false;
        #endif
    }

    // Use this for initialization
    void Start () {
        //ui = GetComponent<UIManager>();
        position = transform.position;

        am.carAcc.Play();

        if (currentPlatformAndroid)
            Debug.Log("Android");
        else
            Debug.Log("Windows");
	}
	
	// Update is called once per frame
	void Update () {
        if (currentPlatformAndroid == true)
        {
            //middle = gameObject.transform.position.x;
            //TouchMove();
            AccelerometerMove();

        }
        else
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            //position.x = Mathf.Clamp(position.x, -maxPos, maxPos + 0.02f);
            //position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

            //transform.position = position;
        }
        position = transform.position;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos + 0.02f);
        //position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            ui.GameOverActivated();
            am.carAcc.Stop();
        }  
    }

    public void moveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void moveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void setVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }

    void TouchMove()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            
            if(touch.position.x < middle && touch.phase == TouchPhase.Stationary)
            {
                moveLeft();
            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Stationary)
            {
                moveRight();
            }
            else
            {
                setVelocityZero();
            }
        }
    }

    void AccelerometerMove()
    {
        float x = Input.acceleration.x;
        //Debug.Log(x);

        if(x < -0.1f)
        {
            moveLeft();
        }
        else if(x > 0.1f)
        {
            moveRight();
;       }
        else
        {
            setVelocityZero();
        }
    }
}
