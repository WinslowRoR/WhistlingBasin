/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID WBASIN_PAUSE_MUSIC = 4231800764U;
        static const AkUniqueID WBASIN_PLAY_MUSIC_SYSTEM = 4193549960U;
        static const AkUniqueID WBASIN_UNPAUSE_MUSIC = 1329831351U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace BOSSSTATUS
        {
            static const AkUniqueID GROUP = 549431000U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace BOSSSTATUS

        namespace MUSIC_SYSTEM
        {
            static const AkUniqueID GROUP = 792781730U;

            namespace STATE
            {
                static const AkUniqueID BOSSFIGHT = 580146960U;
                static const AkUniqueID GAMEPLAY = 89505537U;
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SECRETLEVEL = 778026301U;
            } // namespace STATE
        } // namespace MUSIC_SYSTEM

        namespace WBASIN_GAMEPLAYSONGCHOICE
        {
            static const AkUniqueID GROUP = 1605073460U;

            namespace STATE
            {
                static const AkUniqueID BOSSSONG = 833170957U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID STAGESONG = 1973016150U;
            } // namespace STATE
        } // namespace WBASIN_GAMEPLAYSONGCHOICE

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYERHEALTH = 151362964U;
        static const AkUniqueID TELEPORTERPLAYERSTTAUS = 782977558U;
        static const AkUniqueID VOLUME_MASTER = 3695994288U;
        static const AkUniqueID VOLUME_MSX = 3729143042U;
        static const AkUniqueID VOLUME_SFX = 3673881719U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID WBASIN_MUSIC = 4235463847U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
