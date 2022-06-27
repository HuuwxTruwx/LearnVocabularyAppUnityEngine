using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    float horizontal;
    public float speed;
    Vector3 move;
    public QuestionScript question;
  
    
    // Start is called before the first frame update
    void Start()
    {
        question.SelectQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = transform.position.y;
            touchPosition.z = transform.position.z;
            transform.position = touchPosition;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        move = new Vector3 (horizontal*speed, 0, 0);
        transform.position = transform.position + move;
           
    }
   
}
