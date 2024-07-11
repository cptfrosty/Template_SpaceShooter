using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Используется паттерн - Пулинг объектов (Object Pool)*/

[SelectionBase]
public class PlayerLogic : MonoBehaviour
{
    [Header("Настройки игрока")]
    [Tooltip("Скорость игрока")]
    [SerializeField] private float _playerSpeed = 60;
    [Tooltip("Перезарядка оружия")]
    [SerializeField] private float _shootingCooldown = 0.5f;
    [Tooltip("Префаб пуль")]
    [SerializeField] private Bullet _prefabBullet;

    [Header("Ограничение движения")]
    [Tooltip("Ограничение движения по X")]
    [SerializeField] private float _maxXDistance = 30;

    [Header("Пулинг объектов")]
    [SerializeField] private int _countBullets = 20;

    private bool _isShooting = true;
    private List<Bullet> _bullets;

    public void Init()
    {
        InitBulletObjectPool();
    }

    public void Begin()
    {
        StartCoroutine(ShootTimer());
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void InitBulletObjectPool()
    {
        _bullets = new List<Bullet>();
        for (int i = 0; i < _countBullets; i++)
        {
            Bullet bullet = Instantiate(_prefabBullet);
            _bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }
    }

    private void PlayerMovement()
    {
        float axisHorizontal = Input.GetAxisRaw("Horizontal");
        if (axisHorizontal < 0 && transform.position.x >= -_maxXDistance) transform.Translate(-_playerSpeed * Time.deltaTime, 0, 0);
        else if (axisHorizontal > 0 && transform.position.x <= _maxXDistance) transform.Translate(_playerSpeed * Time.deltaTime, 0, 0);
    }

    private IEnumerator ShootTimer()
    {
        while (_isShooting)
        {
            yield return new WaitForSeconds(_shootingCooldown);
            Shoot();
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].gameObject.activeSelf)
            {
                _bullets[i].gameObject.SetActive(true);
                _bullets[i].transform.position = transform.position;
                break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
