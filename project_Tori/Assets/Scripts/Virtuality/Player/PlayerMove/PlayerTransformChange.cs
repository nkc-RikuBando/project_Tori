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

            Subject<Vector3>        _playerVec3PosSubject  = new Subject<Vector3>();
            Subject<Quaternion>     _playerVec3RotSubject  = new Subject<Quaternion>();
            Subject<PlayerMoveType> _playerMoveTypeSubject = new Subject<PlayerMoveType>();

            private Vector3    _currentVelocity;

<<<<<<< HEAD
            private const float _PLAYER_SPEED = 15f;
=======
            private float _playerRotateSpeed_Y = 0f;
            private const float _PLAYER_SPEED = 50f;
            private const float _PLAYER_ACCEL_RATE = 0.5f;
            private const float _ROTATE_SPEED_CHANGE_RATE = 0.1f;


            // ��O��velocity�̒l���擾����C���^�[�t�F�[�X
            void IInputRecevable.OldMoveDir(Vector3 vec)
            {
                _oldVelocity = vec;
            }
>>>>>>> c7c9012343726ae0ce3e59100d64c322e44949e9

            //private float _playerRotateSpeed_Y = 0f;
            //private const float _ROTATE_SPEED_CHANGE_RATE = 0.01f;
            
            // �ړ��p�C���^�[�t�F�[�X����
            void IInputRecevable.CurrentMoveDir(Vector3 moveDir, Vector3 oldVelo)
            {
<<<<<<< HEAD
                _currentVelocity = Vector3.Lerp(oldVelo, moveDir.normalized * _PLAYER_SPEED, Time.deltaTime);
=======
                _currentVelocity = Vector3.Lerp(_oldVelocity, vec * _PLAYER_SPEED, _PLAYER_ACCEL_RATE*Time.deltaTime);
>>>>>>> c7c9012343726ae0ce3e59100d64c322e44949e9

                _playerVec3PosSubject.OnNext(_currentVelocity);
            }

            // ��]�p�C���^�[�t�F�[�X����
            void IInputRecevable.CurrentRatateDir(Vector3 moveDir, GameObject obj)
            {
                {
                //_playerRotateSpeed_Y += _ROTATE_SPEED_CHANGE_RATE * inputVec.x;

                //// Y���̉�]�@�������Y��ɂȂ��您�O�́B
                //if (inputVec.x == 0)
                //{
                //    if (_playerRotateSpeed_Y > 0)
                //    {
                //        _playerRotateSpeed_Y -= _ROTATE_SPEED_CHANGE_RATE;
                //    }
                //    else if (_playerRotateSpeed_Y < 0)
                //    {
                //        _playerRotateSpeed_Y += _ROTATE_SPEED_CHANGE_RATE;
                //    }
                //}

                //_playerRotateSpeed_Y = Mathf.Clamp(_playerRotateSpeed_Y, -1f, 1f);

                //_currentRot.y = _playerRotateSpeed_Y;


                }

                if (moveDir.magnitude > 0.1f)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(moveDir);
                    obj.transform.rotation = Quaternion.Lerp(lookRotation, obj.transform.rotation, 0.9f);
                }

                MoveStateChange(_currentVelocity, moveDir);

                _playerVec3RotSubject.OnNext(obj.transform.rotation);
            }




            // �ړ����W��Reality�ɑ���
            IObservable<Vector3> IPlayerInfoStateSentable.GetPlayerPosObservable()
            {
                return _playerVec3PosSubject;
            }

            // ��]���W��Reality�ɑ���
            IObservable<Quaternion> IPlayerInfoStateSentable.GetPlayerRotObservable()
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

                if (velocity.magnitude <= 0.2f)
                {
                    _playerMoveTypeSubject.OnNext(HOVER);
                }
                else
                {
                    if (velocity.y >= 0) _playerMoveTypeSubject.OnNext(FLIGHT_STRAIGHT);
                    else _playerMoveTypeSubject.OnNext(GLIDE_STRAIGHT);
                }


                //// �����ĂȂ���
                //if (velocity.magnitude <= 0.2f)
                //{
                //    _playerMoveTypeSubject.OnNext(HOVER);
                //    return;
                //}

                //// �㏸���
                //if (velocity.y >= 0)
                //{
                //    if(inputVec.z == 0)
                //    {
                //        _playerMoveTypeSubject.OnNext(HOVER);
                //    }
                //    else if (inputVec.x > 0)
                //    {
                //        _playerMoveTypeSubject.OnNext(FLIGHT_RIGHT);
                //    }
                //    else if (inputVec.x < 0)
                //    {
                //        _playerMoveTypeSubject.OnNext(FLIGHT_LEFT);
                //    }
                //    else
                //    {
                //        _playerMoveTypeSubject.OnNext(FLIGHT_STRAIGHT);
                //    }
                //}
                //// �~�����
                //else
                //{
                //    if(inputVec.z == 0)
                //    {
                //        _playerMoveTypeSubject.OnNext(HOVER);
                //    }
                //    else if (inputVec.x > 0)
                //    {
                //        _playerMoveTypeSubject.OnNext(GLIDE_RIGHT);
                //    }
                //    else if (inputVec.x < 0)
                //    {
                //        _playerMoveTypeSubject.OnNext(GLIDE_LEFT);
                //    }
                //    else
                //    {
                //        _playerMoveTypeSubject.OnNext(GLIDE_STRAIGHT);
                //    }
                //}

            }
        }

    }
}
