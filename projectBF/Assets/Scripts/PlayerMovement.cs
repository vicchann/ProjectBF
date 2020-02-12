using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    private Vector2 direction;
    // private Animator animator;

    // void start(){animator = GetComponent<Animator>();}

    void Update()
    {
        TakeInput();
        Move();
    }

	private void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
	}

    private void TakeInput() {

        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            // animator.Play("playerRight");
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
}
