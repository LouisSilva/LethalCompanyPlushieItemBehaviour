using UnityEngine;
using Random = UnityEngine.Random;

namespace LethalCompanyPlushieScript;

public class PlushieBehaviour : PhysicsProp
{
    private int _materialVariantIndex;

#pragma warning disable 0649
    [SerializeField] private Material[] plushieMaterialVariants;
    [SerializeField] private Renderer renderer;
#pragma warning restore 0649

    public override void Start()
    {
        _materialVariantIndex = -1;
        base.Start();
        
        Random.InitState(FindObjectOfType<StartOfRound>().randomMapSeed - plushieMaterialVariants.Length);
        ApplyRandomMaterial();
    }
    
    private void ApplyRandomMaterial()
    {
        if (_materialVariantIndex != -1)
        {
            renderer.material = plushieMaterialVariants[_materialVariantIndex];
        }
        else if (plushieMaterialVariants.Length > 0)
        {
            _materialVariantIndex = Random.Range(0, plushieMaterialVariants.Length);
            renderer.material = plushieMaterialVariants[_materialVariantIndex];
        }
    }

    public override int GetItemDataToSave()
    {
        base.GetItemDataToSave();
        return _materialVariantIndex;
    }

    public override void LoadItemSaveData(int saveData)
    {
        base.LoadItemSaveData(saveData);
        _materialVariantIndex = saveData;
    }
}