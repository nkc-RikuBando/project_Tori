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

            Subject<Vector3> _playerVec3PosSubject = new Subject<Vector3>();
            Subject<Vector3> _playerVec3RotSubject = new Subject<Vector3>();
            Subject<PlayerMoveType> _playerMoveTypeSubject = new Subject<PlayerMoveType>();

            private Vector3 _currentVelocity;
            private Vector3 _oldVelocity;
            private Vector3 _currentRot;

            private float _playerRotateSpeed_Y = 0f;
            private const float _PLAYER_SPEED = 50f;
            private const float _PLAYER_ACCEL_RATE = 0.5f;
            private const float _ROTATE_SPEED_CHANGE_RATE = 0.1f;


            // 一つ前のvelocityの値を取得するインターフェース
            void IInputRecevable.OldMoveDir(Vector3 vec)
            {
                _oldVelocity = vec;
            }

            // 移動用インターフェース実装
            void IInputRecevable.CurrentMoveDir(Vector3 vec)
            {
                _currentVelocity = Vector3.Lerp(_oldVelocity, vec * _PLAYER_SPEED, _PLAYER_ACCEL_RATE*Time.deltaTime);

                _playerVec3PosSubject.OnNext(_currentVelocity);
            }

            // 回転用インターフェース実装
            void IInputRecevable.CurrentRatateDir(Vector3 inputVec)
            {
                _playerRotateSpeed_Y += _ROTATE_SPEED_CHANGE_RATE * inputVec.x;

                // Y軸の回転　もっと綺麗になれるよお前は。
                if (inputVec.x == 0)
                {
                    if (_playerRotateSpeed_Y > 0)
                    {
                        _playerRotateSpeed_Y -= _ROTATE_SPEED_CHANGE_RATE;
                    }
                    else if (_playerRotateSpeed_Y < 0)
                    {
                        _playerRotateSpeed_Y += _ROTATE_SPEED_CHANGE_RATE;
                    }
                }

                _playerRotateSpeed_Y = Mathf.Clamp(_playerRotateSpeed_Y, -1f, 1f);

                _currentRot.y = _playerRotateSpeed_Y;

                MoveStateChange(_currentVelocity, inputVec);

                _playerVec3RotSubject.OnNext(_currentRot);
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

            // Playerの状態をRealityに送る
            IObservable<PlayerMoveType> IPlayerInfoStateSentable.GetPlayerMoveTypeObservable()
            {
                return _playerMoveTypeSubject;
            }


            // Playerのステートを変更する
            private void MoveStateChange(Vector3 velocity, Vector3 inputVec)
            {
                // 動いてない時
                if (velocity.magnitude <= 0.2f)
                {
                    _playerMoveTypeSubject.OnNext(HOVER);
                    return;
                }

                // 上昇状態
                if (velocity.y >= 0)
                {
                    if(inputVec.z == 0)
                    {
                        _playerMoveTypeSubject.OnNext(HOVER);
                    }
                    else if (inputVec.x > 0)
                    {
                        _playerMoveTypeSubject.OnNext(FLIGHT_RIGHT);
                    }
                    else if (inputVec.x < 0)
                    {
                        _playerMoveTypeSubject.OnNext(FLIGHT_LEFT);
                    }
                    else
                    {
                        _playerMoveTypeSubject.OnNext(FLIGHT_STRAIGHT);
                    }
                }
                // 降下状態
                else
                {
                    if(inputVec.z == 0)
                    {
                        _playerMoveTypeSubject.OnNext(HOVER);
                    }
                    else if (inputVec.x > 0)
                    {
                        _playerMoveTypeSubject.OnNext(GLIDE_RIGHT);
                    }
                    else if (inputVec.x < 0)
                    {
                        _playerMoveTypeSubject.OnNext(GLIDE_LEFT);
                    }
                    else
                    {
                        _playerMoveTypeSubject.OnNext(GLIDE_STRAIGHT);
                    }
                }
                
            }
        }

    }
}
