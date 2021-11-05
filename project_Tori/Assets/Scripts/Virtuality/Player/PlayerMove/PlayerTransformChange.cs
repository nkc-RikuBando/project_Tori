using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using Connector.Player;
using static Virtuality.Player.PlayerMoveType;

namespace Virtuality
{
    namespace Player
    {
        public class PlayerTransformChange : IInputRecevable, IPlayerInfoStateSentable
        {
            // PlayerのTransformを変更

            Subject<Vector3>        _playerVec3PosSubject  = new Subject<Vector3>();
            Subject<Quaternion>     _playerVec3RotSubject  = new Subject<Quaternion>();
            Subject<PlayerMoveType> _playerMoveTypeSubject = new Subject<PlayerMoveType>();

            private Vector3    _currentVelocity;

            
            // 移動用インターフェース実装
            void IInputRecevable.CurrentMoveDir(Vector3 moveDir, Vector3 oldVelo, float dash, float speed)
            {
                _currentVelocity = Vector3.Lerp(oldVelo, moveDir.normalized * speed * dash, Time.deltaTime);

                _playerVec3PosSubject.OnNext(_currentVelocity);
            }

            // 回転用インターフェース実装
            void IInputRecevable.CurrentRatateDir(Vector3 moveDir, GameObject obj)
            {
                if (moveDir.magnitude > 0.1f)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(moveDir);
                    obj.transform.rotation = Quaternion.Lerp(lookRotation, obj.transform.rotation, 0.9f);
                }

                MoveStateChange(_currentVelocity, moveDir);

                _playerVec3RotSubject.OnNext(obj.transform.rotation);
            }


            // 移動座標をRealityに送る
            IObservable<Vector3> IPlayerInfoStateSentable.GetPlayerPosObservable()
            {
                return _playerVec3PosSubject;
            }

            // 回転座標をRealityに送る
            IObservable<Quaternion> IPlayerInfoStateSentable.GetPlayerRotObservable()
            {
                return _playerVec3RotSubject;
            }

            // Playerの状態をRealityに送る
            IObservable<PlayerMoveType> IPlayerInfoStateSentable.GetPlayerMoveTypeObservable()
            {
                return _playerMoveTypeSubject;
            }


            // Playerのステートを変更する
            private void MoveStateChange(Vector3 velocity, Vector3 inputVec)
            {

                if (velocity.magnitude <= 0.2f)
                {
                    _playerMoveTypeSubject.OnNext(HOVER);
                }
                else
                {
                    if (velocity.y >= 0) _playerMoveTypeSubject.OnNext(FLIGHT_STRAIGHT);
                    else _playerMoveTypeSubject.OnNext(GLIDE_STRAIGHT);
                }

            }
        }

    }
}
