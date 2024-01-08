using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllSettingsPro.TutorialWizard;
using UnityEditor;

public class AllSettingsProDocumentation : TutorialWizard
{
    //required//////////////////////////////////////////////////////
    private const string ImagesFolder = "all-settings-pro/img/";
    private NetworkImages[] m_ServerImages = new NetworkImages[]
    {
        new NetworkImages{Name = "img-0.jpg", Image = null},
        new NetworkImages{Name = "img-1.png", Image = null},
        new NetworkImages{Name = "img-2.png", Image = null},
    };
    private readonly GifData[] AnimatedImages = new GifData[]
    {
        new GifData{ Path = "none.gif" },

    };

    private Steps[] AllSteps = new Steps[] {
     new Steps { Name = "Get Started", StepsLenght = 0, DrawFunctionName = nameof(GetStartedDoc) },
     new Steps { Name = "Show/Hide", StepsLenght = 0, DrawFunctionName = nameof(ShowHideDoc) },
     new Steps { Name = "Default Settings", StepsLenght = 0, DrawFunctionName = nameof(DefaultSettingsDoc) },
     new Steps { Name = "Text Mesh Pro", StepsLenght = 0, DrawFunctionName = nameof(DrawTMP) },
     new Steps { Name = "Full Screen", StepsLenght = 0, DrawFunctionName = nameof(FullscreenDoc) },
     new Steps { Name = "Resolution", StepsLenght = 0, DrawFunctionName = nameof(ResolutionDoc) },
     new Steps { Name = "Input Manager", StepsLenght = 0, DrawFunctionName = nameof(InputManagerDoc) },
     new Steps { Name = "Add Inputs", StepsLenght = 0, DrawFunctionName = nameof(AddInputsDoc) },
     new Steps { Name = "Settings", StepsLenght = 0, DrawFunctionName = nameof(DrawSettingsDoc) },
     new Steps { Name = "HUD Scale", StepsLenght = 0, DrawFunctionName = nameof(HudScaleDoc) },
    };

    public override void WindowArea(int window)
    {
        AutoDrawWindows();
    }
    //final required////////////////////////////////////////////////

    public override void OnEnable()
    {
        base.OnEnable();
        base.Initizalized(m_ServerImages, AllSteps, ImagesFolder, AnimatedImages);
        allowTextSuggestions = true;
    }

    void GetStartedDoc()
    {
        DrawText("•  Import the package from asset store to your unity project.\n\n•   •  In the scene where you want use the settings menu, drag the prefab <b>AllSettingsPro</b> located in:\n<i>\nAssets->All Settings Pro->Content->Prefabs->All Settings->*</i> into the canvas of your scene <i>(create one if not have yet)</i>.\n\n•  Drag the prefab <b>Brightness</b>  <i>(from the same folder path)</i> in the canvas too.\n\n•  In the first scene of your game (the one that appear first like the splash screen or so), drag the prefab\n<b>Settings Applicator </b>located in: <i>Assets->All Settings Pro->Content->Prefabs->Instances->Settings Applicator</i> anywhere in the hierarchy <i>(without parent)</i>\n\nReady!, now you can start to customize the UI and remove / add the settings that you want!\nFor hide show it, please follow the steps in the below section.\n\n(if you can a quick preview simple open the example scene located in: <i>All Settings Pro -> Example -> Scene ->*)</i>\n\n");
    }

    void ShowHideDoc()
    {
        DrawText("In order to open/show the settings menu in runtime:\n\n<b><size=16>From a script:</size></b>\n\n- Simple call the function like this:");
        DrawCodeText("bl_AllSettingsPro.Instance.ShowMenu();");
        DrawText("<b><size=16>From a button:</size></b>\n\n-Simple add the bl_AllSettingsPro menu in the button <b>OnClick</b> listeners pointing to the <b>ShowMenu</b> function.\n\nTo Close/Hide call the same function one second time.\n");
    }

    void DrawTMP()
    {
        DrawText("By default All Settings Pro support <b>UGUI</b> and <b>TextMeshPro</b> Text components, TextMeshPro solution is recommended to use nowdays but it's all up to you.\n\nIf you wanna use TextMeshPro simple use the <b>AllSettingsPro TMP</b> prefab, if you wanna use UGUI -> use the <b>AllSettingsPro</b> prefab.\n\n<b>If you don't wanna use TextMeshPro</b> and you don't wanna import the TextMeshPro package in the Unity Package Manager simply comment/remove the line:");
        DrawCodeText("#define TMP");
        DrawText("That line is present on the very top line of the following scripts:\n\n- bl_SingleSettingsSlider.cs\n- bl_SingleSettingsBinding.cs\n- bl_AllSettingsPro.cs\n- bl_KeyOptionsUI.cs\n- bl_SelectableText.cs");
    }

