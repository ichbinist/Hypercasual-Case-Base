using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnObstacleDestroyed = new UnityEvent();
}