using NaughtyAttributes;
using SE.Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SE.Game.Core
{
    public class MainFlow : MonoInstaller<MainFlow>
    {
        [ReadOnly] public ShipDataStorage shipDataStorage;

        public override void InstallBindings()
        {
            Container.Bind<MainFlow>().FromInstance(this).AsSingle();
        }
    }
}