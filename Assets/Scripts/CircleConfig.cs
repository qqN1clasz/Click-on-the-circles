using System;
using UnityEngine;

[Serializable] 
public class CircleConfig
{
    [SerializeField] private Circle _prefab;
    [SerializeField, Range(2,6)] private int _killValue;

    public Circle Prefab => _prefab;
    public int KillValue => _killValue;
}
