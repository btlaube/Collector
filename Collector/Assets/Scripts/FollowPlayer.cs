using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float followDistance;
    public float speed;
    public Transform player;
    private float distance;
    public float range;
    private bool outOfRange;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    Vector2 target;

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {

        distance = transform.position.x - player.transform.position.x;
        
        target.x = player.position.x - transform.position.x;

        if (Mathf.Abs(distance) >= range) {
            outOfRange = true;            
        }
        else if (Mathf.Abs(distance) <= followDistance) {
            outOfRange = false;
        }

        //Vector2 direction = player.position - transform.position;
        //if (direction.x < 0) {
        //    GameObject.FindGameObjectWithTag("childAnimator").GetComponent<Animator>().SetFloat("Horizontal", 1);
        //}
        //else {
        //    GameObject.FindGameObjectWithTag("childAnimator").GetComponent<Animator>().SetFloat("Horizontal", 0);
        //}
    }

    private void FixedUpdate() {
        if (outOfRange) {
            moveCharacter(target);
        }
    }
    
    void moveCharacter(Vector2 direction){
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
