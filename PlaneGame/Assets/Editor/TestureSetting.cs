using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestureSetting : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        var importer = (TextureImporter) assetImporter;
        importer.textureType = TextureImporterType.Sprite;
    }
}
