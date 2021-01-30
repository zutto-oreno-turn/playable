using Unity.Entities;
using Unity.Tiny;

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
        UnityEngine.Debug.Log("GroundSystem#Play");
    }
}
