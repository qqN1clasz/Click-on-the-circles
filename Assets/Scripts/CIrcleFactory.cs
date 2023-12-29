using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CircleFactory", menuName = "Factory/CircleFactory")]
public class CircleFactory : ScriptableObject
{
    [SerializeField] private CircleConfig _small, _medium, _big;

    public Circle GetCircle(CircleType type)
    {
        CircleConfig config = GetType(type);
        Circle circle = Instantiate(config.Prefab);
        circle.Initialize(config.KillValue);

        return circle;
    }

    private CircleConfig GetType(CircleType type)
    {
        switch (type)
        {
            case CircleType.Small:
                return _small;

            case CircleType.Medium:
                return _medium;

            case CircleType.Big:
                return _big;

            default: throw new ArgumentException(nameof(type));
        }
    }
}
