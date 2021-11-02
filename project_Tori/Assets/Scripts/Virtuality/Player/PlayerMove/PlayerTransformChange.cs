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
            // Player��Transform��ύX

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


            // ��O��velocity�̒l���擾����C���^�[�t�F�[�X
            void IInputRecevable.OldMoveDir(Vector3 vec)
            {
                _oldVelocity = vec;
            }

            // �ړ��p�C���^�[�t�F�[�X����
            void IInputRecevable.CurrentMoveDir(Vector3 vec)
            {
                _currentVelocity = Vector3.Lerp(_oldVelocity, vec * _PLAYER_SPEED, _PLAYER_ACCEL_RATE*Time.deltaTime);

                _playerVec3PosSubject.OnNext(_currentVelocity);
            }

            // ��]�p�C���^�[�t�F�[�X����
            void IInputRecevable.CurrentRatateDir(Vector3 inputVec)
            {
                _playerRotateSpeed_Y += _ROTATE_SPEED_CHANGE_RATE * inputVec.x;

                // Y���̉�]�@�������Y��ɂȂ��您�O�́B
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


            // �ړ����W��Reality�ɑ���
            IObservable<Vector3> IPlayerInfoStateSentable.GetPlayerPosObservable()
            {
                return _playerVec3PosSubject;
            }

            // ��]���W��Reality�ɑ���
            IObservable<Vector3> IPlayerInfoStateSentable.GetPlayerRotObservable()
            {
                return _playerVec3RotSubject;
            }

            // Player�̏�Ԃ�Reality�ɑ���
            IObservable<PlayerMoveType> IPlayerInfoStateSentable.GetPlayerMoveTypeObservable()
            {
                return _playerMoveTypeSubject;
            }


            // Player�̃X�e�[�g��ύX����
            private void MoveStateChange(Vector3 velocity, Vector3 inputVec)
            {
                // �����ĂȂ���
                if (velocity.magnitude <= 0.2f)
                {
                    _playerMoveTypeSubject.OnNext(HOVER);
                    return;
                }

                // �㏸���
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
                // �~�����
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
