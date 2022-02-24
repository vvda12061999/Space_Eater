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
        [Header("REFERENCES")]
        [SerializeField] private Joystick joystick;
        [SerializeField, ReadOnly] private static SpriteRenderer spriteRenderer;

        [Inject] private GameplayEngine gameplayEngine;
    }
}