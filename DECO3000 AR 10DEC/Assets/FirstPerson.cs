using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour {
    bool isLocked;


    public float movementSpeed = 6.0f;
    public float mouseSensitivity = 3.0f;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;

    // Use this for initialization
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        SetCursorLock(true);
    }

    void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        if (this.isLocked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorLock(false);
        }

        //mouse movement
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //player movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;
        CharacterController cc = GetComponent<CharacterController>();
        cc.SimpleMove(speed);
    }
}
