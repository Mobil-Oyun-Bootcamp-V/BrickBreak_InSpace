using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Values
{
    public int MaxLevel;
}
public class JSONData : MonoBehaviour
{
    Values _values;
    int newLevelValue;
    bool IsWrited;
    void Awake()
    {
        _values = new Values();
    }
    void Update()
    {
        if (PlayerManager.playerState == PlayerManager.PlayerState.EndMOD && !IsWrited)
        {   
            newLevelValue = GameManager.level;

            if (JSONRead() == -1)
            {
                JSONWrite();
            }
            if (JSONRead() < newLevelValue)
            {
                _values.MaxLevel = newLevelValue;
                JSONWrite();
            }
            IsWrited = true;
        }
    }
    public int JSONRead()
    {
        try
        {
            string jsread = System.IO.File.ReadAllText(Application.persistentDataPath + "/Values.json");
            _values = JsonUtility.FromJson<Values>(jsread);
        }
        catch(Exception ex)
        {
            return -1;
        }
        return _values.MaxLevel;
    }
    void JSONWrite()
    {
       string JSON = JsonUtility.ToJson(_values);
       System.IO.File.WriteAllText(Application.persistentDataPath + "/Values.json", JSON);
    }
}
