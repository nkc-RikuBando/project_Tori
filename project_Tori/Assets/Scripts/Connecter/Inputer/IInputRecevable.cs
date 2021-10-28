using System;
using UnityEngine;

namespace Connector
{
    namespace Player
    {
        interface IInputRecevable
        {
            // 入力情報を受けとる用インターフェース

            void CurrentMoveDir(Vector3 vec);

            void CurrentRatateDir(Vector3 vec);

        }
    }
}