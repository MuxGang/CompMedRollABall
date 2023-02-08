using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI liveText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public Transform teleportTarget;
    public GameObject Player;

    private Rigidbody rb;
    private int count;
    public static int num;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        num = 3;
        SetCountText();
        SetLiveText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 20)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetLiveText()
    {
        liveText.text = "Lives: " + num.ToString();
        /*if(num<=0)
        {
            loseTextObject.SetActive(true);         //scene reloader
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }*/
    }
     
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            
            SetCountText();

            if(count==12)
            {
                Player.transform.position = teleportTarget.transform.position;  //go to second level
            }
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            num = num - 1;
            SetLiveText();
            if(num<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
