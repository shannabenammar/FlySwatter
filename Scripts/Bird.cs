using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDead = false;
    Rigidbody2D rigidbody2d;
    Animator animator;
    private float UpForce = 200f;
    [SerializeField]
    // private string nextlevel;
    public GameObject wonPanel;
    public Transform target;
    Camera camera;
    private float minX, maxX, minY, maxY;



    void Start()
    {
        wonPanel.SetActive(false);
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        camera = GetComponent<Camera>();

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        //setting boundaries for sprite in the scene
        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))

            {
                rigidbody2d.velocity = Vector2.zero;
                rigidbody2d.AddForce(new Vector2(0, UpForce));
                animator.SetTrigger("Flap");
                MusicController.instance.BirdFlySound();
            }
            // Get current position
            Vector3 pos = transform.position;

            // Horizontal contraint
            if (pos.x < minX) pos.x = minX;
            if (pos.x > maxX) pos.x = maxX;

            // vertical contraint
            if (pos.y < minY) pos.y = minY;
            if (pos.y > maxY) pos.y = maxY;

            // Update position
            transform.position = pos;
        }
    }

   void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Finish")
        {
            Invoke("FinishGame", 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        isDead = true;
        animator.SetTrigger("Die");
        MusicController.instance.BirdDiedSound();
        Invoke("Birddie", 1f);
    }

    void Birddie()
    {
        FlappyGameController.instance.BirdDied();
    }

    void FinishGame()
    {
        isDead = true;
        animator.SetTrigger("Die");
        wonPanel.SetActive(true);
    }
}
