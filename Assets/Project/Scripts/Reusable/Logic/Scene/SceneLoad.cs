using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public static class SceneLoad
{
    private const int NotifyDelay = 10;

    public static event Action<float> ProgressUpdated;

    public static void Restart()
    {
        var name = SceneManager.GetActiveScene().name;
        Load(name);
    }

    public static async void Load(string name)
    {
        var operation = SceneManager.LoadSceneAsync(name);

        while(!operation.isDone)
        {
            await Task.Delay(NotifyDelay);
            var progress = operation.progress;
            ProgressUpdated?.Invoke(progress);
        }
    }
}