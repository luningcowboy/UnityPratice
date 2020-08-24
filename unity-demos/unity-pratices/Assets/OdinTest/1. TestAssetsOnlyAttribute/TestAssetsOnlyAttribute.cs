using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TestAssetsOnlyAttribute : MonoBehaviour
{
    [AssetsOnly]
    public List<GameObject> OnlyPrefabs;

    [AssetsOnly]
    public GameObject SomePrefab;

    [AssetsOnly]
    public Material MaterialAsset;

    [AssetsOnly]
    public List<GameObject> SomeMeshRenderOnPrefab;

    [SceneObjectsOnly]
    public List<GameObject> OnlySceneObjects;

    [SceneObjectsOnly]
    public GameObject SomeSceneObject;

    [SceneObjectsOnly]
    public MeshRenderer SomeMeshRender;

}
