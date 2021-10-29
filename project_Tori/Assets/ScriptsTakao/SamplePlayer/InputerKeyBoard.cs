using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Inputer
{
    public class InputerKeyBoard : MonoBehaviour,IInputerKeyBorad
    {
        public bool MoveDown()
        {
            return Input.GetKey(KeyCode.RightShift);
        }

        public float MoveH()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public bool MoveUp()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        public float MoveV()
        {
            return Input.GetAxisRaw("Vertical");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

