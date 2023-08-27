using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRewardController : MonoBehaviour
{
    [FoldoutGroup("Obstacle Reward Settings")]
    public int RewardCount = 0;
    [FoldoutGroup("Obstacle Reward Settings")]
    public GameObject RewardPrefab;
    [FoldoutGroup("Obstacle Reward Settings")]
    public Transform RewardPrefabHolder;

    [FoldoutGroup("Obstacle Reward Settings/Reward Positioning")]
    public float RewardStartHeight = 3.75f;
    [FoldoutGroup("Obstacle Reward Settings/Reward Positioning")]
    public float RewardHeightIncrement = 0.19f;

    [FoldoutGroup("Obstacle Reward Settings/Debug")]
    [ReadOnly]
    public List<GameObject> Rewards = new List<GameObject>();
    
    private void OnEnable()
    {
        InitializeRewards();
    }

    private void InitializeRewards()
    {
        for (int i = 0; i < RewardCount; i++)
        {
            GameObject localReward = Instantiate(RewardPrefab, RewardPrefabHolder);
            localReward.transform.localPosition = Vector3.up * RewardStartHeight + Vector3.up * RewardHeightIncrement * i;
            Rewards.Add(localReward);
        }
    }
}