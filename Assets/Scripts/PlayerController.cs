using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed;
    public float speedMulti;
    public float jumpHeight;
    public int gemsCollected;
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") && canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight));
            canJump = false;
        }
    }

    void FixedUpdate()
    {
        speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        GetComponent<Transform>().Translate(new Vector2(speed * speedMulti, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        if (collision.gameObject.CompareTag("KillBox"))
            GetComponent<Transform>().position = new Vector3(0, 0, 0);
        else if (collision.gameObject.CompareTag("Gem"))
        {
            gemsCollected++;
            Destroy(collision.gameObject);
        }

    }

}
