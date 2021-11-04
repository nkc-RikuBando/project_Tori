using System.Collections;
using System.Collections.Generic;
using Connector.Player;
using UnityEngine;
using Zenject;

namespace Reality
{
    namespace Player
    {
        public class KeyboardInputer : MonoBehaviour
        {
            // Player入力処理

            [SerializeField] private Camera     _playerCamera;
            [SerializeField] private GameObject _avatar;

            [Inject] private IInputRecevable _keyboardInputer;

            private Rigidbody _rb;

            private Vector3 _cameraForward;
            private Vector3 _cameraRight;
            private Vector3 _movement = Vector3.zero;
            private Vector3 _velo     = Vector3.zero;

            private float _inputX, _inputY;

            private void Start()
            {
                _rb = GetComponent<Rigidbody>();
            }

            private void FixedUpdate()
            {
                Move();
            }


            // Z軸移動用Input
            private void Move()
            {
                {
                //Vector3 posVec3 = Vector3.zero;

                //if (Input.GetKey(KeyCode.LeftShift))
                //{
                //    posVec3 = transform.forward;
                //}
                //else
                //{
                //    posVec3 = Vector3.zero;
                //}
                //posVec3.y = Input.GetAxisRaw("Vertical");

                }

                _inputX = Input.GetAxisRaw("Horizontal");
                _inputY = Input.GetAxisRaw("Vertical");

                _velo = _rb.velocity;

                if (_playerCamera != null)
                {
                    _cameraForward = _playerCamera.transform.forward;
                    _cameraRight = _playerCamera.transform.right;
                }

                if (!Input.GetMouseButton(0))
                {
                    _movement = _cameraRight * _inputX + _cameraForward * _inputY;
                }

                _keyboardInputer.CurrentMoveDir(_movement, _velo);
                _keyboardInputer.CurrentRatateDir(_movement, _avatar);



            }

            // 回転用Input
            //private void InputVector()
            //{
            //    //Vector3 inputVec3 = Vector3.zero;

            //    //if (Input.GetKey(KeyCode.LeftShift)) inputVec3.z = 1;
            //    //else                                 inputVec3.z = 0;

            //    //inputVec3.y = Input.GetAxisRaw("Vertical");

            //    //inputVec3.x = Input.GetAxisRaw("Horizontal");

            //    _keyboardInputer.OldRatateDir(_movement);

            //    _keyboardInputer.CurrentRatateDir(_avatar.transform.rotation);
            //}

        }

    }
}

