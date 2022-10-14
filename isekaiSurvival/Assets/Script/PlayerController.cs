using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Samplebank
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private Transform bulletPrefab;
        [SerializeField] private Transform playerRotate;
        [SerializeField] private GameObject gunfireEffect;
        [SerializeField] private PlayerAudioController playerAudio;


        private float playerSpeed = 5f;

        private Vector2 moveInput;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            HideGunfire();
        }

        private void FixedUpdate()
        {
            Move();

        }
        #region MOVEMENT
        private void OnMove(InputValue value)

        {
            moveInput = value.Get<Vector2>();
        }

        private void Move()
        {
            rb.velocity = moveInput * playerSpeed;
            
        }
        #endregion
        #region FIREGUN
        private void OnFire(InputValue value)
        {
            if (!value.isPressed) return;
            TryFire();
        }

        private void TryFire()
        {
            if (PauseController.paused) return;
            FireBullet();
        }

        private void FireBullet()
        {
            Instantiate(bulletPrefab, playerRotate.position, playerRotate.rotation);
            StartCoroutine(GunfiringEffect());
        }

        private void ShowGunfire() => gunfireEffect.SetActive(true);
        private void HideGunfire() => gunfireEffect.SetActive(false);
        private void BulletFireAudio() => playerAudio.BulletFireSound();

        public IEnumerator GunfiringEffect()
        {
            ShowGunfire();
            BulletFireAudio();
            yield return new WaitForSeconds(0.1f);
            HideGunfire();
        }
        #endregion

        #region PROCESS_DAMAGE

        public void PlayerDamagedAudio() => playerAudio.PlayerDamageSound();

        #endregion
    }
}