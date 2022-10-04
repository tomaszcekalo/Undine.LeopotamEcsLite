using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;

namespace Undine.LeopotamEcsLite
{
    public class LeopotamSystem<T> : IEcsRunSystem, ISystem
        where T : struct
    {
        public UnifiedSystem<T> System { get; set; }
        public IEcsSystems Systems { get; set; }

        public void ProcessAll()
        {
            Run(Systems);
        }

        public void Run(IEcsSystems systems)
        {
            System.PreProcess();
            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<T>().End();
            var components = world.GetPool<T>();
            foreach (int entity in filter)
            {
                ref T item = ref components.Get(entity);
                System.ProcessSingleEntity(entity, ref item);
            }
            System.PostProcess();
        }
    }

    public class LeopotamSystem<A, B> : IEcsRunSystem, ISystem
        where A : struct
        where B : struct
    {
        public IEcsSystems Systems { get; set; }
        public UnifiedSystem<A, B> System { get; set; }

        public void Run(IEcsSystems systems)
        {
            System.PreProcess();
            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<A>().Inc<B>().End();
            var componentsA = world.GetPool<A>();
            var componentsB = world.GetPool<B>();
            foreach (int entity in filter)
            {
                ref A a = ref componentsA.Get(entity);
                ref B b = ref componentsB.Get(entity);
                System.ProcessSingleEntity(entity, ref a, ref b);
            }
            System.PostProcess();
        }

        public void ProcessAll()
        {
            Run(Systems);
        }
    }

    public class LeopotamSystem<A, B, C> : IEcsRunSystem, ISystem
        where A : struct
        where B : struct
        where C : struct
    {
        public IEcsSystems Systems { get; set; }
        public UnifiedSystem<A, B, C> System { get; set; }

        public void Run(IEcsSystems systems)
        {
            System.PreProcess();
            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<A>().Inc<B>().Inc<C>().End();
            var componentsA = world.GetPool<A>();
            var componentsB = world.GetPool<B>();
            var componentsC = world.GetPool<C>();
            foreach (int entity in filter)
            {
                ref A a = ref componentsA.Get(entity);
                ref B b = ref componentsB.Get(entity);
                ref C c = ref componentsC.Get(entity);
                System.ProcessSingleEntity(entity, ref a, ref b, ref c);
            }
            System.PostProcess();
        }

        public void ProcessAll()
        {
            Run(Systems);
        }
    }

    public class LeopotamSystem<A, B, C, D> : IEcsRunSystem, ISystem
        where A : struct
        where B : struct
        where C : struct
        where D : struct
    {
        public IEcsSystems Systems { get; set; }
        public UnifiedSystem<A, B, C, D> System { get; set; }

        public void Run(IEcsSystems systems)
        {
            System.PreProcess();
            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<A>().Inc<B>().Inc<C>().End();
            var componentsA = world.GetPool<A>();
            var componentsB = world.GetPool<B>();
            var componentsC = world.GetPool<C>();
            var componentsD = world.GetPool<D>();
            foreach (int entity in filter)
            {
                ref A a = ref componentsA.Get(entity);
                ref B b = ref componentsB.Get(entity);
                ref C c = ref componentsC.Get(entity);
                ref D d = ref componentsD.Get(entity);
                System.ProcessSingleEntity(entity, ref a, ref b, ref c, ref d);
            }
            System.PostProcess();
        }

        public void ProcessAll()
        {
            Run(Systems);
        }
    }
}