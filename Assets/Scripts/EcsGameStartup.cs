using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

public class EcsGameStartup : MonoBehaviour
{
    [SerializeField] private EcsWorld world;
    [SerializeField] private EcsSystems systems;

    void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();

        systems.Init();
    }

    private void Update()
    {
        systems.Run();
    }

    private void AddSystems()
    {
        systems.
            Add(new PlayerInputSystem()).
            Add(new MovementSystem());

    }

    private void AddOneFrames()
    {
        throw new NotImplementedException();
    }

    private void AddInjections()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        if (systems != null)
            return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;

    }
}
