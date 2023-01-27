using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy_SO : ScriptableObject
{
    [Header("Enemy Variable")]

    public GameObject enemyPrefab;

    public float enemySpeed;


}
