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
            // Player“ü—Íˆ—

            [Inject] private IInputRecevable _keyboardInputer;


            private void Update()
            {
                Position();
                Rotate();
            }


            // ZŽ²ˆÚ“®—pInput
            private void Position()
            {
                Vector3 posVec3 = Vector3.zero;

                posVec3.y = Input.GetAxis("Vertical");

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    posVec3.z = 1;
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    posVec3.z = 0;
                }

                _keyboardInputer.CurrentMoveDir(posVec3);

            }

            // ‰ñ“]—pInput
            private void Rotate()
            {
                Vector3 rotVec3 = Vector3.zero;

                rotVec3.y = Input.GetAxisRaw("Horizontal");


                if (transform.rotation.y >= 0.5f)
                {
                    rotVec3.y = -0.5f;
                }
                else if (transform.rotation.y <= -0.5f)
                {
                    rotVec3.y = 0.5f;
                }

                _keyboardInputer.CurrentRatateDir(rotVec3);
            }
        }

    }
}

