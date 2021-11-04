using System;
using UnityEngine;

namespace Connector
{
    namespace Player
    {
        interface IInputRecevable
        {
            // 入力情報を受けとる用インターフェース

            void CurrentMoveDir(Vector3 moveDir, Vector3 oldVelo);

            void CurrentRatateDir(Vector3 moveDir, GameObject obj);
        }
    }
}