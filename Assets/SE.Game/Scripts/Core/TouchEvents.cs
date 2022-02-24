using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE.Game.Core
{
    public static class TouchEvents
    {
        private static Camera _camera = Camera.main;
        public static Vector3 touchWorldStartPosition
        {
            get
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = _camera.nearClipPlane;
                    return _camera.ScreenToWorldPoint(mousePos);
                }
                else
                    return Vector3.zero;
            }
        }
        public static Vector3 touchWorldPosition
        {
            get
            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = _camera.nearClipPlane;
                    return _camera.ScreenToWorldPoint(mousePos);
                }
                else
                    return Vector3.zero;
            }
        }
        public static Vector3 touchWorldEndPosition
        {
            get
            {
                if (Input.GetMouseButtonUp(0))
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = _camera.nearClipPlane;
                    return _camera.ScreenToWorldPoint(mousePos);
                }
                else
                    return Vector2.zero;
            }
        }


        public static Vector2 touchStartPosition
        {
            get 
            {
                if (Input.GetMouseButtonDown(0))
                    return Input.mousePosition;
                else
                    return Vector2.zero;
            }
        }
        public static Vector2 touchPosition
        {
            get
            {
                if (Input.GetMouseButton(0))
                    return Input.mousePosition;
                else
                    return Vector2.zero;
            }
        }
        public static Vector2 touchEndPosition
        {
            get
            {
                if (Input.GetMouseButtonUp(0))
                    return Input.mousePosition;
                else
                    return Vector2.zero;
            }
        }
    }
}
