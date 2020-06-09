using NAudio.Wave;
using SaboteurX.Properties;
using System;
using System.IO;

namespace SaboteurX
{
    #region Music Helpers
    public static class MusicPlayerHelper
    {
        #region Audio settings
        public static bool isMusicOn = true;
        public static bool isSoundOn = true;
        #endregion

        #region Players
        public static WaveOut themeMusicPlayer = new WaveOut();
        public static WaveOut yourTurnMusicPlayer = new WaveOut();
        public static WaveOut navigationMusicPlayer = new WaveOut();
        public static WaveOut destroyRoadMusicPlayer = new WaveOut();
        public static WaveOut powerupMusicPlayer = new WaveOut();
        public static WaveOut buildMusicPlayer = new WaveOut();
        #endregion

        #region Wave streams
        private static WaveStream streamMusic = FromResourceToWaveStream(Resources.ThemeSong);
        private static WaveStream streamYourTurnAudio = FromResourceToWaveStream(Resources.YourTurnAudio);
        private static WaveStream streamNavigationAudio = FromResourceToWaveStream(Resources.NavigationAudio);
        private static WaveStream streamDestroyRoadAudio = FromResourceToWaveStream(Resources.DestroyRoadAudio);
        private static WaveStream streamPowerUpAudio = FromResourceToWaveStream(Resources.PowerUpAudio);
        private static WaveStream streamBuildAudio = FromResourceToWaveStream(Resources.BuildAudio);
        #endregion

        #region Initializers
        public static void InitAllPlayers()
        {
            InitMusic();
            InitAudioPlayers();
            ResetAudioTimelines();
        }
        static void InitAudioPlayers()
        {
            yourTurnMusicPlayer.Init(streamYourTurnAudio);
            navigationMusicPlayer.Init(streamNavigationAudio);
            destroyRoadMusicPlayer.Init(streamDestroyRoadAudio);
            powerupMusicPlayer.Init(streamPowerUpAudio);
            buildMusicPlayer.Init(streamBuildAudio);
        }
        static void InitMusic()
        {
            themeMusicPlayer.Init(streamMusic);
        }
        static void ResetAudioTimelines()
        {
            streamBuildAudio.CurrentTime = TimeSpan.Zero;
            streamDestroyRoadAudio.CurrentTime = TimeSpan.Zero;
            streamMusic.CurrentTime = TimeSpan.Zero;
            streamNavigationAudio.CurrentTime = TimeSpan.Zero;
            streamPowerUpAudio.CurrentTime = TimeSpan.Zero;
            streamYourTurnAudio.CurrentTime = TimeSpan.Zero;
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
            ResetAudioTimelines();
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
