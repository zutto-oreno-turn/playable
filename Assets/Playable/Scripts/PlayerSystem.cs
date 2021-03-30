using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny;
using Unity.Tiny.Input;
using Unity.Transforms;
using Unity.Tiny.UI;

public class PlayerSystem : SystemBase
{
    // enum ProgressState
    // {
    //     Initializing,
    //     Playing
    // }

    // ProgressState State = ProgressState.Initializing;

    // protected override void OnCreate()
    // {
    //     UnityEngine.Debug.Log($"PlayerSystem#OnCreate");
    //     base.OnCreate();
    // }

    protected override void OnUpdate()
    {
        Play();
        // switch (State)
        // {
        //     case ProgressState.Initializing:
        //         Initialization();
        //         break;
        //     case ProgressState.Playing:
        //         Play();
        //         break;
        //     default:
        //         break;
        // }
    }

    // void Initialization()
    // {
    //     UnityEngine.Debug.Log($"PlayerSystem#Initialization");
    //     State = ProgressState.Playing;
    // }

    void Play()
    {
        // UnityEngine.Debug.Log($"PlayerSystem#Play");

        InputSystem input = World.GetOrCreateSystem<InputSystem>();

        if (input.GetKey(KeyCode.W) || input.GetKey(KeyCode.UpArrow))
        {
            UnityEngine.Debug.Log($"PlayerSystem#Play Up 2");
        }
        if (input.GetKey(KeyCode.S) || input.GetKey(KeyCode.DownArrow))
        {
            UnityEngine.Debug.Log($"PlayerSystem#Play Down 2");
        }
        if (input.GetKey(KeyCode.A) || input.GetKey(KeyCode.LeftArrow))
        {
            UnityEngine.Debug.Log($"PlayerSystem#Play Left 2");
        }
        if (input.GetKey(KeyCode.D) || input.GetKey(KeyCode.RightArrow))
        {
            UnityEngine.Debug.Log($"PlayerSystem#Play Right 2");
        }

    //     Entities.ForEach((ref PlayerComponent player, ref RectTransform rect) =>
    //     {
    //         UnityEngine.Debug.Log($"PlayerSystem#Play {player.Speed}");
    //     }).ScheduleParallel();
    }
}
