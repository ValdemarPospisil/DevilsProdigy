using System;
using Prodigy.ObjectPoolSystem;
using UnityEngine;

namespace Prodigy.Interfaces
{
    public interface IObjectPoolItem
    {
        void SetObjectPool<T>(ObjectPool pool, T comp) where T : Component;

        void Release();
    }
}