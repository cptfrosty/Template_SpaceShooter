using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 60f;
    [SerializeField] private float _lifeTimeSec = 3f;

    private float timer = 0f;

    private void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        Move();
        LifeTime();
    }

    private void Move()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    private void LifeTime()
    {
        timer += Time.deltaTime;

        if (timer >= _lifeTimeSec)
        {
            gameObject.SetActive(false);
        }
    }
}
