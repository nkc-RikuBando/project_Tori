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
            // Playerì¸óÕèàóù

            [Inject] private IInputRecevable _keyboardInputer;

            private Rigidbody rb;


            private void Start()
            {
                rb = GetComponent<Rigidbody>();
            }

            private void Update()
            {
                InputVector();
            }

            private void FixedUpdate()
            {
                
                Position();
            }


            // Zé≤à⁄ìÆópInput
            private void Position()
            {
                Vector3 posVec3 = Vector3.zero;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    posVec3 = transform.forward;
                }
                else
                {
                    posVec3 = Vector3.zero;
                }

                posVec3.y = Input.GetAxisRaw("Vertical");

                _keyboardInputer.CurrentMoveDir(posVec3.normalized);
                _keyboardInputer.OldMoveDir(rb.velocity);

            }

            // âÒì]ópInput
            private void InputVector()
            {
                Vector3 inputVec3 = Vector3.zero;

                if (Input.GetKey(KeyCode.LeftShift)) inputVec3.z = 1;
                else                                 inputVec3.z = 0;

                inputVec3.y = Input.GetAxisRaw("Vertical");

                inputVec3.x = Input.GetAxisRaw("Horizontal");

                _keyboardInputer.CurrentRatateDir(inputVec3);
            }
        }

    }
}

