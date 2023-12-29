using System.Collections;
using UnityEngine;
using System;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawns;
    [SerializeField] private GameTimer _timer;
    [SerializeField] private CircleFactory _circleFactory;
    [SerializeField] private float _posY;
    [SerializeField] private float _posX;

    public void Start()
    { 
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (!_timer.Ended)
        {
            Circle circle = _circleFactory.GetCircle((CircleType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CircleType)).Length));
            circle.transform.position = new Vector2(UnityEngine.Random.Range(-_posX, _posX), UnityEngine.Random.Range(-_posY, _posY));
            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
    }
}
