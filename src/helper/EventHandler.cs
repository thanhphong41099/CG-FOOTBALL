using K3DAsyncEngineLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLeague
{
    internal class EventHandler : KAEventHandler , IKAEventHandler
    {
        public virtual void OnHello()
        {
            //throw new NotImplementedException();
        }

        public virtual void OnLogMessage(string LogMessage)
        {
            if(LogMessage == "")
            {
              throw new NotImplementedException();
            }
        }

        public virtual void OnLoadProject(int bSuccess, KAScene pScene, int TotalCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSelectProject(int bSuccess, string AliasName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnLoadScene(int bSuccess, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnUnloadScene(int bSuccess, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnScenePlayed(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnScenePaused(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnBeginTransaction(int iSuccess)
        {
            if (iSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnEndTransaction(int iSuccess)
        {
            if (iSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnRollbackTransaction(int iSuccess)
        {
            if (iSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnReloadScene(int bSuccess, string FileName, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnHeartBeat(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnUnloadAll(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCloseProject(int bSuccess, string AliasName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnNewProject(int bSuccess, string AliasName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSceneSaved(int bSuccess, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSceneAnimationPlayed(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnLoadSceneForce(int bSuccess, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnScenePrepare(int bSuccess, string SceneName, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnScenePrepareEx(int bSuccess, string SceneName, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPlay(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPlayOut(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnStop(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnStopAll(int iSuccess)
        {
            if (iSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPause(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnResume(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryIsOnAir(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnTrigger(int bSuccess, int OutputChannelIndex, int LayerNo, int AnimationType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnTriggerObject(int bSuccess, string ObjectName, int OutputChannelIndex, int LayerNo, int AnimationType, int bWithChildren)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnTriggerByName(int bSuccess, int OutputChannelIndex, int LayerNo, string AnimationName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnTriggerObjectByName(int bSuccess, string ObjectName, int OutputChannelIndex, int LayerNo, string AnimationName, int bWithChildren)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnResumeBackground(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPlayDirect(int bSuccess, string SceneName, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackgroundFill(int bSuccess, string SceneName, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackgroundTexture(int bSuccess, string SceneName, string TextureFileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackgroundVideo(int bSuccess, string SceneName, string VideoFileName, int LoopCount, int LoopInfinite)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackgroundLiveIn(int bSuccess, string SceneName, int InputChannel)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnUseBackground(int bSuccess, string SceneName, int Use)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSceneEffectType(int bSuccess, string SceneName, int bInEffect, eKSceneEffectType EffectType, int Duration)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackground(int bSuccess, string SceneName, ref sKBackground Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetLightColor(int bSuccess, string SceneName, string LightName, ref sKLightColor Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetLightAttribute(int bSuccess, string SceneName, string LightName, ref sKLightAttribute Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQuerySceneEffectType(int bSuccess, string SceneName, int bInEffect, eKSceneEffectType EffectType, int Duration)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryChartObjects(int bSuccess, string SceneName, int Index, int TotalCount, ref sKChart Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryVariables(int bSuccess, string SceneName, int Index, int TotalCount, ref sKVariable Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryAnimationNames(int bSuccess, string SceneName, int Index, int TotalCount, string pAnimationName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryAnimationCount(int bSuccess, string SceneName, int AnimationCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryLightNames(int bSuccess, string SceneName, int Index, int TotalCount, string pLightName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSaveImageFile(int bSuccess, string SceneName, int Width, int Height, int Frame, string ImagePathName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSaveScene(int bSuccess, string SceneName, string K3SFileName, int UseCollect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddPause(int bSuccess, string SceneName, int AnimationType, int FrameNo, int Delay, int bAuto)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddPauseByName(int bSuccess, string SceneName, string AnimationName, int FrameNo, int Delay, int bAuto)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDeletePause(int bSuccess, string SceneName, int AnimationType, int FrameNo, int bAll)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDeletePauseByName(int bSuccess, string SceneName, string AnimationName, int FrameNo, int bAll)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnUpdateTextures(int bSuccess, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryPickedObjects(int bSuccess, string SceneName, int Index, int TotalCount, ref sKVariable Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSceneDuration(int bSuccess, string SceneName, int AnimationType, int Durtaion)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackgroundChangeType(int bSuccess, string SceneName, eKBackgroundChangeType ChangeType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackgroundPauseType(int bSuccess, string SceneName, eKBackgroundPauseType PauseType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetBackgroundPauseAtZeroFrameAsStandBy(int bSuccess, string SceneName, int bPause)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetStyleColor(int bSuccess, string ObjectName, ref sKStyleColor Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetFaceAttribute(int bSuccess, string ObjectName, ref sKFaceAttribute Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEdgeAttribute(int bSuccess, string ObjectName, ref sKEdgeAttribute Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetShadowAttribute(int bSuccess, string ObjectName, ref sKShadowAttribute Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetVisible(int bSuccess, string ObjectName, int bShow)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetValue(int bSuccess, string ObjectName, string Value)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterial(int bSuccess, string ObjectName, ref sKMaterial pKMaterial)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetFont(int bSuccess, string ObjectName, ref sKFont Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryChartDataTable(int bSuccess, string ObjectName, int Index, int TotalCount, ref sKChartDataTable Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetObjectAttribute(int bSuccess, string ObjectName, ref sKObjectAttribute pKObjectAttribute)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryObjectAttribute(int bSuccess, string ObjectName, ref sKObjectAttribute pKObjectAttribute)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnReplaceWithAFile(int bSuccess, string ObjectName, string ReplaceFileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddText(int bSuccess, string ObjectName, string Text, int StyleNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnStoreTextStyle(int bSuccess, string ObjectName, string Text, int StyleCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTextStyle(int bSuccess, string ObjectName, int Begin, int Count, int StyleNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnEditText(int bSuccess, string ObjectName, string Text, int BeginPos, int EndPos, int StyleNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryClassType(int bSuccess, string ObjectName, int ClassType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetChartCSVFile(int bSuccess, string ObjectName, string FilePath)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetChartCellData(int bSuccess, string ObjectName, float Value)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQuerySize(int bSuccess, string ObjectName, float Width, float Height, float Depth)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSize(int bSuccess, string ObjectName, float Width, float Height, float Depth)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCounterNumberKey(int bSuccess, string ObjectName, int KeyIndex, double Number)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPositionKey(int bSuccess, string ObjectName, int KeyIndex, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetRotationKey(int bSuccess, string ObjectName, int KeyIndex, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetScaleKey(int bSuccess, string ObjectName, int KeyIndex, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCylinderAngleKey(int bSuccess, string ObjectName, int KeyIndex, float Start, float End)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSphereAngleKey(int bSuccess, string ObjectName, int KeyIndex, float Start, float End)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCircleAngleKey(int bSuccess, string ObjectName, int KeyIndex, float Start, float End)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCropKey(int bSuccess, string ObjectName, int KeyIndex, float Left, float Top, float Right, float Bottom)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialKey(int bSuccess, string ObjectName, int KeyIndex, ref sKMaterial pKMaterial)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCountDown(int bSuccess, string ObjectName, float Second)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPosition(int bSuccess, string ObjectName, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetRotation(int bSuccess, string ObjectName, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetScale(int bSuccess, string ObjectName, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetLensFlaresKey(int bSuccess, string ObjectName, int KeyIndex, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddPathPoint(int bSuccess, string ObjectName, int Count)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnClearPathPoints(int bSuccess, string ObjectName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddPathShapePoint(int bSuccess, string ObjectName, int Count)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnClearPathShapePoints(int bSuccess, string ObjectName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetOpacity(int bSuccess, string ObjectName, int Opacity)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetOpacityKey(int bSuccess, string ObjectName, int KeyIndex, int Opacity)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryScrollRemainingDistance(int bSuccess, string ObjectName, int ScrollRemainingDistance)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddScrollObject(int bSuccess, string ObjectName, string ChildName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAdjustScrollSpeed(int bSuccess, string ObjectName, float SpeedDelta)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetScrollSpeed(int bSuccess, string ObjectName, float Speed)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetVariableName(int bSuccess, string ObjectName, string VariableName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetDiffuse(int bSuccess, string ObjectName, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetAmbient(int bSuccess, string ObjectName, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSpecular(int bSuccess, string ObjectName, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEmissive(int bSuccess, string ObjectName, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetDiffuseKey(int bSuccess, string ObjectName, int KeyIndex, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetAmbientKey(int bSuccess, string ObjectName, int KeyIndex, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSpecularKey(int bSuccess, string ObjectName, int KeyIndex, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEmissiveKey(int bSuccess, string ObjectName, int KeyIndex, int R, int G, int B)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetLoftPositionKey(int bSuccess, string ObjectName, int KeyIndex, float Start, float End)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetChangeOut(int bSuccess, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetStyleTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTextTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetDiffuseTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSpecularTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTransparencyTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetNormalTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetReflectionTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetRefractionTexture(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnModifyPathPoint(int bSuccess, string ObjectName, int Index, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetVideoFrame(int bSuccess, string ObjectName, int StartFrame, int StopFrame)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetVideoRepeatInfo(int bSuccess, string ObjectName, int StartFrame, int StopFrame, int LoopCount, int bInfinite, int bPlayAsOut)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTextStyleLibrary(int bSuccess, string ObjectName, string Text, int StyleID)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddTextStyleLibrary(int bSuccess, string ObjectName, string Text, int StyleID)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetFaceColor(int bSuccess, string ObjectName, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEdgeColor(int bSuccess, string ObjectName, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetShadowColor(int bSuccess, string ObjectName, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnInitScrollObject(int bSuccess, string ObjectName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCounterInfo(int bSuccess, string ObjectName, string Format, int UpdatePeriod, int bAddPlusSign)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCounterNumber(int bSuccess, string ObjectName, double Number)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCounterRange(int bSuccess, string ObjectName, double StartTime, double EndTime)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCounterRemainingTime(int bSuccess, string ObjectName, double BaseTime)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetCounterElapsedTime(int bSuccess, string ObjectName, double BaseTime)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSaveObjectImage(int bSuccess, string ObjectName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSendMosMessage(int bSuccess, string MosMessage)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnReceiveFile(int bSuccess, string ExistingFileName, string NewFileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddObject(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSavePreviewImage(int bSuccess, string ImagePathName, int Width, int Height)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDragObject(int bSuccess, string ObjectName, int X, int Y, int FrameCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnResetDrag(int bSuccess, string ObjectName, int FrameCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSceneScrollSpeed(int bSuccess, string SceneName, float Speed)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCreateWithAFile(int bSuccess, string SceneName, string FileName, string VariableName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSceneAudioFile(int bSuccess, string SceneName, int AnimationType, string AudioFileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnEnableSceneAudio(int bSuccess, string SceneName, int AnimationType, int bEnable)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCreateStory(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnInsertStory(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnMoveStory(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSwapStory(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDeleteStory(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCreateItem(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnInsertItem(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDeleteItem(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnMoveItem(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSwapItem(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPrepareItem(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnUpdateItems(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetScrollSpeedByScenePlayer(int bSuccess, int OutputChannelIndex, int LayerNo, float Speed)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAdjustScrollSpeedByScenePlayer(int bSuccess, int OutputChannelIndex, int LayerNo, float SpeedDelta)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPositionOfPathAnimation(int bSuccess, string ObjectName, float Position)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPositionKeyOfPathAnimation(int bSuccess, string ObjectName, int KeyIndex, float Position)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnUpdateThumbnail(int bSuccess, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetStyleItemTexture(int bSuccess, string ObjectName, eKStyleType ItemType, int ItemIndex, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnMessageNo(uint MessageNo)
        {
            if (MessageNo == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetKeyFrame(int bSuccess, eKObjectAttribute AttributeType, string ObjectName, int KeyIndex, int Frame, eKKeyFrameType KeyFrameType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetKeyInterpolation(int bSuccess, eKObjectAttribute AttributeType, string ObjectName, int KeyIndex, eKKeyInterpolationType InInterpolation, eKKeyInterpolationType OutInterpolation)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetStartFrame(int bSuccess, string ObjectName, int Frame)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnStartVideoCapture(int bSuccess, string FilePath, int VideoCodecIndex)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnStopVideoCapture(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCaptureImage(int bSuccess, string FilePath)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnClose(int ErrorCode)
        {
            if (ErrorCode == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddAbsolutePause(int bSuccess, string SceneName, int AnimationType, int FrameNo, int Delay, int bAuto)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnResetTotalTime(int bSuccess, string SceneName, int AnimationType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTotalTime(int bSuccess, string SceneName, int AnimationType, int Frame)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetAnimationLibrary(int bSuccess, string ObjectName, string Name, int bApplyAtCurrentPosition)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialLibrary(int bSuccess, string ObjectName, string Name)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetStyleLibrary(int bSuccess, string ObjectName, string Name)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetObjectEffectType(int bSuccess, string ObjectName, int bInEffect, eKEffectType EffectType, int Duration)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDownloadThumbnail(int bSuccess, string SceneName, int Width, int Height, int Frame, string ImagePathName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnMoveCamera(int bSuccess, string ObjectName, int X, int Y, int Z, int FrameCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnLoadStyleLibrarys(int bSuccess, string LibraryPath)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnLoadAnimationLibrarys(int bSuccess, string LibraryPath)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnLoadMaterialLibrarys(int bSuccess, string LibraryPath)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCheckVersion(int bSuccess, string ServerVersion, string SDKVersion)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetFaceTextColor(int bSuccess, string ObjectName, int BeginPos, int Count, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEdgeTextColor(int bSuccess, string ObjectName, int BeginPos, int Count, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetShadowTextColor(int bSuccess, string ObjectName, int BeginPos, int Count, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryGroupType(int bSuccess, string ObjectName, eKGroupType GroupType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryImageType(int bSuccess, string ObjectName, eKTextureTarget TextureTarget, eKImageType ImageType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetDiffuseTextColor(int bSuccess, string ObjectName, int BeginPos, int Count, int R, int G, int B, int A)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetVideoPlayInfo(int bSuccess, string ObjectName, eKTextureTarget TextureTarget, ref sKVideoPlayInfo pVideoPlayInfo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryVideoPlayInfo(int bSuccess, string ObjectName, eKTextureTarget TextureTarget, ref sKVideoPlayInfo pVideoPlayInfo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryIs3D(int bSuccess, string ObjectName, int b3D)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryScrollChildRemainingDistance(int bSuccess, string ObjectName, string ChildName, int ScrollRemainingDistance)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetImageType(int bSuccess, string ObjectName, eKTextureTarget TextureTarget, eKImageType ImageType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCutIn(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnCutOut(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnClearNextPreview(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectNone(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectWipe(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectPush(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectTransform(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectCurl(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectRipple(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectParticle(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectFade(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectDistortion(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectBlink(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectCrop(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectBlur(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectColor(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectSidefade(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEffectCutOut(int bSuccess, string SceneName, string ObjectName, int bAppliedObjectEffect)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnEnableMaterialItem(int bSuccess, string ObjectName, eKMaterialType Type, int bEnable)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetDiffuseColor(int bSuccess, string ObjectName, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetDiffuseColorKey(int bSuccess, string ObjectName, int KeyIndex, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetAmbientColor(int bSuccess, string ObjectName, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetAmbientColorKey(int bSuccess, string ObjectName, int KeyIndex, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSpecularColor(int bSuccess, string ObjectName, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSpecularColorKey(int bSuccess, string ObjectName, int KeyIndex, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEmissiveColor(int bSuccess, string ObjectName, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetEmissiveColorKey(int bSuccess, string ObjectName, int KeyIndex, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSpecularSharpness(int bSuccess, string ObjectName, float Sharpness)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTransparencyOpacity(int bSuccess, string ObjectName, byte Opacity)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureType(int bSuccess, string ObjectName, eKTextureType Type)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureFile(int bSuccess, string ObjectName, string FilePathName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureOpacity(int bSuccess, string ObjectName, byte Opacity)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureBlending(int bSuccess, string ObjectName, eKTextureBlending BlendingType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureFilter(int bSuccess, string ObjectName, eKTextureFilter FilterType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureAddress(int bSuccess, string ObjectName, eKTextureAddress AddressType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureOffset(int bSuccess, string ObjectName, float X, float Y)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureOffsetKey(int bSuccess, string ObjectName, int KeyIndex, float X, float Y)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureTiling(int bSuccess, string ObjectName, float X, float Y)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureTilingKey(int bSuccess, string ObjectName, int KeyIndex, float X, float Y)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureRotation(int bSuccess, string ObjectName, float Degree)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMaterialTextureRotationKey(int bSuccess, string ObjectName, int KeyIndex, float Degree)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetAudioOutput(int bSuccess, eKPlayAudioType PlayAudioType)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMemo(int bSuccess, string ObjectName, string Memo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryMemo(int bSuccess, string ObjectName, string Memo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTrialPlayMode(int bSuccess)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnAddCloneObject(int bSuccess, string SceneName, string NewVariable)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryFont(int bSuccess, string ObjectName, ref sKFont Param)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetImageOriginalSize(int bSuccess, string SceneName, string ObjectName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnApplyLibrary(int bSuccess, string SceneName, string ObjectName, string LibraryPath, eKEffectTarget EffectTarget)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTableValue(int bSuccess, string SceneName, string ObjectName, int Row, int Column, string Value)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetTableColor(int bSuccess, string SceneName, string ObjectName, int Row, int Column, sKColor Color)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryTableValue(int bSuccess, string SceneName, string ObjectName, int Row, int Column, string Value)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryTableValues(int bSuccess, string SceneName, string ObjectName, int Index, int TotalCount, int Row, int Column, string Value)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryPauseCount(int bSuccess, string SceneName, int AnimationType, int PauseCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryPauseCountByName(int bSuccess, string SceneName, string AnimationName, int PauseCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPlayRange(int bSuccess, int OutputChannelIndex, int LayerNo, int PlaybackRangeNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryPlaybackRangeCount(int bSuccess, string SceneName, int PlaybackRangeCount)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryPlaybackRange(int bSuccess, string SceneName, int PlaybackRangeNo, int Start, int End)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetVROffset(int bSuccess, string SceneName, float Horz, float Vert)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetOutputChannelIndex(int bSuccess, string SceneName, int OutputChannelIndex)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryOutputChannelIndex(int bSuccess, string SceneName, int OutputChannelIndex)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnEndTransactionOnChannel(int iSuccess, int OutputChannelIndex)
        {
            if (iSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryTotalTime(int iSuccess, string SceneName, int AnimationType, int Frame)
        {
            if (iSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPathShapeOutlineThickness(int bSuccess, string SceneName, string ObjectName, float Thickness)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnEnablePathShapeOutline(int bSuccess, string SceneName, string ObjectName, int bEnable)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPlayInNextPreview(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPlayOutNextPreview(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPlaybackCamera(int bSuccess, string SceneName, string ObjectName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetMoveTo(int bSuccess, string SceneName, string ObjectName, float X, float Y, float Z)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetRotateTo(int bSuccess, string SceneName, string ObjectName, float Pitch, float Yaw, float Roll)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetVerticalFOV(int bSuccess, string SceneName, string ObjectName, float Angle)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetDelay(int bSuccess, string SceneName, string ObjectName, int Delay)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnExportVideo(int bSuccess, string SceneName, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnStopVideoExporting(int bSuccess, string SceneName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryVideoExportingProgress(int bSuccess, string SceneName, int CurrentFrame, int TotalFrame)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnFinishedVideoExporting(int bSuccess, string FileName)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPause(int bSuccess, string SceneName, int AnimationType, int FrameNo, int Delay, int bAuto)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPauseByName(int bSuccess, string SceneName, string AnimationName, int FrameNo, int Delay, int bAuto)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPauseWithIndex(int bSuccess, string SceneName, int AnimationType, int Index, int Delay, int bAuto)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetPauseWithIndexByName(int bSuccess, string SceneName, string AnimationName, int Index, int Delay, int bAuto)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDeletePauseWithIndex(int bSuccess, string SceneName, int AnimationType, int Index, int bAll)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnDeletePauseWithIndexByName(int bSuccess, string SceneName, string AnimationName, int Index, int bAll)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnQueryTextlistOfTextObjects(int bSuccess, string SceneName, int Index, int TotalCount, string Text)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnPlayIn(int bSuccess, int OutputChannelIndex, int LayerNo)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }

        public virtual void OnSetSceneClipBox(int bSuccess, string SceneName, int Left, int Top, int Right, int Bottom)
        {
            if (bSuccess == 0)
            {

                throw new NotImplementedException();
            }
        }
    }
}
