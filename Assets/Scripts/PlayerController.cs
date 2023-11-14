using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameActive)
            return;
            
        //set input values
        bool isPressingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isPressingRight = Input.GetKey(KeyCode.RightArrow);

        //abort if no key pressed or both right and left
        if (isPressingLeft == isPressingRight)
            return;

        //move player
        float movement = speed * Time.deltaTime;

        if (isPressingLeft)
            movement *= -1f;

        transform.position += new Vector3(movement, 0, 0);

        //limit player boundaries
        float movementLimit = (GameManager.Instance.gameWidth / 2)-1;
        if (gameObject.transform.position.x < -movementLimit)
            transform.position = new Vector3(-movementLimit, transform.position.y, transform.position.z);
        else if (gameObject.transform.position.x > movementLimit)
            transform.position = new Vector3(movementLimit, transform.position.y, transform.position.z);;

 
    }
}