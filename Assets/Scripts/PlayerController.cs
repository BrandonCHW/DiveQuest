using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public Camera MainCamera;
    public Transform PlayerTransform;

    // player movement constants
    [SerializeField] private const float MOVE_SPEED_BASE = 1.0f;
    [SerializeField]
    private float _moveSpeed = 1.0f;

    // input properties
    private uint clicks = 0;
    private float clickTime = 0f;
    private float clickDelay = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        if (isDoubleClick())
        {
            _moveSpeed = MOVE_SPEED_BASE * 2;
        }
        // left mouse click
        if (Input.GetMouseButton(0))
        {
            var mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            PlayerTransform.position =
                Vector2.MoveTowards(PlayerTransform.position, mousePos, Time.deltaTime * _moveSpeed);

        }

        if (Input.GetMouseButtonUp(0))
        {
            _moveSpeed = MOVE_SPEED_BASE;
        }
    }

    private bool isDoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicks++;
            if (clicks == 1)
            {
                clickTime = Time.time;
            }
        }
        if (clicks > 1 && Time.time - clickTime < clickDelay)
        {
            clicks = 0;
            clickTime = 0;
            return true;
        }
        if (clicks > 2 || Time.time - clickTime > 1)
        {
            clicks = 0;
        }
        return false;
    }
    
}
