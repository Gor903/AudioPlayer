using NAudio.Wave;
using NAudio.Wave.SampleProviders;

class MusicPlayer{
    private static MusicPlayer? musicPlayer;
    private AudioFileReader? audioFile;
    private WaveOutEvent? outputDevice;
    private float volume = 1f;
    private static TimeSpan localPosition = TimeSpan.Zero;
    private string? path;

    public static MusicPlayer GetMusicPlayer(){
        if(musicPlayer == null){
            return new MusicPlayer();
        }
        return musicPlayer;
    }
    private void PlayMusic(){
        audioFile = new AudioFileReader(path);
        outputDevice = new WaveOutEvent();

        outputDevice.Volume = volume;
        audioFile.CurrentTime = localPosition;
        localPosition = TimeSpan.Zero;

        outputDevice.Init(audioFile);
        outputDevice.Play();
        
        while(outputDevice.PlaybackState == PlaybackState.Playing){
            // Let audio play
        }   
        outputDevice = null;
        audioFile = null;
    }

    public void SetPath(string path){
        if(audioFile != null)
            outputDevice.Stop();
        if (!System.IO.File.Exists(path))
            throw new Exception("Wrong path!!!");
        this.path = path;
        localPosition = TimeSpan.Zero;
    }
    public void SetVolume(float volume){
        if(outputDevice != null)
            outputDevice.Volume = volume;
        else
            this.volume = volume;
    }     
    public void SetPosition(int seconds){
        if(audioFile != null)
            audioFile.CurrentTime = TimeSpan.FromSeconds(seconds);
        else
            localPosition  = TimeSpan.FromSeconds(seconds);
    }   
    async public void Play(){
        if(audioFile != null){
            return;
        }
        await Task.Run(() => {
            PlayMusic();
        });
    }  
    public void Stop(){
        if(audioFile == null)
            return;
        localPosition = audioFile.CurrentTime;
        outputDevice.Stop();
    }
}