using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bird : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 12.0f;
    private bool levelStart;
    private Animator animator;

    public GameObject gameController;
    private int score;
    public Text scoreText;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        levelStart = false;
        rb.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!levelStart)
            {
                levelStart = true;
                rb.gravityScale = 3;
                gameController.GetComponent<PipeGenerator>().enableGenratePipe = true;
            }
            BirdMoveup();
        }

        // Cập nhật trạng thái animation
        animator.SetBool("isFlying", rb.velocity.y > 0);
    }

    private void BirdMoveup()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReloadScene();
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("plappy bird");
    }
}