using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny;
using Unity.Tiny.Input;
using Unity.Transforms;

public class GroundSystem : SystemBase
{
    enum ProgressState
    {
        Initializing,
        Playing
    }

    ProgressState State = ProgressState.Initializing;

    protected override void OnUpdate()
    {
        switch (State)
        {
            case ProgressState.Initializing:
                Initialization();
                break;
            case ProgressState.Playing:
                Play();
                break;
            default:
                break;
        }
    }

    void Initialization()
    {
        State = ProgressState.Playing;
        DisplayInfo di = GetSingleton<DisplayInfo>();
        UnityEngine.Debug.Log($"GroundSystem#Initialization1 di.width: {di.width}, di.height: {di.height}");
    }

    void Play()
    {
        UnityEngine.Debug.Log("GroundSystem#Play 1");

        var inputAxis = new float2(0, 0);
        var input = World.GetOrCreateSystem<InputSystem>();
        if (input.GetKey(KeyCode.UpArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Up");
        }
        if (input.GetKey(KeyCode.DownArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Down");
        }
        if (input.GetKey(KeyCode.LeftArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Left");
        }
        if (input.GetKey(KeyCode.RightArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Right");
        }

        Entities.ForEach((ref GroundComponent ground, ref Translation translation) =>
        {
            UnityEngine.Debug.Log($"GroundSystem#Play speed: {ground.Speed}, value: {translation.Value}");

            // var oldPosition = translation.Value;
            // var newPosition = translation.Value +
            //     new float3(0,
            //     playerInput.InputAxis.y * player.Speed,
            //     -playerInput.InputAxis.x * player.Speed);
            // translation.Value = new float3(newPosition.x,
            //     // Clamp the player position to avoid going off screen
            //     math.clamp(newPosition.y, player.VerticalLimit.y, player.VerticalLimit.x),
            //     math.clamp(newPosition.z, player.HorizontalLimit.y, player.HorizontalLimit.x));
            // //Update Seahorse Player direction (rotationY) only if moved on Z
            // var MoveDirection = oldPosition.z - newPosition.z;
            // if (MoveDirection != 0)
            // {
            //     var rotateAmount = 0f;
            //     // If direction < 0 moving left (0) else right (180)
            //     rotateAmount = (MoveDirection < 0) ? 0f : 180f;
            //     rotation.Value = quaternion.RotateY(math.radians(rotateAmount));
            // }
        }).ScheduleParallel();
    }
}
