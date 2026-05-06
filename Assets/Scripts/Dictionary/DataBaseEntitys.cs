using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "DataBaseEntitys", menuName = "Scriptable Objects/DataBaseEntitys")]
public class DataBaseEntitys : SerializedScriptableObject
{
    [FoldoutGroup("References"), PreviewField(150)]
    public GameObject entityPrefab;

    public Dictionary<Rarity, List<BaseEntityData>> dataBaseEntitys = new();

    public BaseEntityData GetRandomEntity(Rarity rarity)
    {
        if(dataBaseEntitys.TryGetValue(rarity, out List<BaseEntityData> entities))
        {
            return entities[ Random.Range(0,entities.Count)];
        }
        else
        {
            throw new System.Exception("La rareza definida no existe!!!");
        }
    }

    public GameObject InstantitateEntity(Rarity rarity,Vector3 position)
    {
        GameObject obj = Instantiate(entityPrefab);
      //obj.GetComponent<BaseEntity>().Set(GetRandomEntity(rarity));
        obj.transform.position = position; 
        return obj;
    }


}
