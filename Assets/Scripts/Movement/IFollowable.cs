using System;
using UnityEngine;

namespace Movement
{
    public interface IFollowable
    {
        Vector3 StaticPosition { get; }
        IObservable<Vector3> Position { get; }
    }
}