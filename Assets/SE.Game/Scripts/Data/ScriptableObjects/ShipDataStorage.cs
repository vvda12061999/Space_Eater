using SE.Game.CoreUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace SE.Game.Data
{
    [CreateAssetMenu(fileName = "Ship Data Storage", menuName = "Space Eater/Data/Create Ship Data Storage")]
    public class ShipDataStorage : ScriptableObject
    {
        public List<Ship> data;
    }
}