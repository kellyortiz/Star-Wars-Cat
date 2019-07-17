using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 5f;
    bool isStop, isDead;
    bool facingRight = true;
    Vector3 localScale;

    // coin
    public Text scoreText;
    public int score = 0;

    //life
    public int life = 4;
    public Text lifeText;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.W) && !isDead && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 500f);

        if (Input.GetKey(KeyCode.D))
            moveSpeed = 10f;
        else
            moveSpeed = 5f;

        SetAnimationState();

        if (!isDead)
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        if (!isStop)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void SetAnimationState()
    {
        if (dirX == 0) {
            anim.SetBool("isWalk", false);
        }

        if (rb.velocity.y == 0) {
            anim.SetBool("isWalk", false);
        }

        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
            anim.SetBool("isWalk", true);

        if (Mathf.Abs(dirX) == 10 && rb.velocity.y == 0)
            anim.SetBool("isWalk", true);
        else
            anim.SetBool("isWalk", false);

        if (rb.velocity.y > 0)
            anim.SetBool("isWalk", true);

        if (rb.velocity.y < 0) {
            anim.SetBool("isWalk", false);
        }
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.name.Equals("box") && life > 0)
        {
            anim.SetTrigger("isStop");
            StartCoroutine("Stop");
        }

        if (this.tag == "Player" && other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
        if (this.tag == "Player" && other.CompareTag("life"))
        {
            Destroy(other.gameObject);
            life++;
            lifeText.text = life.ToString();
        }
        if (this.tag == "Player" && other.CompareTag("object"))
        {
            score--;
            scoreText.text = score.ToString();
        }
        if (this.tag == "Player" && other.CompareTag("enemy"))
        {

            life--;
            lifeText.text = life.ToString();

        }
        if (this.tag == "Player" && other.CompareTag("objectLife"))
        {
            audioMagnet.PlaySound("spineSound");
            life--;
            lifeText.text = life.ToString();
        }
        if (this.tag == "Player" && other.CompareTag("objectWater"))
        {
            life--;
            lifeText.text = life.ToString();
        }
        if (life == 0)
        {
            anim.SetTrigger("isDead");
        dirX = 0;
        isDead = true;
        anim.SetTrigger("isWalk");
        SceneManager.LoadScene("Game Over");
        }
    }

    void OnCollisionEnter2D(Collision2D other2)
    {
        if (other2.gameObject.tag.Equals("objectLife"))
        {
            audioMagnet.PlaySound("spineSound");
        }
    }

    IEnumerator Stop()
    {
        isStop = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isStop = false;
    }
       

    }
