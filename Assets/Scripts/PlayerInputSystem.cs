using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;

    private float moveX;
    private float moveZ;

    public void Run()
    {
        SetDirection();

        foreach (var i in directionFilter)
        {
            ref var directionalComponent = ref directionFilter.Get2(i);
            ref var direction = ref directionalComponent.Direction;

            direction.x = moveX; 
            direction.z = moveZ;
        }
    }

    private void SetDirection()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }
}
