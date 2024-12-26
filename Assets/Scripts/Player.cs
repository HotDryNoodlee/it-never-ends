using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float movespeed = 6f;
    public float flyforce = 5f;
    public Animator anim;
    public Transform groundcheck;
    public LayerMask whatisboundry;
    public float groundcheckdistanceup = 0.55f;
    public float groundcheckdistancedown = 0.9f;
    public GameObject enemy1;
    public GameObject enemy2;
    public float powers = 50;
    public float scores = 0;
    public GameObject power;
    public Text scoretext;
    void Start()
    {
        int layerIndex = LayerMask.NameToLayer("boundry");
        whatisboundry.value = 1 << layerIndex;
        groundcheck = GameObject.Find("groundcheck").transform;
        rb = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        enemy1 = GameObject.Find("enemy1");
        enemy2 = GameObject.Find("enemy2");
        power = GameObject.Find("power");
        scoretext = GameObject.Find("scores").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movespeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(movespeed, flyforce);
        }
        anim.SetFloat("yVelocity", rb.velocity.y);
        powers = powers - Time.deltaTime;
        if (iswalldetected() || powers < 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            //Debug.Log("gameover");
        }
        scores += Time.deltaTime;
        scoretext.text = "分数：" + scores + "\n" + "能量：" + powers;
    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundcheck.position, new Vector2(groundcheck.position.x, groundcheck.position.y - groundcheckdistancedown));
        Gizmos.DrawLine(groundcheck.position, new Vector2(groundcheck.position.x, groundcheck.position.y + groundcheckdistanceup));
    }

    public bool iswalldetected()
    {
        return Physics2D.Raycast(groundcheck.position, Vector2.up, groundcheckdistanceup, whatisboundry) || Physics2D.Raycast(groundcheck.position, Vector2.down, groundcheckdistancedown, whatisboundry);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == power)
        {
            powers += 15;
            power.transform.position = new Vector2(power.transform.position.x + Random.Range(20, 25), power.transform.position.y);
        } else if(collision.gameObject == enemy1 || collision.gameObject == enemy2)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            //Debug.Log("game over");
        }
    }
}

