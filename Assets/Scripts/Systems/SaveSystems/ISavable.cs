using System;

//All object that has to be saved will inherit this interface
interface ISavable
{
    SaveDataBase SaveData();

    void LoadData(SaveDataBase saveData);
}

[System.Serializable]
public class SaveDataBase
{
    public string Name;
}