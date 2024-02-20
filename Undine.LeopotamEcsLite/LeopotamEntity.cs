using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;

namespace Undine.LeopotamEcsLite
{
    public class LeopotamEntity : IUnifiedEntity
    {
        public int EntityId { get; }
        private EcsWorld _world;

        public LeopotamEntity(EcsWorld world)
        {
            _world = world;
            EntityId = _world.NewEntity();
        }

        public void AddComponent<A>(in A component)
            where A : struct
        {
            EcsPool<A> pool = _world.GetPool<A>();
            ref A a1 = ref pool.Add(EntityId);
            a1 = component;
        }

        public ref A GetComponent<A>()
            where A : struct
        {
            EcsPool<A> pool = _world.GetPool<A>();
            ref A a1 = ref pool.Add(EntityId);
            return ref a1;
        }

        public void RemoveComponent<A>() where A : struct
        {
            EcsPool<A> pool = _world.GetPool<A>();
            pool.Del(EntityId);
        }
        public bool HasComponent<A>() where A : struct
        {
            EcsPool<A> pool = _world.GetPool<A>();
            return pool.Has(EntityId);
        }
    }
}