    void ResolutionDoc()
    {
        DrawText("If you want to use the native resolution of the device screen, you have to set the <b>Resolution</b> value in the Settings profile as <b>-1</b>.\n\nThe resolutions available depend on the device screens, that's way you can't define fixed dimensions.\n\nResolution 0 = the lowest supported resolution.\nResolution Lenght -1 = the maximum supported resolution.\n\n<i>As Full Screen, Resolution changes is not supported in Editor only in Builds.</i>\n");
    }

    void FullscreenDoc()
    {
        DrawText("In order to set the game screen to full screen in some platforms like Window, Mac or Linux you have to make sure that the <b>Resolution dialog</b> would not show since this will override any settings in game, for disable the Resolution Dialog go to (Top Menu)Edit -> Project Settings... -> Player -> Resolution and Presentation -> Display Resolution Dialog -> Set to <b>Disable</b>.\n\nOk, now Unity provide some full screen mode variations which are:\n\n-Fullscreen Window\n-Exclusive Fullscreen\n-Maximized Window\n-Windowed\n\nYou can set your default mode in your <b>Settings</b> profile -> <b>FullScreen Mode</b>.\n\n<i>Note: Fullscreen doesn't work on Editor, to test you have to do it in the Game Build.</i>\n");
    }

    void DefaultSettingsDoc()
    {
        DrawText("To set the default settings you want for your game, you simply have to create or modify a settings profile, for it select a folder in the <b>Project</b> View window -> right mouse click -> Create -> All Settings -> <b>Settings</b>.\n\nNow in the folder you will see an asset called <b>Settings</b>, in it foldout the <b>Settings</b> propertie and you will see all the settings values, there you have to set the default values for each setting, make ssure to set a custom name in the <b>GroupName</b> field.\n\nOnce you set the default values go to (Project View)All Settings Pro -> Resources -> AllSettings -> in the Inspector window you will see a variable called <b>Default Settings</b>, there assign the profile that you just created before.\n\nThat's.\n");
        DrawServerImage(1);
    }

    void InputManagerDoc()
    {
        DrawText("For use the Input Manager in your game you simple have to replace the Unity Input with the Input Manager code, e.g:\n\nWith Unity Input you may use something like this:");
        DrawCodeText("Input.GetKeyDown('MyKeyName');");
        DrawText("You simple have to replace for:");
        DrawCodeText("bl_Input.GetKeyDown('MyKeyName')");
        DownArrow();
        DrawText("Another example for the Axis method, in Unity:");
        DrawCodeText("Input.GetAxis('Vertical');\nor\nInput.GetAxis('Horizontal');");
        DrawText("Replace with:");
        DrawCodeText("bl_Input.VerticalAxis\nand\nbl_Input.HorizontalAxis");
        DrawText("So basically is just replace the <b>Input</b> to <b>bl_Input</b>, the key names are the ones defined in the InputManager object located in: <i>Assets->All Settings Pro->Content->Resources->InputManager->AllKeys</i>\n");
    }

    void AddInputsDoc()
    {
        DrawText("In order to add more inputs to use and that can be replaced in the settings menu by the players, you simple need add a new field in the list \"AllKeys\" of <b>InputManager</b> scriptableObject <i>(located in: Assets -> All Settings Pro -> Content -> Resources -> InputManager -> AllSettings)</i>\n\nhere you need fill following this:\n\n<b>Function</b> = The name of key, this is the one that you set when use the");
        DrawCodeText("bl_Input.GetKeyDown('KeyName');");
        DrawText("Key = The default KeyCode of this.\nDescription = Short description of what this input does in game.\n");
    }

    void DrawSettingsDoc()
    {
        DrawText("You can learn the function of each settings here:");
        DrawLinkText("https://docs.unity3d.com/Manual/class-QualitySettings.html", true);
        DrawLinkText("https://docs.unity3d.com/ScriptReference/QualitySettings.html", true);
    }

    void HudScaleDoc()
    {
        DrawText("As you see in the example scene, there's a HUD Scale setting, which is a slider with which players can increase or decrease the scale of the HUD, well this feature require a simple manual setup from your part, you simple had to attach the script <b>bl_CanvasScaler</b> in the Canvases that you wanna to get affected by the scale of that setting.\n");
        DrawServerImage(2);
    }

    [MenuItem("Window/Documentation/All Settings Pro")]
    private static void Open()
    {
        EditorWindow.GetWindow(typeof(AllSettingsProDocumentation));
    }
}