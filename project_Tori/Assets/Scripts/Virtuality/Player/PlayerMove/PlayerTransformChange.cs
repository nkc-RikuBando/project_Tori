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

            // Player��Transform��ύX

            Subject<Vector3> _playerVec3PosSubject = new Subject<Vector3>();
            Subject<Vector3> _playerVec3RotSubject = new Subject<Vector3>();

            private Vector3 _playerPos;
            private Vector3 _playerRot;

            private const float _PLAYER_SPEED = 0.2f;
            private const float _PLAYER_SPEEDROT = 3;


            // �ړ��p�C���^�[�t�F�[�X����
            void IInputRecevable.CurrentMoveDir(Vector3 vec)
            {
                _playerPos.z = vec.z * _PLAYER_SPEED;
                _playerPos.y = vec.y * _PLAYER_SPEED;

                _playerVec3PosSubject.OnNext(_playerPos);
            }

            // ��]�p�C���^�[�t�F�[�X����
            void IInputRecevable.CurrentRatateDir(Vector3 vec)
            {
                _playerRot.y = vec.y * _PLAYER_SPEEDROT;

                _playerVec3RotSubject.OnNext(_playerRot);
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


        }

    }
}
