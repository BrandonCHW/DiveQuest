using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField]
    private float _moveSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // finger touch
        if (Input.touchCount > 0)
        {
            
        }
        // left mouse click
        else if (Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerTransform.position =
                Vector2.MoveTowards(playerTransform.position, mousePos, Time.deltaTime * _moveSpeed);

        }
    }
    
}
