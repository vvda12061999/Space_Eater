using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using SE.Game.CoreUtils;

namespace SE.Game.Data
{
    [System.Serializable]
    public partial class Ship
    {
        [Header("ID")]
        [ScriptableObjectId] public string ID;
        [Header("SHIP CLASS")]
        public EShipClass shipClass;
        [Header("SHIP SPRITES")]
        public ShipSprites shipSprites;
        [Header("BULLETS")]
        public ShipBulletVariable shipBulletVariable;
        [Header("SHIP STRINGS")]
        public string shipName;
        [TextArea(5, 10)] public string description;
        [Header("SHIP PROPERTIES")]
        public IntShipVariable health;
        public IntShipVariable attack;
        public FloatShipVariable attackSpeed;
        public IntShipVariable defend;
        public float movementSpeed;
    }

    public enum EShipClass { Space, Ranger, Crawler }

    [System.Serializable]
    public class ShipSprites
    {
        [ShowAssetPreview(64, 64)] public Sprite Left = null;
        [ShowAssetPreview(64, 64)] public Sprite Center = null;
        [ShowAssetPreview(64, 64)] public Sprite Right = null;
        public GameObject BackFirePrefab;
    }
    [System.Serializable]
    public struct ShipBulletVariable
    {
        public GameObject level_1;
        public GameObject level_2;
        public GameObject level_3;
        public GameObject level_4;
        public GameObject level_5;
    }
    [System.Serializable]
    public struct IntShipVariable
    {
        public int level_1;
        public int level_2;
        public int level_3;
        public int level_4;
        public int level_5;
    }
    [System.Serializable]
    public struct FloatShipVariable
    {
        public float level_1;
        public float level_2;
        public float level_3;
        public float level_4;
        public float level_5;
    }
}