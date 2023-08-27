using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InputManager : Singleton<InputManager>
{
    [FoldoutGroup("Input Manager Settings")]
    [FoldoutGroup("Input Manager Settings/Swerve Settings")]
    public float SwerveSpeed;

    [FoldoutGroup("Input Manager Settings")]
    [FoldoutGroup("Input Manager Settings/Tap Debug")]
    [ReadOnly]
    public Vector3 FirstTouchPosition;

    [FoldoutGroup("Input Manager Settings")]
    [FoldoutGroup("Input Manager Settings/Tap Debug")]
    [ReadOnly]
    public Vector3 LastTouchPosition;

    private void FixedUpdate()
    {
        SetTouchPositions();
    }

    #region Tap
    private void SetTouchPositions()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                FirstTouchPosition = touch.position;
                LastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                LastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                LastTouchPosition = touch.position;
            }
        }
    }
    #endregion

    #region Swerve
    public Vector2 GetSwerveAmount()
    {
        Vector2 ScreenSwerveAmount = Input.mousePosition - InputManager.Instance.FirstTouchPosition;

        Vector2 UnclampedWorldSwerveAmount = ScreenSwerveAmount / Screen.width;

        Vector2 ClampedSwerveAmount = new Vector2(UnclampedWorldSwerveAmount.x * SwerveSpeed, 0f);

        return ClampedSwerveAmount;
    }
    #endregion
}
