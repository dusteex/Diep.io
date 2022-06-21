//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private Transform _gunRotatePivot;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private PlayerInputObserver _userInputObserver;
    [Header("ShootingValues")]
    [SerializeField] private float _damage;
    [SerializeField] private float _reloadTime;

    private float _lastShootTime;
    private Camera _mainCamera;

    private void OnEnable()
    {
        _userInputObserver.onShootInput += Shoot;
    }
    private void OnDisable()
    {
        _userInputObserver.onShootInput -= Shoot;
    }

    private void Start()
    {
        _lastShootTime = -_reloadTime; // To get possibility of shooting right after start the game
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        RotateGun(_gunRotatePivot);
    }

    #region Rotation

    private void RotateGun(Transform gunRotatePivot)
    {
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float angle = CalculateAngle(gunRotatePivot.position , mouseWorldPosition);
        gunRotatePivot.eulerAngles = new Vector3(0,0,angle-90);
    }

    private float CalculateAngle(Vector3 centerPosition , Vector3 targetPosition)
    {
        Vector3 mouseVector = targetPosition-centerPosition;
        float angle = Mathf.Atan2(mouseVector.y,mouseVector.x) * Mathf.Rad2Deg;
        return angle;
    }

    #endregion
    #region Shooting

    private void Shoot()
    {
        if(CheckReload(ref _lastShootTime , _reloadTime) == false) return;
        Bullet newBullet = Instantiate(_bulletPrefab,_bulletSpawnPoint.position,Quaternion.identity);
        newBullet.Init(_damage,_gunRotatePivot.gameObject);
    }

    private bool CheckReload(ref float lastShootTime, float reloadTime)
    {
        if(lastShootTime + reloadTime < Time.time)
        {
            lastShootTime = Time.time;
            return true;
        }
        return false;
    }

    #endregion
}
