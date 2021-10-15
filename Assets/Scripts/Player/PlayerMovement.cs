using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    private PlayerStats playerStats;
    private CharacterController controller;

    #endregion

    #region Methods

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        if (Mathf.Sqrt(Mathf.Pow(moveDirection.x, 2) + Mathf.Pow(moveDirection.z, 2)) > 1)  // fix increase speed when walking diagonally
            moveDirection.Normalize();

        controller.Move(moveDirection * playerStats.MoveSpeed * Time.deltaTime);
    }



    #endregion
}
