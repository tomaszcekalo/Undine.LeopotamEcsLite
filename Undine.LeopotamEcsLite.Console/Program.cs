// See https://aka.ms/new-console-template for more information
using Leopotam.EcsLite;
using Undine.Core;
using Undine.LeopotamEcsLite;

Console.WriteLine("Hello, World!");

var container = new LeopotamEcsContainer();
var c1sys = new Component1System();
container.AddSystem(c1sys);
var e1 = container.CreateNewEntity();
var c1 = new Component1()
{
    Id = 1,
    Name = "C1"
};
container.Init();
e1.AddComponent(c1);
container.Run();

internal class Component1System : UnifiedSystem<Component1>
{
    public override void ProcessSingleEntity(int entityId, ref Component1 t)
    {
        Console.WriteLine($"Component with Id={t.Id} has Name={t.Name}");
    }
}

internal struct Component1
{
    public int Id;
    public string Name;
}