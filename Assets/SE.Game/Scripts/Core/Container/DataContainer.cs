using SE.Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using Cysharp.Threading.Tasks;

namespace SE.Game.Core
{
    public class DataContainer : Singleton<DataContainer>
    {
        [Header("DATA")]
        public ShipDataStorage shipDataStorage;

        private void Start()
        {
        }
    }
}