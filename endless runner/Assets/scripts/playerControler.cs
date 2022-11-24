using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler: MonoBehaviour
{
    [SerializeField]private CharacterController controller;
    [SerializeField] private Vector3 direction;
    //[SerializeField]private bool groundedPlayer;
    [SerializeField]private float playerSpeed = 2.0f;
    [SerializeField] private int currentlane = 0;
    [SerializeField] private float laneChangeDistance = 1f;

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
        direction = new Vector3(0, 0, 1);
    }

    void Update()
    {

        Vector3 move = direction;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveleft();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight();
        }

    }

    public void moveleft()
    {
        if (currentlane == 0)
        {
            controller.enabled = false;
            Vector3 position = this.transform.position;
            position.x = -laneChangeDistance;
            currentlane = -1;
            this.transform.position = position;
            controller.enabled = true;

        }

        else if (currentlane == 1)
        {
            controller.enabled = false;
            Vector3 position = this.transform.position;
            position.x = -0.02f;
            currentlane = 0;
            this.transform.position = position;
            controller.enabled = true;

        }

    }
    public void moveRight()
    {
        if (currentlane == 0)
        {
            controller.enabled = false;
            Vector3 position = this.transform.position;
            position.x = laneChangeDistance;
            currentlane = 1;
            this.transform.position = position;
            controller.enabled = true;

        }

        else if (currentlane == -1)
        {
            controller.enabled = false;
            Vector3 position = this.transform.position;
            position.x = -0.02f;
            this.transform.position = position;
            controller.enabled = true;
            currentlane = 0;
        }
    }
}

