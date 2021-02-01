using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny;
using Unity.Tiny.Input;
using Unity.Transforms;
using Unity.Tiny.UI;

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
        InputSystem input = World.GetOrCreateSystem<InputSystem>();
        float2 vector = new float2(0.0f, 0.0f);

        if (input.GetKey(KeyCode.W) || input.GetKey(KeyCode.UpArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Up");
            vector = new float2(0.0f, -2.0f);
        }
        if (input.GetKey(KeyCode.S) || input.GetKey(KeyCode.DownArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Down");
            vector = new float2(0.0f, 2.0f);
        }
        if (input.GetKey(KeyCode.A) || input.GetKey(KeyCode.LeftArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Left");
            vector = new float2(2.0f, 0.0f);
        }
        if (input.GetKey(KeyCode.D) || input.GetKey(KeyCode.RightArrow))
        {
            UnityEngine.Debug.Log($"GroundSystem#Play Right");
            vector = new float2(-2.0f, 0.0f);
        }

        Entities.ForEach((ref GroundComponent ground, ref RectTransform rect) =>
        {
            rect.AnchoredPosition = new float2(rect.AnchoredPosition.x + vector.x, rect.AnchoredPosition.y + vector.y);
        }).ScheduleParallel();
    }
}
