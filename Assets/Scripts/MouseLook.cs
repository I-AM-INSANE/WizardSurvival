using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Fields

    [SerializeField] private float mouseSensitivity = 50f;

    private Transform player;
    private float xRotation = 0;

    #endregion

    #region Methods

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;
        Aim(mouseX, mouseY);
    }

    private void Aim(float mouseX, float mouseY)
    {
        if (mouseX == 0 && mouseY == 0)
            return;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10f, 25f);

        transform.localRotation = Quaternion.Euler(transform.rotation.x + xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }

    #endregion
}
