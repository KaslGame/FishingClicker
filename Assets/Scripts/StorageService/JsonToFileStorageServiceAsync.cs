using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class JsonToFileStorageServiceAsync : IStorageService
{
    private bool _isInProgressNow;

    public void Save(string key, object data, Action<bool> callback = null)
    {
        if (_isInProgressNow == false)
        {
            SaveAsync(key, data, callback);
        }
        else
        {
            callback?.Invoke(false);
        }
    }

    public void Load<T>(string key, Action<T> callback)
    {
        string path = BuildPath(key);

        using (var fileStream = new StreamReader(path))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);

            callback.Invoke(data);
        }
    }

    public bool Exists(string key)
    {
        string path = BuildPath(key);
        return File.Exists(path);
    }

    private async void SaveAsync(string key, object data, Action<bool> callback)
    {
        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (var fileStream = new StreamWriter(path))
        {
            await fileStream.WriteAsync(json);
        }

        callback?.Invoke(true);
    }

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
