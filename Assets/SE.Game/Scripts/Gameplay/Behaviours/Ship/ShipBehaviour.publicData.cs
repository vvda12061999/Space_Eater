using NaughtyAttributes;
using SE.Game.Data;
using SE.Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SE.Game
{
    public partial class ShipBehaviour : MonoBehaviour
    {
        public void SetShipData(Ship shipdata) => this.shipData = shipdata;
    }
}