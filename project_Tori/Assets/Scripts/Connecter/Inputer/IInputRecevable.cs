using System;
using UnityEngine;

namespace Connector
{
    namespace Player
    {
        interface IInputRecevable
        {
            // ���͏����󂯂Ƃ�p�C���^�[�t�F�[�X

            void CurrentMoveDir(Vector3 vec);

            void CurrentRatateDir(Vector3 vec);

        }
    }
}