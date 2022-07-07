using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float mouseSens = 100f;
    public float moveSpeed = 12f;

    private GameObject _mainCamera;
    public CharacterController characterController;

    float xRotation = 0f;

    private Vector2 m_Look;
    private Vector2 m_Move;
    public bool cursorInputForLook = true;

    private void Awake()
    {
        if(_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Handle look
        float mouseX = m_Look.x * mouseSens * Time.deltaTime;
        float mouseY = m_Look.y * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        Vector3 inputDirection = new Vector3(m_Move.x, 0f, m_Move.y).normalized;
        inputDirection = transform.right * m_Move.x + transform.forward * m_Move.y;
        characterController.Move(inputDirection * moveSpeed * Time.deltaTime);

    }

    //Look input using Unity's new PlayerInput system
    public void OnLook(InputValue value)
    {
        if (cursorInputForLook)
        {
            m_Look = value.Get<Vector2>();
        }
    }
    //Move input using Unity's new PlayerInput system
    public void OnMove(InputValue value)
    {
        m_Move = value.Get<Vector2>();
    }
    public void LookInput(Vector2 newLookDirection)
    {
        m_Look = newLookDirection;
    }
}
