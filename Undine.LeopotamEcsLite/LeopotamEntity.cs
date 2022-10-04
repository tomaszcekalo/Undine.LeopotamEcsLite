using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;

namespace Undine.LeopotamEcsLite
{
    public class LeopotamEntity : IUnifiedEntity
    {
        private int _entity;
        private EcsWorld _world;

        public LeopotamEntity(EcsWorld world)
        {
            _world = world;
            _entity = _world.NewEntity();
        }

        public void AddComponent<A>(in A component)
            where A : struct
        {
            EcsPool<A> pool = _world.GetPool<A>();
            ref A a1 = ref pool.Add(_entity);
            a1 = component;
        }

        public ref A GetComponent<A>()
            where A : struct
        {
            EcsPool<A> pool = _world.GetPool<A>();
            ref A a1 = ref pool.Add(_entity);
            return ref a1;
        }
    }
}