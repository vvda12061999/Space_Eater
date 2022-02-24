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
        [ReadOnly] public Ship shipData;

        [SerializeField] private float _duration = 0.3f;

        private async void Start()
        {
            await Init();
        }
        private void Update()
        {
            Move();
        }

        private async UniTask Init()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            await UniTask.Yield();
        }

        public void Ability()
        {
            
        }

        public void Move()
        {
            var pos = joystick.Direction;
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

            transform.DOMove(pos, _duration);
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