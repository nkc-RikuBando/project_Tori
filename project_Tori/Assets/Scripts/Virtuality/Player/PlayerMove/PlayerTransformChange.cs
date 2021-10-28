using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using Connector.Player;

namespace Virtuality
{
    namespace Player
    {
        public class PlayerTransformChange : IInputRecevable, IPlayerInfoStateSentable
        {

            // PlayerのTransformを変更

            Subject<Vector3> _playerVec3PosSubject = new Subject<Vector3>();
            Subject<Vector3> _playerVec3RotSubject = new Subject<Vector3>();

            private Vector3 _playerPos;
            private Vector3 _playerRot;

            private const float _PLAYER_SPEED = 0.2f;
            private const float _PLAYER_SPEEDROT = 3;


            // 移動用インターフェース実装
            void IInputRecevable.CurrentMoveDir(Vector3 vec)
            {
                _playerPos.z = vec.z * _PLAYER_SPEED;
                _playerPos.y = vec.y * _PLAYER_SPEED;

                _playerVec3PosSubject.OnNext(_playerPos);
            }

            // 回転用インターフェース実装
            void IInputRecevable.CurrentRatateDir(Vector3 vec)
            {
                _playerRot.y = vec.y * _PLAYER_SPEEDROT;

                _playerVec3RotSubject.OnNext(_playerRot);
            }


            // 移動座標をRealityに送る
            IObservable<Vector3> IPlayerInfoStateSentable.GetPlayerPosObservable()
            {
                return _playerVec3PosSubject;
            }

            // 回転座標をRealityに送る
            IObservable<Vector3> IPlayerInfoStateSentable.GetPlayerRotObservable()
            {
                return _playerVec3RotSubject;
            }


        }

    }
}
