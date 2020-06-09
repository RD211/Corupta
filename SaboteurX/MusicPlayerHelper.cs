using NAudio.Wave;
using SaboteurX.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace SaboteurX
{
    #region Music Helpers
    public static class MusicPlayerHelper
    {
        #region Audio settings
        static bool isMusicOn = true;
        static bool isSoundOn = true;

        public static void TurnMusicOn()
        {
            isMusicOn = true;
            OnStateChanged();
        }
        public static void TurnMusicOff()
        {
            isMusicOn = false;
            OnStateChanged();
        }
        public static void TurnAudioOn()
        {
            isSoundOn = true;
            OnStateChanged();
        }
        public static void TurnAudioOff()
        {
            isSoundOn = false;
            OnStateChanged();

        }
        public static bool GetAudioState()
        {
            return isSoundOn;
        }
        public static bool GetMusicState()
        {
            return isMusicOn;
        }
        #endregion

        #region Players
        public static WaveOut themeMusicPlayer = new WaveOut();
        public static WaveOut yourTurnMusicPlayer = new WaveOut();
        public static WaveOut navigationMusicPlayer = new WaveOut();
        public static WaveOut destroyRoadMusicPlayer = new WaveOut();
        public static WaveOut powerupMusicPlayer = new WaveOut();
        public static WaveOut buildMusicPlayer = new WaveOut();
        public static WaveOut navigationNoMusicPlayer = new WaveOut();

        #endregion

        #region Wave streams
        private static readonly WaveStream streamMusic = FromResourceToWaveStream(Resources.ThemeSong);
        private static readonly WaveStream streamYourTurnAudio = FromResourceToWaveStream(Resources.YourTurnAudio);
        private static readonly WaveStream streamNavigationAudio = FromResourceToWaveStream(Resources.NavigationAudio);
        private static readonly WaveStream streamDestroyRoadAudio = FromResourceToWaveStream(Resources.DestroyRoadAudio);
        private static readonly WaveStream streamPowerUpAudio = FromResourceToWaveStream(Resources.PowerUpAudio);
        private static readonly WaveStream streamBuildAudio = FromResourceToWaveStream(Resources.BuildAudio);
        private static readonly WaveStream streamNavigationNoAudio = FromResourceToWaveStream(Resources.NavigationNoAudio);
        #endregion

        #region Initializers
        public static void InitAllPlayers()
        {
            InitMusic();
            InitAudioPlayers();
            ResetAudioTimelines();
            ResetMusicTimeline();
        }
        static void InitAudioPlayers()
        {
            yourTurnMusicPlayer.Init(streamYourTurnAudio);
            navigationMusicPlayer.Init(streamNavigationAudio);
            destroyRoadMusicPlayer.Init(streamDestroyRoadAudio);
            powerupMusicPlayer.Init(streamPowerUpAudio);
            buildMusicPlayer.Init(streamBuildAudio);
            navigationNoMusicPlayer.Init(streamNavigationNoAudio);
        }
        static void InitMusic()
        {
            themeMusicPlayer.Init(streamMusic);
        }
        static void ResetAudioTimelines()
        {
            streamBuildAudio.CurrentTime = TimeSpan.Zero;
            streamDestroyRoadAudio.CurrentTime = TimeSpan.Zero;
            streamNavigationAudio.CurrentTime = TimeSpan.Zero;
            streamPowerUpAudio.CurrentTime = TimeSpan.Zero;
            streamYourTurnAudio.CurrentTime = TimeSpan.Zero;
            streamNavigationNoAudio.CurrentTime = TimeSpan.Zero;
        }
        static void ResetMusicTimeline()
        {
            streamMusic.CurrentTime = TimeSpan.Zero;
        }
        #endregion

        #region Theme song
        public static void PlayThemeSong()
        {
            if (themeMusicPlayer.PlaybackState == PlaybackState.Paused)
            {
                themeMusicPlayer.Resume();
            }
            else
            {
                themeMusicPlayer.Volume = 0.25f;
                if (isMusicOn)
                {
                    themeMusicPlayer.Play();
                    themeMusicPlayer.PlaybackStopped += Output_PlaybackStopped_ThemeSong;
                }
            }
        }
        private static void Output_PlaybackStopped_ThemeSong(object sender, StoppedEventArgs e)
        {
            ResetMusicTimeline();
            try { themeMusicPlayer.Play(); } catch { }
        }
        public static void PauseThemeSong()
        {
            if (themeMusicPlayer.PlaybackState == PlaybackState.Playing)
            {
                themeMusicPlayer.Pause();
            }
        }
        #endregion

        #region All audios
        public static void PlayYourAudio(ref WaveOut wave)
        {
            if(isSoundOn)
            {

                ResetAudioTimelines();
                wave.Play();
                GC.Collect();
            }
        }
        #endregion

        #region Event handler
        public static event EventHandler StateChanged;
        private static void OnStateChanged()
        {
            StateChanged?.Invoke(null, EventArgs.Empty);
        }
        #endregion

        #region Helpers
        private static WaveStream FromResourceToWaveStream(UnmanagedMemoryStream resourceAudio)
        {
            byte[] b = ReadToEnd(resourceAudio);
            WaveStream wav = new RawSourceWaveStream(new MemoryStream(b), new WaveFormat(44100, 16, 2));
            return wav;
        }
        private static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        #endregion
    }
    #endregion
}
