using System;
using UnityEngine;

namespace Connector
{
    namespace Player
    {
        interface IInputRecevable
        {
            // ���͏����󂯂Ƃ�p�C���^�[�t�F�[�X

            void CurrentMoveDir(Vector3 moveDir, Vector3 oldVelo, float dash, float speed);

            void CurrentRatateDir(Vector3 moveDir, GameObject obj);
        }
    }
}