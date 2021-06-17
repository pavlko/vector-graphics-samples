using UnityEngine;

public class Debug_CameraMovement : MonoBehaviour
{
    public int MoveSpeed = 4;

    public float LookSpeedH = 2.0f;
    public float LookSpeedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * MoveSpeed;
        float zAxisValue = Input.GetAxis("Vertical") * MoveSpeed;
        float yValue = 0.0f;

        if (Input.GetKey(KeyCode.Q))
        {
            yValue = -MoveSpeed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            yValue = MoveSpeed;
        }

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + yValue, transform.position.z + zAxisValue);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            yaw += LookSpeedH * Input.GetAxis("Mouse X");
            pitch -= LookSpeedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}