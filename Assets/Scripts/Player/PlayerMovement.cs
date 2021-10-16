using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    private Animator animator;
    private PlayerStats playerStats;
    private CharacterController controller;
    private float inputHorizontal;
    private float inputVertical;

    #endregion

    #region Methods

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UserInput();
        Move();
        PlayMoveAnimation();
    }

    private void UserInput()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector3 moveDirection = transform.right * inputHorizontal + transform.forward * inputVertical;
        if (Mathf.Sqrt(Mathf.Pow(moveDirection.x, 2) + Mathf.Pow(moveDirection.z, 2)) > 1)  // fix increase speed when walking diagonally
            moveDirection.Normalize();

        controller.Move(moveDirection * playerStats.MoveSpeed * Time.deltaTime);
    }

    private void PlayMoveAnimation()
    {
        string animName = ChooseSuitableAnimation();
        animator.Play(animName);
    }

    private string ChooseSuitableAnimation()
    {
        if (inputHorizontal > 0)
            return "RunRight";
        if (inputHorizontal < 0)
            return "RunLeft";
        if (inputVertical > 0)
            return "RunFWD";
        if (inputVertical < 0)
            return "RunBWD";

        return "Idle";
    }

    #endregion
}
