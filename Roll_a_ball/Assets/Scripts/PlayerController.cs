using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text life;
    public Text lose;

    private Rigidbody rb;
    private int count;
    private int Life;
  

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Life = 3;
        SetCountText();
        setlife();
        winText.text = "";
        lose.text = "";
      
    }

    private void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }
    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            setlife();

        }
       else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I hit an enemy");
            Life--;
            setlife();
            other.gameObject.SetActive(false);
        }
       if (count == 16)
        {
            transform.position = new Vector3(18.63f, 13.75f, -128.5f);
        }
    }

 

    void SetCountText ()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 33)
        {
            winText.text = "CONGRATS YOU WIN!";
            Time.timeScale = 0f;
        }
    }

    void setlife ()
    {
        life.text = "Lives:" + Life.ToString();
        if(Life <= 0)
        {
            lose.text = "You're a LOSER!!";
            Time.timeScale = 0f;

        }
    }

}


