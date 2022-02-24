using Cysharp.Threading.Tasks;
using DG.Tweening;
using NaughtyAttributes;
using SE.Game.Core;
using SE.Game.Data;
using SE.Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SE.Game
{
    public partial class ShipBehaviour : MonoBehaviour, IShip
    {
        [Header("PROPERTIES")]
        [ReadOnly, HideInInspector] public Ship shipData;

        [SerializeField] private const float _SMOOTHNESS = 0.3f;
        [SerializeField] private Transform backfireOriginPos = null;

        private async void Start()
        {
            
        }
        private void Update()
        {
            Move();

            if (Input.GetKey(KeyCode.X))
                ObjectPooler.Instance.GetPooledObject("Test");
        }

        public async UniTask Init()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (shipData.shipSprites.BackFirePrefab != null)
            {
                var backfire = GameObject.Instantiate(shipData.shipSprites.BackFirePrefab, backfireOriginPos);
                backfire.transform.SetParent(backfireOriginPos);
            }
            await UniTask.Yield();
        }

        public void Ability()
        {
            
        }

        public void Move()
        {
            var pos = joystick.Direction;

            if(pos != Vector2.zero)
            {
                backfireOriginPos.gameObject.SetActive(true);
            }
            else
            {
                backfireOriginPos.gameObject.SetActive(false);
            }

            if(pos.x > 0.3f)
            {
                spriteRenderer.sprite = shipData.shipSprites.Right;
            }
            else if(pos.x < -0.3f)
            {
                spriteRenderer.sprite = shipData.shipSprites.Left;
            }
            else
            {
                spriteRenderer.sprite = shipData.shipSprites.Center;
            }

            pos.x += transform.position.x;
            pos.y += transform.position.y;

            transform.DOMove(pos, shipData.movementSpeed * _SMOOTHNESS);
        }

        public void ReceiveDamage()
        {
            
        }

        public void Shoot()
        {
            
        }
    }

    public interface IShip
    {
        void Shoot();
        void Move();
        void Ability();
        void ReceiveDamage();
    }
}