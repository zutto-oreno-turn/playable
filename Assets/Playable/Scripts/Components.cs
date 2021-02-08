using Unity.Entities;

public struct ExplosionSpawner : IComponentData
{
    public Entity Prefab;
    public float TimePerSprite;
}

public struct Explosion : IComponentData
{
    public float Timer;
}

public struct ExplosionSprite : IBufferElementData
{
    public Entity Sprite;
}
