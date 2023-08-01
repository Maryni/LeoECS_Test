using Leopotam.Ecs;
using UnityEngine;

sealed class MovementSystem :IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent, MovebleComponent, DirectionComponent> movebleFilter = null;

    public void Run()
    {
        foreach (var i in movebleFilter)
        {
            ref var modelComponent = ref movebleFilter.Get1(i);
            ref var movebleComponent = ref movebleFilter.Get2(i);
            ref var directionComponent = ref movebleFilter.Get3(i);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.ModelTransform;

            ref var characterController = ref movebleComponent.CharacterController;
            ref var speed = ref movebleComponent.Speed;

            var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);
            characterController.Move(rawDirection * speed * Time.deltaTime);
        }
        
    }
}