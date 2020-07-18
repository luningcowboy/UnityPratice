#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using XLua;

public static class XGenerateConfig
{
    //一个C#纯值类型或枚举，加上了[GCOptimize]后，xLua会为该类型生成GC优化代码
    //效果是该值类型在Lua和C#之间传递不产生C#的GC Alloc
    //该类型的数组访问也不产生GC
    //除了枚举之外，包含无参构造函数的复杂类型，都会生成Lua Table到该类型、以及该类型的一维数组的转换代码
    //这将会优化这个转换的性能，包括更少的GC Alloc
    [GCOptimize]
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharpEnum
    {
        get
        {
            //Enum
            return new List<Type>
            {
                //UnityEngine
                typeof(UnityEngine.AudioType),
                typeof(UnityEngine.RenderMode),
                typeof(UnityEngine.TouchPhase),
                typeof(UnityEngine.CameraClearFlags),
                typeof(UnityEngine.CameraType),
                typeof(UnityEngine.ForceMode),
                typeof(UnityEngine.ForceMode2D),

                //UnityEngine.UI
                typeof(UnityEngine.UI.CanvasScaler.ScaleMode),
                typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode),

                //UnityEngine.Events
//				typeof(UnityEngine.Events.UnityEvent),

                //UnityEngine.EventSystems
                typeof(UnityEngine.EventSystems.EventTriggerType)
                //DoTween
            };
        }
    }


    //静态列表的方式
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    //有时我们无法直接给一个类型打标签，比如系统api，没源码的库，或者实例化的泛化类型，
    //这时可以在一个静态类里声明一个静态字段，该字段的类型除BlackList和AdditionalProperties之外只要实现了IEnumerable<Type>就可以了
    //然后为这字段加上标签
    //这个字段需要放在静态类里，建议放到Editor目录
    [LuaCallCSharp] public static List<Type> LuaCallCSharp = new List<Type>()
    {
        //Custom
        //typeof(XFramework.XUnityEngineTransformExtension),
        //typeof(XFramework.XUnityEngineObjectExtension),
        //typeof(XFramework.XUnityEngineUIButtonExtension),
        //System
        typeof(System.Action<string>),
        typeof(System.Collections.Generic.List<int>),
        typeof(System.Object),
        //UnityEngine
        typeof(UnityEngine.Object),
        typeof(UnityEngine.AnimationClip),
        typeof(UnityEngine.AnimationCurve),
        typeof(UnityEngine.Behaviour),
        typeof(UnityEngine.Bounds),
        typeof(UnityEngine.Camera),
        typeof(UnityEngine.Canvas),
        typeof(UnityEngine.Color),
        typeof(UnityEngine.Component),
        typeof(UnityEngine.Debug),
        typeof(UnityEngine.GameObject),
        typeof(UnityEngine.Keyframe),
        typeof(UnityEngine.Light),
        typeof(UnityEngine.LayerMask),
        typeof(UnityEngine.Mathf),
        typeof(UnityEngine.MonoBehaviour),
        typeof(UnityEngine.ParticleSystem),
        typeof(UnityEngine.Quaternion),
        typeof(UnityEngine.Ray),
        typeof(UnityEngine.Ray2D),
        typeof(UnityEngine.Random),
        typeof(UnityEngine.Renderer),
        typeof(UnityEngine.Resources),
        typeof(UnityEngine.Rigidbody),
        typeof(UnityEngine.Rigidbody2D),
        typeof(UnityEngine.SkinnedMeshRenderer),
        typeof(UnityEngine.TextAsset),
        typeof(UnityEngine.Time),
        typeof(UnityEngine.Transform),
        typeof(UnityEngine.Vector2),
        typeof(UnityEngine.Vector3),
        typeof(UnityEngine.Vector4),

        //UnityEngine.UI
        typeof(UnityEngine.UI.Button),
        typeof(UnityEngine.UI.CanvasScaler),
        typeof(UnityEngine.UI.GraphicRaycaster),
        typeof(UnityEngine.UI.Image),

        //UnityEngine.EventSystems
        typeof(UnityEngine.EventSystems.EventSystem),
        typeof(UnityEngine.EventSystems.StandaloneInputModule),
    };

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    //把一个Lua函数适配到一个C# delegate
    [CSharpCallLua] public static List<Type> CSharpCallLua = new List<Type>()
    {
        //System
        typeof(System.Action),
        typeof(System.Action<bool>),
        typeof(System.Action<double>),
        typeof(System.Action<float>),
        typeof(System.Action<float, float>),
        typeof(System.Action<float, float, float>),
        typeof(System.Action<string>),
        typeof(System.Action<UnityEngine.Collider>),
        typeof(System.Action<UnityEngine.Collision>),
        typeof(System.Action<UnityEngine.Collider2D>),
        typeof(System.Action<UnityEngine.Collision2D>),

        //typeof(System.Action<SuperScrollView.LoopListViewItem2, object>),

        typeof(System.Func<float>),
        typeof(System.Func<double, double, double>),
        //typeof(System.Func<SuperScrollView.LoopListView2, int, SuperScrollView.LoopListViewItem2>),
        typeof(System.Collections.IEnumerator),

        //Unity
        typeof(UnityEngine.Events.UnityAction),
    };

    //黑名单
    //如果你不要生成一个类型的一些成员的适配代码，你可以通过这个配置来实现。
    //标签方式比较简单，对应的成员上加就可以了。
    //由于考虑到有可能需要把重载函数的其中一个重载列入黑名单，配置方式比较复杂，类型是List<List<string>>，
    //对于每个成员，在第一层List有一个条目，第二层List是个string的列表，
    //第一个string是类型的全路径名，第二个string是成员名，如果成员是一个方法，还需要从第三个string开始，把其参数的类型全路径全列出来。
    [BlackList] public static List<List<string>> BlackList = new List<List<string>>()
    {
        new List<string>() {"UnityEngine.WWW", "movie"},
#if UNITY_WEBGL
		new List<string>(){"UnityEngine.WWW", "threadPriority"},
#endif
        new List<string>() {"UnityEngine.Texture2D", "alphaIsTransparency"},
        new List<string>() {"UnityEngine.Security", "GetChainOfTrustValue"},
        new List<string>() {"UnityEngine.CanvasRenderer", "onRequestRebuild"},
        new List<string>() {"UnityEngine.Light", "areaSize"},
#if UNITY_2017_1_OR_NEWER
        new List<string>() {"UnityEngine.Light", "lightmapBakeType"},
        new List<string>() {"UnityEngine.WWW", "MovieTexture"},
        new List<string>() {"UnityEngine.WWW", "GetMovieTexture"},
#endif
        new List<string>() {"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
#if !UNITY_WEBPLAYER
        new List<string>() {"UnityEngine.Application", "ExternalEval"},
#endif
        new List<string>() {"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
        new List<string>() {"UnityEngine.Component", "networkView"}, //4.6.2 not support
        new List<string>()
            {"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>() {"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
        new List<string>()
            {"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>()
            {"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>()
        {
            "System.IO.DirectoryInfo", "CreateSubdirectory", "System.String",
            "System.Security.AccessControl.DirectorySecurity"
        },
        new List<string>() {"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"UnityEngine.MonoBehaviour", "runInEditMode"},
    };
}


/*
 * 可以通过这种方式对C#类生成适配代码，但是会在IL2CPP下会增加不少的代码量，不建议使用
 * 
[CSharpCallLua]
public class CSharpCallLuaClass{
}
*/
#endif