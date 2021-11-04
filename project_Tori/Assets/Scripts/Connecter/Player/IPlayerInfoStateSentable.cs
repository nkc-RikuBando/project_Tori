using UnityEngine;
using System;
using UniRx;
using Virtuality.Player;

namespace Connector
{
    namespace Player
    {
        public interface IPlayerInfoStateSentable
        {
            //  Realiry�ɏ��𑗂�p�̃C���^�[�t�F�[�X

            IObservable<Vector3> GetPlayerPosObservable();

            IObservable<Quaternion> GetPlayerRotObservable();

            IObservable<PlayerMoveType> GetPlayerMoveTypeObservable();
        }
    }
}
