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
            //  Realiryに情報を送る用のインターフェース

            IObservable<Vector3> GetPlayerPosObservable();

            IObservable<Vector3> GetPlayerRotObservable();
        }
    }
}
