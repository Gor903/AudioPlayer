string path1 = @"path\to\your\audio\file";
string path = @"path\to\your\audio\file";


MusicPlayer musicPlayer = MusicPlayer.GetMusicPlayer();
musicPlayer.SetPath(path);
musicPlayer.Play();

while(true){
    ConsoleKey key = Console.ReadKey(true).Key;

    switch (key){
        case ConsoleKey.S:
            musicPlayer.Stop();
            break;
        case ConsoleKey.P:
            musicPlayer.Play();break;
        case ConsoleKey.UpArrow:
            musicPlayer.SetVolume(1);break;
        case ConsoleKey.DownArrow:
            musicPlayer.SetVolume(.1f);break;
        case ConsoleKey.RightArrow:
            musicPlayer.SetPath(path1);
            musicPlayer.Play();
            break;
        case ConsoleKey.LeftArrow:
            musicPlayer.SetPath(path);
            musicPlayer.Play();
            break;
        case ConsoleKey.Spacebar:
            musicPlayer.SetPosition(100);
            break;
    }
}

