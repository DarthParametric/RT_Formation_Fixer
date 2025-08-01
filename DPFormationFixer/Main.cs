using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Root;
using Kingmaker.BundlesLoading;
using Kingmaker.Code.UI.MVVM.View.Formation;
using Kingmaker.Code.UI.MVVM.View.Formation.Base;
using Kingmaker.Code.UI.MVVM.View.Formation.Console;
using Kingmaker.Code.UI.MVVM.View.ServiceWindows.CharacterInfo.Sections.LevelClassScores;
using Kingmaker.Code.UI.MVVM.VM.Formation;
using Kingmaker.Formations;
using Owlcat.Runtime.UI.Controls.Button;
using Owlcat.Runtime.UI.MVVM;
using System.Collections.Generic;
using System.Reflection.Emit;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityModManagerNet;

namespace DPFormationFixer;

public static class Main
{
    internal static Harmony HarmonyInstance;
    internal static UnityModManager.ModEntry.ModLogger Log;
	public static Sprite NewCharBorder;

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
        Log = modEntry.Logger;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        try
        {
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }
        catch
        {
            HarmonyInstance.UnpatchAll(HarmonyInstance.Id);
            throw;
        }
        return true;
    }

    public static void PatchFormationArrays()
    {
        var BPRoot = ResourcesLibrary.TryGetBlueprint<FormationsRoot>("d5fe855c2ee3dfe4fae440979505dd33");                  // FormationsRoot
        var BPAuto = ResourcesLibrary.TryGetBlueprint<BlueprintPartyFormation>("1528ed7057903244f98c2d3c2851b3ec");         // Formation_Auto
        var BPStar = ResourcesLibrary.TryGetBlueprint<BlueprintPartyFormation>("89afd2b7af61273478e0b8584ae2c60b");         // Formation_Custom_01
        var BPTriangle = ResourcesLibrary.TryGetBlueprint<BlueprintPartyFormation>("bb3d357f04e7e7b439ddd36c2b123877");     // Formation_Triangle
        var BPWaves = ResourcesLibrary.TryGetBlueprint<BlueprintPartyFormation>("cdb4a0c6f7c2faf4f9bfb142ca4caee5");        // Formation_Custom_02
        var BPCircle = ResourcesLibrary.TryGetBlueprint<BlueprintPartyFormation>("a38b14ca3fb0c05409c5c8e45fb5687c");       // Formation_Custom_03
        var BPColumn = ResourcesLibrary.TryGetBlueprint<BlueprintPartyFormation>("71bb427a43932424a803f68253d57197");       // Formation_Default
        //var BPDefault = ResourcesLibrary.TryGetBlueprint<FollowersFormation>("a198d360f0d0cc643a1b104d6c5346ac");         // Formation_Followers_Default - For pets?

        LogDebug("Patching blueprints.");

        //                                #1                      #2                      #3                      #4                      #5                      #6                      #7                      #8                      #9                     #10                      #11                     #12                     #13                     #14                     #15                     #16                     #17                    #18                     #19                      #20                     #21                    #22                     #23                     #24
        BPAuto.Positions =		[new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f),	new(0.000f, 0.000f)];
        BPColumn.Positions =	[new(0.000f, 0.700f),	new(-1.400f, 0.700f),	new(1.400f, 0.700f),	new(0.000f, -0.600f),	new(-1.400f, -0.600f),	new(1.400f, -0.600f),	new(0.000f, -1.900f),	new(-1.400f, -1.900f),	new(1.400f, -1.900f),	new(0.000f, -3.200f),	new(-1.400f, -3.200f),	new(1.400f, -3.200f),	new(0.000f, -4.500f),	new(-1.400f, -4.500f),	new(1.400f, -4.500f),	new(0.000f, -5.800f),	new(-1.400f, -5.800f),	new(1.400f, -5.800f),	new(0.000f, -7.100f),	new(-1.400f, -7.100f),	new(1.400f, -7.100f),	new(0.000f, -8.400f),	new(-1.400f, -8.400f),	new(1.400f, -8.400f)];
        BPTriangle.Positions =	[new(0.000f, 0.000f),	new(-0.747f, -1.280f),	new(0.747f, -1.280f),	new(-1.493f, -2.560f),	new(1.493f, -2.560f),	new(0.000f, -2.560f),	new(-2.240f, -3.840f),	new(2.240f, -3.840f),	new(-0.740f, -3.840f),	new(0.740f, -3.840f),	new(-2.987f, -5.120f),	new(2.987f, -5.120f),	new(-1.480f, -5.120f),	new(1.480f, -5.120f),	new(0.000f, -5.120f),	new(-3.733f, -6.400f),	new(3.733f, -6.400f),	new(-2.220f, -6.400f),	new(2.220f, -6.400f),	new(-0.740f, -6.400f),	new(0.740f, -6.400f),	new(-1.920f, -7.680f),	new(1.920f, -7.680f),	new(0.000f, -7.680f)];
        BPStar.Positions =		[new(0.000f, -0.120f),	new(0.000f, -1.380f),	new(0.000f, -2.640f),	new(0.000f, -5.000f),	new(0.000f, -6.260f),	new(-2.020f, -3.840f),	new(2.020f, -3.840f),	new(-0.760f, -3.840f),	new(0.760f, -3.840f),	new(-1.320f, -2.720f),	new(1.320f, -2.720f),	new(-1.320f, -5.060f),	new(1.320f, -5.060f),	new(-2.000f, -1.700f),	new(2.000f, -1.700f),	new(-2.000f, -6.180f),	new(2.000f, -6.180f),	new(-2.000f, -6.180f),	new(2.000f, -6.180f),	new(-2.600f, -7.280f),	new(2.600f, -7.280f),	new(-3.320f, -3.840f),	new(3.320f, -3.840f),	new(0.000f, -7.560f)];
        BPWaves.Positions =		[new(0.000f, -0.520f),	new(-2.800f, -1.520f),	new(2.800f, -1.520f),	new(0.000f, -1.920f),	new(-2.800f, -2.920f),	new(2.800f, -2.920f),	new(-1.400f, -0.920f),	new(1.400f, -0.920f),	new(-1.400f, -2.320f),	new(1.400f, -2.320f),	new(-2.800f, -4.320f),	new(2.800f, -4.320f),	new(0.000f, -3.320f),	new(-1.400f, -3.720f),	new(1.400f, -3.720f),	new(-2.800f, -5.720f),	new(2.800f, -5.720f),	new(0.000f, -4.720f),	new(-1.400f, -5.120f),	new(1.400f, -5.120f),	new(-2.800f, -7.120f),	new(2.800f, -7.120f),	new(-1.400f, -6.520f),	new(1.400f, -6.520f)];
        BPCircle.Positions =	[new(0.000f, -0.990f),	new(-2.015f, -1.825f),	new(2.015f, -1.825f),	new(-2.850f, -3.840f),	new(2.850f, -3.840f),	new(0.000f, -6.690f),	new(-2.015f, -5.855f),	new(2.015f, -5.855f),	new(-1.124f, -1.195f),	new(1.124f, -1.195f),	new(-1.091f, -6.473f),	new(1.091f, -6.473f),	new(-2.633f, -2.749f),	new(2.633f, -2.749f),	new(-2.633f, -4.931f),	new(2.633f, -4.931f),	new(-1.061f, -2.779f),	new(1.061f, -2.779f),	new(-1.061f, -4.901f),	new(1.061f, -4.901f),	new(0.000f, -2.340f),	new(0.019f, -5.340f),	new(-1.500f, -3.840f),	new(1.500f, -3.840f)];

        BPRoot.AutoFormation.SpaceX = 1.25f;         // Default is 2.0 - Kingmaker.Formations.PartyAutoFormationHelper uses these when assembling the auto formation.
        BPRoot.AutoFormation.SpaceY = 1.25f;         // Default is 2.0

        LogDebug($"Patched blueprint array counts: Auto - {BPAuto.Positions.Length}, Column - {BPColumn.Positions.Length}, Triangle - {BPTriangle.Positions.Length}, Star - {BPStar.Positions.Length}, Waves - {BPWaves.Positions.Length}, Circle - {BPCircle.Positions.Length}.");
    }

    // Stolen from - https://discussions.unity.com/t/scale-around-point-similar-to-rotate-around/531171/5
    public static void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;

        Vector3 C = A - B; // Diff from object pivot to desired pivot/origin

        float RS = newScale.x / target.transform.localScale.x; // Relative scale factor

        // Calc final position post-scale
        Vector3 FP = B + C * RS;

        // Finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }

	public static void GrabSpriteFromBundle()
	{
		try
		{
			AssetBundle uibundle = BundlesLoadService.Instance.RequestBundle(AssetBundleNames.UIArt);
			NewCharBorder = uibundle.LoadAsset<Sprite>("6a9f2f0c67731f6468cb0d346dda9ae8");
			UnityEngine.Object.DontDestroyOnLoad(NewCharBorder);

			LogDebug($"Storing {NewCharBorder.GetType()} asset {NewCharBorder.name}, AssetID \"6a9f2f0c67731f6468cb0d346dda9ae8\".");
		}
		catch (Exception ex)
		{
			Log.Log($"Caught exception trying to load new sprite:\n{ex}");
		}
	}

	public static void LogDebug(string message)
    {
#if DEBUG
        try
        {
            Log.Log($"DEBUG: {message}");
        }
        catch (Exception e)
        {
            Log.Log($"Caught exception in debug log:\n{e}");
        }
#endif
    }

    [HarmonyPatch(typeof(BlueprintsCache))]
    public static class BlueprintsCaches_Patch
    {
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        public static void Init_Postfix()
        {
            try
            {
                if (Initialized)
                {
                    LogDebug("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;

                PatchFormationArrays();
				GrabSpriteFromBundle();
			}
            catch (Exception e)
            {
                Log.Log($"Mod initialisation failed with exception \n{e}");
            }
        }
    }

    // Removes the unnecessary gap in the Auto formation when no off-tank is present.
    [HarmonyPatch(typeof(PartyAutoFormationHelper), nameof(PartyAutoFormationHelper.SetupPositions))]
    class Auto_Formation_Condenser_Patch_1
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            /*
            This in the method that sets the row offsets. It inserts an empty row if there is no off-tank. Original code:

		    	formation.SetOffset(mainTank.Unit, Vector2.zero);
			    vector -= new Vector2(0f, PartyAutoFormationHelper.SpaceY);
			    if (offTank != null)
			    {
				    formation.SetOffset(offTank.Unit, vector);
			    }
			    vector -= new Vector2(0f, PartyAutoFormationHelper.SpaceY);

                IL_0017: ldloc.0
                IL_0018: ldc.r4     0
                IL_001D: call       static System.Single Kingmaker.Formations.PartyAutoFormationHelper::get_SpaceY()
                IL_0022: newobj     System.Void UnityEngine.Vector2::.ctor(System.Single x, System.Single y)
                IL_0027: call       static UnityEngine.Vector2 UnityEngine.Vector2::op_Subtraction(UnityEngine.Vector2 a, UnityEngine.Vector2 b)
                IL_002C: stloc.0
                IL_002D: ldarg.2
                IL_002E: brfalse => Label0

            By moving the second vector assignment inside the if check, it should no longer create an unnecessary empty row when
            no off-tank is present.
            */

            CodeMatcher matcher = new(instructions);

            matcher.MatchEndForward(
                new CodeMatch(OpCodes.Ldarg_2),                                     // Load the offTank argument.
                new CodeMatch(OpCodes.Brfalse_S)                                    // Break if false/null.
            );

            var jumpto = matcher.Operand;                                           // Store the jump label for the break.

            matcher.RemoveInstruction()                                             // Remove the brfalse.
                .Advance(-1)
                .RemoveInstruction()                                                // Remove the ldarg.2.
                .Advance(-6)                                                        // Move back to the start of the vector declaration block (ldloc.0).
                .Insert([
                    new CodeInstruction(OpCodes.Ldarg_2),                           // Add the ldarg.2.
                    new CodeInstruction(OpCodes.Brfalse_S, jumpto)                  // Add the brfalse with the original jump label.
                ]);

            return matcher.InstructionEnumeration();
        }
    }

    // Patch the Auto formation line setup to make it use the Wrath setup, adjusted for wider rows. The RT vanilla method puts everyone
    // in a single line behind the tank.
    [HarmonyPatch(typeof(PartyAutoFormationHelper), nameof(PartyAutoFormationHelper.SetupLinePositions))]
    class Auto_Formation_Condenser_Patch_2
    {
        static bool Prefix(PartyFormationAuto formation, ref Vector2 center, List<PartyAutoFormationHelper.UnitFormationData> line)
        {
            int i = 0;
            int num = ((line.Count > 5) ? Math.Min(6, line.Count) : Math.Min(4, line.Count));

			while (i < line.Count)
            {
                float num2 = -PartyAutoFormationHelper.SpaceX / 2f * (float)(num - 1);
                for (int j = i; j < i + num; j++)
                {
                    Vector2 vector = center + new Vector2(num2, 0f);
                    formation.SetOffset(line[j].Unit, vector);
                    num2 += PartyAutoFormationHelper.SpaceX;
                }
                i += num;
                num = ((line.Count > 5) ? Math.Min(12 - num, line.Count - i) : Math.Min(10 - num, line.Count - i));
                center -= new Vector2(0f, PartyAutoFormationHelper.SpaceY);
            }

            return false;
        }
    }

    // Patch that scales down the UI formation positions and character portraits by 70% to fit more on screen.
    // Also removes the vanilla auto-scaling behaviour, since that also shrinks the grid texture.
    [HarmonyPatch(typeof(FormationBaseView), nameof(FormationBaseView.OnFormationPresetChanged))]
    static class Formation_UI_Scale_Patch
    {
        static bool Prefix(int formationPresetIndex, FormationBaseView __instance)
        {
            RectTransform charcont = __instance.m_CharacterContainer;
			var children = charcont.childCount;
			Vector3 scalefac = new(0.7f, 0.7f, 1f);

			LogDebug("FormationCharacterBaseView.OnFormationPresetChanged Prefix patch started:");

			if (children < 3)
			{
				LogDebug($"m_CharacterContainer has no characters!");
			}

			for (int i = 0; i < children; i++)
            {
                var child = charcont.GetChild(i);

				if (child.name.Contains("FormationCharacter"))
                {
                    ScaleAround(child.gameObject, charcont.localPosition, scalefac);
				}
			}

			try
			{
				var contmode = Game.Instance.m_ControllerMode;

				LogDebug($"Formation preset number is {formationPresetIndex}. Checking for formation character list.");
				LogDebug($"Current view is {__instance}, ControllerMode = {contmode}");

				try
				{
					IEnumerable<FormationCharacterBaseView> ChrList = null;
					if (__instance is FormationPCView pcView)
					{
						ChrList = pcView.m_Characters;
					}
					else if (__instance is FormationConsoleView consoleView)
					{
						ChrList = consoleView.m_Characters;
					}

					var num = ChrList.Count();

					LogDebug($"Found valid {ChrList.GetType()} character list, length is {num}");

					if (num > 0)
					{
						LogDebug("Checking character surround sprites.");

						foreach (var Char in ChrList)
						{
							var button = Char.m_Button;
							var end = string.Empty;

							if (button != null)
							{
								var origspname = button.GetComponent<Image>().sprite.name;
								end = $", image = {origspname} - replacing";

								if (origspname != "UIDecal_Target")
								{
									try
									{
										end += $" with {NewCharBorder.name}";

										button.GetComponent<Image>().sprite = NewCharBorder;
									}
									catch (Exception ex)
									{
										Log.Log($"Caught exception trying to replace surround sprite:\n{ex}");
									}
								}
								else
								{
									end = " - already patched, skipping.";
								}

								//LogDebug($"Found m_Button{end}");
							}
							else
							{
								LogDebug("Character m_Button not found!");
							}
						}
					}
					else
					{
						LogDebug("Character list is empty!");
					}
				}
				catch (Exception ex)
				{
					Log.Log($"Caught exception trying to load the UI bundle:\n{ex}");
				}
			}
			catch (Exception ex)
			{
				Log.Log($"Caught exception trying to grab character list:\n{ex}");
			}

            return false;
        }
    }

    // Patch that offsets the position of the character icons on the formation UI when the Auto formation tab is active to force them
    // towards the top of the grid, maximising the available space. Dynamically adjusts the offset based on the party size.
    [HarmonyPatch(typeof(FormationCharacterVM), nameof(FormationCharacterVM.GetLocalPosition))]
    class Formation_UI_Offset_Patch
    {
        static bool Prefix(ref Vector3 __result, FormationCharacterVM __instance)
        {
            int CurrInd = Game.Instance.Player.FormationManager.CurrentFormationIndex;
            int PtyCnt = Game.Instance.Player.Party.Count;
            Vector2 CurrPos = __instance.GetOffset();
            Vector2 AdjPos = CurrPos * 40f;
            Vector2 DefPos = AdjPos + new Vector2(0f, 138f);

			float offset;

            if (PtyCnt > 18)
            {
                offset = 150f;
            }
            else if (PtyCnt > 12)
            {
                offset = 140;
            }
            else if (PtyCnt > 6)
            {
                offset = 130;
            }
            else if (PtyCnt == 1)
            {
                offset = 0;
            }
            else
            {
                offset = 110;
            }

            //LogDebug($"Party count = {PtyCnt}, offset = {offset}");

            if (CurrInd == 0)
            {
                Vector2 Auto = AdjPos + new Vector2(0f, offset);

                //LogDebug($"Char index = {__instance.m_Index}, name = {__instance.m_Unit.CharacterName}, GetOffset() = {CurrPos}, AdjPos = {AdjPos}, DefPos = {DefPos}, final position = {Auto}");

                __result = Auto;
            }
            else
            {
                __result = DefPos;
            }

            return false;
        }
    }

    // Change this to the same as the Wrath equivalent to prevent an endless loop causing a lockup/freeze when switching to the Auto tab.
    [HarmonyPatch(typeof(FormationCharacterBaseView), nameof(FormationCharacterBaseView.SetupPosition))]
    class GetLocalPosition_AntiFreeze_Patch
    {
        static bool Prefix(FormationCharacterBaseView __instance)
        {
            __instance.transform.localPosition = __instance.ViewModel.GetLocalPosition();

			return false;
        }
    }

    // Makes the BindViewImplementation subscribe to OnFormationPresetIndexChanged and OnFormationPresetChanged like it does in Wrath. Fixes the
    // formation UI needing to be updated to trigger the mod's changes taking effect.
    [HarmonyPatch(typeof(FormationPCView), nameof(FormationPCView.BindViewImplementation))]
    static class Formation_PCView_BindView_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            /*
            Add in the subscription to OnFormationPresetIndexChanged from the equivalent Wrath UI code:

                base.AddDisposable(base.ViewModel.SelectedFormationPresetIndex.Subscribe(new Action<int>(this.OnFormationPresetIndexChanged)));
				
                IL_0124: ldarg.0
                IL_0125: ldarg.0
                IL_0126: call      instance !0 class [Owlcat.Runtime.UI]Owlcat.Runtime.UI.MVVM.ViewBase`1<class Kingmaker.Code.UI.MVVM.VM.Formation.FormationVM>::get_ViewModel()
                IL_012B: callvirt  instance class [UniRx]UniRx.IReadOnlyReactiveProperty`1<int32> Kingmaker.Code.UI.MVVM.VM.Formation.FormationVM::get_SelectedFormationPresetIndex()
                IL_0130: ldarg.0
                IL_0131: dup
                IL_0132: ldvirtftn instance void Kingmaker.Code.UI.MVVM.View.Formation.Base.FormationBaseView::OnFormationPresetIndexChanged(int32)
                IL_0138: newobj    instance void class [mscorlib]System.Action`1<int32>::.ctor(object, native int)
                IL_013D: call      class [mscorlib]System.IDisposable [UniRx]UniRx.ObservableExtensions::Subscribe<int32>(class [mscorlib]System.IObservable`1<!!0>, class [mscorlib]System.Action`1<!!0>)
                IL_0142: call      instance void class [Owlcat.Runtime.UI]Owlcat.Runtime.UI.MVVM.ViewBase`1<class Kingmaker.Code.UI.MVVM.VM.Formation.FormationVM>::AddDisposable(class [mscorlib]System.IDisposable)
            */

            CodeMatcher matcher = new(instructions);

			matcher.Start();

			/*

			//UNNEEDED?

			matcher.MatchEndForward([
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Call),
                new CodeMatch(OpCodes.Call),
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Ldfld),
                new CodeMatch(OpCodes.Ldc_I4_0),
                new CodeMatch(OpCodes.Callvirt),
                new CodeMatch(OpCodes.Call),
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Ldfld),
                new CodeMatch(OpCodes.Ldc_I4_0),
                new CodeMatch(OpCodes.Callvirt)
                ]);

            matcher.Advance(1)
                .Insert([
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(ViewBase<FormationVM>), "ViewModel")),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(FormationVM), "SelectedFormationPresetIndex")),
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Dup),
                    new CodeInstruction(OpCodes.Ldvirtftn, AccessTools.Method(typeof(FormationBaseView), "OnFormationPresetIndexChanged")),
                    new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(Action<int>), [typeof(object), typeof(IntPtr)])),
                    new CodeInstruction(OpCodes.Call, typeof(ObservableExtensions)
                        .GetMethods()
                        .Single(m => m.Name == nameof(ObservableExtensions.Subscribe) && m.GetParameters().Length == 2).MakeGenericMethod([typeof(int)])),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(ViewBase<FormationVM>), nameof(ViewBase<FormationVM>.AddDisposable))),
                ]);

			*/

			/*
            Add in the subscription to OnFormationPresetChanged from the equivalent Wrath UI code:

                base.AddDisposable(base.ViewModel.SelectedFormationPresetIndex.Subscribe(new Action<int>(base.OnFormationPresetChanged)));
				
				IL_0124: ldarg.0
				IL_0125: ldarg.0
				IL_0126: call      instance !0 class [Owlcat.Runtime.UI]Owlcat.Runtime.UI.MVVM.ViewBase`1<class Kingmaker.Code.UI.MVVM.VM.Formation.FormationVM>::get_ViewModel()
				IL_012B: callvirt  instance class [UniRx]UniRx.IReadOnlyReactiveProperty`1<int32> Kingmaker.Code.UI.MVVM.VM.Formation.FormationVM::get_SelectedFormationPresetIndex()
				IL_0130: ldarg.0
				IL_0131: ldftn     instance void Kingmaker.Code.UI.MVVM.View.Formation.Base.FormationBaseView::OnFormationPresetChanged(int32)
				IL_0137: newobj    instance void class [mscorlib]System.Action`1<int32>::.ctor(object, native int)
				IL_013C: call      class [mscorlib]System.IDisposable [UniRx]UniRx.ObservableExtensions::Subscribe<int32>(class [mscorlib]System.IObservable`1<!!0>, class [mscorlib]System.Action`1<!!0>)
				IL_0141: call      instance void class [Owlcat.Runtime.UI]Owlcat.Runtime.UI.MVVM.ViewBase`1<class Kingmaker.Code.UI.MVVM.VM.Formation.FormationVM>::AddDisposable(class [mscorlib]System.IDisposable)
            */

			matcher.MatchEndForward([                                               // Find the next insertion point.
                new CodeMatch(OpCodes.Ldloca_S),
                new CodeMatch(OpCodes.Constrained),
                new CodeMatch(OpCodes.Callvirt),
                new CodeMatch(OpCodes.Endfinally)
                ]);

            matcher.Advance(2)                                                      // Move past an existing ldarg.0 to preserve its label so the previous code can jump to it.
                .Insert([
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(ViewBase<FormationVM>), "ViewModel")),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(FormationVM), "SelectedFormationPresetIndex")),
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Ldftn, AccessTools.Method(typeof(FormationBaseView), "OnFormationPresetChanged")),
                    new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(Action<int>), [typeof(object), typeof(IntPtr)])),
                    new CodeInstruction(OpCodes.Call, typeof(ObservableExtensions)
                        .GetMethods()
                        .Single(m => m.Name == nameof(ObservableExtensions.Subscribe) && m.GetParameters().Length == 2).MakeGenericMethod([typeof(int)])),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(ViewBase<FormationVM>), nameof(ViewBase<FormationVM>.AddDisposable))),
                    new CodeInstruction(OpCodes.Ldarg_0)                            // Add a replacement for the vanilla ldarg.0 with the label that was stolen.
                ]);

            return matcher.InstructionEnumeration();
        }
    }

	// ConsoleView equivalent of the above patch.
	/*
    [HarmonyPatch(typeof(FormationConsoleView), nameof(FormationConsoleView.BindViewImplementation))]
    [HarmonyDebug]
    static class Formation_ConsoleView_BindView_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {

            CodeMatcher matcher = new(instructions);



            return matcher.InstructionEnumeration();
        }
    }
    */
}