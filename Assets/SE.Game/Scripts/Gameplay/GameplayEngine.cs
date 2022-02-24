using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using SE.Game.Core;
using SE.Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SE.Game.Gameplay
{
    public class GameplayEngine : MonoInstaller
    {
        [SerializeField, Expandable] private ShipDataStorage shipDataStorage;
        [SerializeField] private ShipBehaviour shipBehaviour;
        [Inject] private MainFlow mainFlow;

        private async void Start()
        {
            await Init(shipDataStorage.data[0], "");
            
        }

        public override void InstallBindings()
        {
            Container.Bind<GameplayEngine>().FromInstance(this).AsSingle();
        }

        private async UniTask Init(Ship ship, string subShip)
        {
            shipBehaviour.SetShipData(ship);
            await shipBehaviour.Init();
            await UniTask.Yield();
        }
    }
}